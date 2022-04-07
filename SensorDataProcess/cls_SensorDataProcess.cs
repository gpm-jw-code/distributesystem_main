using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataProcess
{
    public class StaticParameters
    {
        public static int TemDataNumber = 1000;
        private static string _DataSaveRootPath = "";
        public static string DataSaveRootPath
        {
            set { _DataSaveRootPath = value; }
        }

        public static string RawDataSaveRootPath
        {
            get { return Path.Combine(_DataSaveRootPath, "RawData"); }
        }

        public static string LogDataSaveRootPath
        {
            get { return Path.Combine(_DataSaveRootPath, "Log"); }
        }
    }

    public class cls_SensorDataProcess
    {
        public SensorInfo SensorInfo = new SensorInfo();
        public SensorStatus Status = new SensorStatus();
        public Dictionary<string, double> Dict_DataThreshold = new Dictionary<string, double>();

        private Dictionary<string, Queue<double>> Dict_SensorDataSeries = new Dictionary<string, Queue<double>>();
        private Queue<DateTime> Queue_TimeLog = new Queue<DateTime>();
        private DataPassRateObject PassRateObjejct;

        private cls_txtDataSaver TxtDataSaver;

        public delegate void UpdateSeriesDataEventHandler(string SensorName, Queue<DateTime> Queue_Time,Dictionary<string,Queue<double>> Dict_DataQueue);

        public event UpdateSeriesDataEventHandler Event_UpdateChartSeries;

        public cls_SensorDataProcess(string IP, int Port,string SensorName,string SensorType, string EQName = null, string UnitName = null)
        {
            if (IP == "127.0.0.1")
                this.SensorInfo.SensorName = $"{IP}_{Port}";
            SensorInfo.IP = IP;
            SensorInfo.Port = Port;
            SensorInfo.SensorName = SensorName;
            SensorInfo.SensorType = SensorType;
            SensorInfo.EQName = EQName ?? "";
            SensorInfo.UnitName = UnitName ?? "";
            TxtDataSaver = new cls_txtDataSaver(SensorInfo);
            PassRateObjejct = new DataPassRateObject();
        }

        public cls_SensorDataProcess(SensorInfo NewSensorInfo)
        {
            SensorInfo = NewSensorInfo;
            TxtDataSaver = new cls_txtDataSaver(SensorInfo);
            PassRateObjejct = new DataPassRateObject();
            PassRateObjejct.Event_WriteNewDataLog += TxtDataSaver.WritePassRateLog;
        }


        public void ImportNewSensorData(Dictionary<string,double> Dict_NewData,DateTime TimeLog)
        {
            TxtDataSaver.WriteRawData(Dict_NewData, TimeLog);
            var CheckResult = CheckThreshold(Dict_NewData,TimeLog);
            Queue_TimeLog.Enqueue(TimeLog);
            foreach (var item in Dict_NewData)
            {
                string DataName = item.Key;
                if (!Dict_SensorDataSeries.ContainsKey(DataName))
                {
                    Dict_SensorDataSeries.Add(DataName, new Queue<double>());
                }
                Dict_SensorDataSeries[DataName].Enqueue(item.Value);
            }

            while (Queue_TimeLog.Count>StaticParameters.TemDataNumber)
            {
                Queue_TimeLog.Dequeue();
                foreach (var item in Dict_SensorDataSeries)
                {
                    item.Value.Dequeue();
                }
            }
            Event_UpdateChartSeries?.Invoke(SensorInfo.SensorName,Queue_TimeLog,Dict_SensorDataSeries);
        }

        private Dictionary<string,bool> CheckThreshold(Dictionary<string,double> Dict_NewData,DateTime TimeLog)
        {
            Dictionary<string, bool> CheckResult = new Dictionary<string, bool>();
            foreach (var item in Dict_NewData)
            {
                if (!Dict_DataThreshold.ContainsKey(item.Key))
                {
                    Dict_DataThreshold.Add(item.Key, 999999);
                }
                CheckResult.Add(item.Key, item.Value < Dict_DataThreshold[item.Key]);
            }
            PassRateObjejct.AddNewCheckResult(CheckResult, TimeLog);
            return CheckResult;
        }

    }

    public class DataPassRateObject
    {
        public Dictionary<string, double> Dict_TotalCount = new Dictionary<string, double>();
        public Dictionary<string, double> Dict_PassCount = new Dictionary<string, double>();
        public DateTime TimeLog;
        public Action<DataPassRateObject> Event_WriteNewDataLog;

        public void AddNewCheckResult(Dictionary<string,bool> Dict_CheckResult,DateTime NewTimelog)
        {
            if (NewTimelog.Minute != this.TimeLog.Minute)
            {
                Event_WriteNewDataLog?.Invoke(this);

                Dict_TotalCount = new Dictionary<string, double>();
                Dict_PassCount = new Dictionary<string, double>();
                foreach (var item in Dict_CheckResult.Keys)
                {
                    Dict_TotalCount.Add(item,0);
                    Dict_PassCount.Add(item, 0);
                }
                this.TimeLog = new DateTime(NewTimelog.Year, NewTimelog.Month, NewTimelog.Day, NewTimelog.Hour, NewTimelog.Minute,0);
            }

            foreach (var item in Dict_CheckResult)
            {
                Dict_TotalCount[item.Key] += 1;
                if (item.Value)
                {
                    Dict_PassCount[item.Key] += 1;
                }
            }
        }
    }

    public class SensorInfo
    {
        public string IP;
        public int Port;
        public string SensorType;
        public string SensorName;
        public string EQName = "undefined";
        public string UnitName = "undefined";
    }

    public class SensorStatus
    {
        public DateTime LastUpdateTime;
        public bool ConnecStatus;
    }
}
