﻿using System;
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
        public Dictionary<string, OutOfState> Dict_OutOfItemStatess = new Dictionary<string, OutOfState>();

        private Dictionary<string, Queue<double>> Dict_SensorDataSeries = new Dictionary<string, Queue<double>>();
        private cls_HourlyData HourlyData;
        private Queue<DateTime> Queue_TimeLog = new Queue<DateTime>();
        private DataPassRateObject PassRateObjejct;

        private cls_txtDataSaver TxtDataSaver;
        private cls_PostgreSQLHandler SQLDataSaver;

        public delegate void UpdateSeriesDataEventHandler(string SensorName, Queue<DateTime> Queue_Time, Dictionary<string, Queue<double>> Dict_DataQueue);
        public event UpdateSeriesDataEventHandler Event_UpdateChartSeries;

        public Action<string> Event_RefreshSensorInfo;
        public Action<string> Event_RefreshSensorThreshold;

        public cls_SensorDataProcess(string IP, int Port, string SensorName, string SensorType, string EQName = null, string UnitName = null)
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
            try
            {
                SQLDataSaver = new cls_PostgreSQLHandler(NewSensorInfo.EdgeName, NewSensorInfo.SensorNameWithOutEdgeName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void ImportNewSensorData(Dictionary<string, double> Dict_NewData, DateTime TimeLog)
        {
            SQLDataSaver?.InsertRawData(Dict_NewData, TimeLog);
            TxtDataSaver.WriteRawData(Dict_NewData, TimeLog);
            bool IsWriteHourlyData = HourlyData.ImportNewData(Dict_NewData, TimeLog);
            if (IsWriteHourlyData)
            {
                SQLDataSaver?.InsertHourlyRawData(HourlyData.Dict_AverageData, TimeLog);
            }
            var CheckResult = CheckThreshold(Dict_NewData, TimeLog);
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

            while (Queue_TimeLog.Count > StaticParameters.TemDataNumber)
            {
                Queue_TimeLog.Dequeue();
                foreach (var item in Dict_SensorDataSeries)
                {
                    item.Value.Dequeue();
                }
            }
            Event_UpdateChartSeries?.Invoke(SensorInfo.SensorName, Queue_TimeLog, Dict_SensorDataSeries);
        }


        public void ImportNewSensorData(Dictionary<string, double> Dict_NewData, DateTime TimeLog, out bool IsOutOfSpec, out bool IsOutOfControl)
        {
            ImportNewSensorData(Dict_NewData, TimeLog);

            IsOutOfControl = false;
            IsOutOfSpec = false;
            var thres = Dict_DataThreshold;
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

        private Dictionary<string, bool> CheckThreshold(Dictionary<string, double> Dict_NewData, DateTime TimeLog)
        {
            Dictionary<string, bool> CheckResult = new Dictionary<string, bool>();
            foreach (var item in Dict_NewData)
            {
                if (!Dict_DataThreshold.ContainsKey(item.Key))
                {
                    Dict_DataThreshold.Add(item.Key, 999999);
                }
                CheckOutOfThreshold(item.Key, item.Value);
                CheckResult.Add(item.Key, item.Value < Dict_DataThreshold[item.Key]);
            }
            PassRateObjejct.AddNewCheckResult(CheckResult, TimeLog);
            return CheckResult;
        }

        private void CheckOutOfThreshold(string fieldKey, double value)
        {
            string oocThreshodlKey = fieldKey + "_OOC";
            string oosThreshodlKey = fieldKey + "_OOS";
            double ooc_threshold = 999;
            double oos_threshold = 999;
            if (!Dict_DataThreshold.ContainsKey(oocThreshodlKey))
                Dict_DataThreshold.Add(oocThreshodlKey, 999);
            if (!Dict_DataThreshold.ContainsKey(oosThreshodlKey))
                Dict_DataThreshold.Add(oosThreshodlKey, 999);

            Dict_DataThreshold.TryGetValue(oocThreshodlKey, out ooc_threshold);
            Dict_DataThreshold.TryGetValue(oosThreshodlKey, out oos_threshold);

            if (!Dict_OutOfItemStatess.ContainsKey(fieldKey))
                Dict_OutOfItemStatess.Add(fieldKey, new OutOfState());

            OutOfState outofState = Dict_OutOfItemStatess[fieldKey];
            if (!outofState.isOutofControl)
                outofState.isOutofControl = value > ooc_threshold;
            if (!outofState.isOutofSPEC)
                outofState.isOutofSPEC = value > oos_threshold;

        }
    }
    public class cls_HourlyData
    {
        private Dictionary<string, List<double>> Dict_HourlyData = new Dictionary<string, List<double>>();
        private DateTime TimeLog = default;
        private cls_txtDataSaver DataSaver;

        public Dictionary<string, double> Dict_AverageData;

        public cls_HourlyData(cls_txtDataSaver DataSaver)
        {
            Dict_HourlyData = new Dictionary<string, List<double>>();
            this.TimeLog = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
            this.DataSaver = DataSaver;
        }

        public bool ImportNewData(Dictionary<string, double> NewData, DateTime TimeLog)
        {
            bool IsWriteData = false;
            if (TimeLog.Hour != this.TimeLog.Hour)
            {
                Dict_AverageData = Dict_HourlyData.Select(item => new KeyValuePair<string, double>(item.Key, item.Value.Average())).ToDictionary(item => item.Key, item => item.Value);
                DataSaver.WriteHourlyRawData(Dict_AverageData, TimeLog);
                Dict_HourlyData = new Dictionary<string, List<double>>();
                this.TimeLog = new DateTime(TimeLog.Year, TimeLog.Month, TimeLog.Day, TimeLog.Hour, 0, 0);
                IsWriteData = true;
            }

            foreach (var item in NewData)
            {
                if (!Dict_HourlyData.ContainsKey(item.Key))
                {
                    Dict_HourlyData.Add(item.Key, new List<double>());
                }
                Dict_HourlyData[item.Key].Add(item.Value);
            }
            return IsWriteData;
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

        public void AddNewCheckResult(Dictionary<string, bool> Dict_CheckResult, DateTime NewTimelog)
        {
            if (NewTimelog.Minute != this.TimeLog.Minute)
            {
                if (Dict_PassCount.Keys.Count != 0)
                {
                    TXT_DataSaver.WritePassRateLog(this);
                }

                Dict_TotalCount = new Dictionary<string, double>();
                Dict_PassCount = new Dictionary<string, double>();
                this.TimeLog = new DateTime(NewTimelog.Year, NewTimelog.Month, NewTimelog.Day, NewTimelog.Hour, NewTimelog.Minute, 0);
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
        public string EdgeName;
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

    public class OutOfState
    {
        public bool isOutofSPEC { get; set; }
        public bool isOutofControl { get; set; }
        public void RESET()
        {
            isOutofControl = false;
            isOutofSPEC = false;
        }
    }

}
