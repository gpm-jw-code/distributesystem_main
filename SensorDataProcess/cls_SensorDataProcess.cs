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
        private cls_HourlyData HourlyData;
        private Queue<DateTime> Queue_TimeLog = new Queue<DateTime>();
        private DataPassRateObject PassRateObjejct;

        private cls_txtDataSaver TxtDataSaver;
        private cls_PostgreSQLHandler SQLDataSaver;

        public delegate void UpdateSeriesDataEventHandler(string SensorName, Queue<DateTime> Queue_Time,Dictionary<string,Queue<double>> Dict_DataQueue);
        public event UpdateSeriesDataEventHandler Event_UpdateChartSeries;

        public Action<string> Event_RefreshSensorInfo;
        public Action<string> Event_RefreshSensorThreshold;

        public cls_SensorDataProcess(string IP, int Port,string SensorName,string SensorType, string EQName = null, string UnitName = null)
        {
            SensorInfo.IP = IP;
            SensorInfo.Port = Port;
            SensorInfo.SensorName = SensorName;
            SensorInfo.SensorType = SensorType;
            SensorInfo.EQName = EQName ?? "";
            SensorInfo.UnitName = UnitName ?? "";
            SensorObjectsInitial(SensorInfo);
        }

        public cls_SensorDataProcess(SensorInfo NewSensorInfo)
        {
            SensorObjectsInitial(NewSensorInfo);
        }

        private void SensorObjectsInitial(SensorInfo NewSensorInfo)
        {
            SensorInfo = NewSensorInfo;
            TxtDataSaver = new cls_txtDataSaver(SensorInfo);
            PassRateObjejct = new DataPassRateObject(TxtDataSaver);
            HourlyData = new cls_HourlyData(TxtDataSaver);
            SQLDataSaver = new cls_PostgreSQLHandler(NewSensorInfo.EdgeName, NewSensorInfo.SensorNameWithOutEdgeName);
        }


        public void ImportNewSensorData(Dictionary<string,double> Dict_NewData,DateTime TimeLog)
        {
            SQLDataSaver.InsertRawData(Dict_NewData, TimeLog);
            TxtDataSaver.WriteRawData(Dict_NewData, TimeLog);
            HourlyData.ImportNewData(Dict_NewData, TimeLog);
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

        public void RefreshSensorInfo()
        {
            Event_RefreshSensorInfo?.Invoke(SensorInfo.SensorName);
        }

        public void RefreshThreshold()
        {
            Event_RefreshSensorThreshold?.Invoke(SensorInfo.SensorName);
        }

        public void RefreshSignalChart()
        {
            Event_UpdateChartSeries?.Invoke(SensorInfo.SensorName, Queue_TimeLog, Dict_SensorDataSeries);
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
    public class cls_HourlyData
    {
        private Dictionary<string, List<double>> Dict_HourlyData = new Dictionary<string, List<double>>();
        private DateTime TimeLog = default;
        private cls_txtDataSaver DataSaver;

        public cls_HourlyData(cls_txtDataSaver DataSaver)
        {
            Dict_HourlyData = new Dictionary<string, List<double>>();
            this.TimeLog = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0 );
            this.DataSaver = DataSaver;
        }

        public void ImportNewData(Dictionary<string,double> NewData,DateTime TimeLog)
        {
            if (TimeLog.Hour != this.TimeLog.Hour)
            {
                var AverageData = Dict_HourlyData.Select(item => new KeyValuePair<string, double>(item.Key, item.Value.Average())).ToDictionary(item=>item.Key,item=>item.Value);
                DataSaver.WriteHourlyRawData(AverageData, TimeLog);
                Dict_HourlyData = new Dictionary<string, List<double>>();
                this.TimeLog = new DateTime(TimeLog.Year, TimeLog.Month, TimeLog.Day, TimeLog.Hour, 0, 0);
            }

            foreach (var item in NewData)
            {
                if (!Dict_HourlyData.ContainsKey(item.Key))
                {
                    Dict_HourlyData.Add(item.Key, new List<double>());
                }
                Dict_HourlyData[item.Key].Add(item.Value);
            }
        }

    }

    public class DataPassRateObject
    {
        public Dictionary<string, double> Dict_TotalCount = new Dictionary<string, double>();
        public Dictionary<string, double> Dict_PassCount = new Dictionary<string, double>();
        public DateTime TimeLog;
        private cls_txtDataSaver TXT_DataSaver;

        public DataPassRateObject(cls_txtDataSaver DataSaver)
        {
            this.TimeLog = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            this.TXT_DataSaver = DataSaver;
        }

        public void AddNewCheckResult(Dictionary<string,bool> Dict_CheckResult,DateTime NewTimelog)
        {
            if (NewTimelog.Minute != this.TimeLog.Minute)
            {
                TXT_DataSaver.WritePassRateLog(this);

                Dict_TotalCount = new Dictionary<string, double>();
                Dict_PassCount = new Dictionary<string, double>();
                this.TimeLog = new DateTime(NewTimelog.Year, NewTimelog.Month, NewTimelog.Day, NewTimelog.Hour, NewTimelog.Minute,0);
            }

            foreach (var item in Dict_CheckResult)
            {
                if (!Dict_TotalCount.ContainsKey(item.Key))
                {
                    Dict_TotalCount.Add(item.Key, 0);
                    Dict_PassCount.Add(item.Key, 0);
                }
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
        public string DataUnit = "";
        public string EdgeName ;
        public string SensorNameWithOutEdgeName
        {
            get
            {
                return SensorName.Split('-').Last();
            }
        }
    }

    public class SensorStatus
    {
        public DateTime LastUpdateTime;
        public bool ConnecStatus;
    }
}
