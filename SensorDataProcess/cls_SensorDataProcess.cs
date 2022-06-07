using ISOInspection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static bool ISOFunctionEnable = false;

        public SensorInfo SensorInfo = new SensorInfo();
        public SensorStatus Status = new SensorStatus();
        public Dictionary<string, double> Dict_DataThreshold = new Dictionary<string, double>();
        public Dictionary<string, OutOfState> Dict_OutOfItemStates = new Dictionary<string, OutOfState>();
        public ISObase ISOCheckObject;

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
        public Action<string> Event_RefreshSensorISOSetting;
        public Action<string> Event_UpdateSensorCheckStates;

        private object RawDataDict_Lock = new object();

        private bool IsUpdateCheckStatus_ContinuousData = false;

        public List<string> List_DataNames
        {
            get
            {
                return Dict_SensorDataSeries.Keys.ToList();
            }
        }

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

        public void ImportContinuousSensorData(Dictionary<string, List<double>> Dict_ListNewData, List<DateTime> List_TimeLog)
        {
            IsUpdateCheckStatus_ContinuousData = false;
            WriteContinuousData(Dict_ListNewData, List_TimeLog);
            for (int i = 0; i < List_TimeLog.Count; i++)
            {
                var NewDataDictionary = Dict_ListNewData.ToDictionary(item => item.Key, item => item.Value[i]);
                ImportNewSensorData(NewDataDictionary, List_TimeLog[i], true);
            }
            Event_UpdateChartSeries?.Invoke(SensorInfo.SensorName, Queue_TimeLog, Dict_SensorDataSeries);
            if (IsUpdateCheckStatus_ContinuousData)
                Event_UpdateSensorCheckStates?.Invoke(SensorInfo.SensorName);
        }

        private void WriteContinuousData(Dictionary<string, List<double>> Dict_ListNewData, List<DateTime> List_TimeLog)
        {
            TxtDataSaver.WriteContinuousRawData(Dict_ListNewData, List_TimeLog);
            SQLDataSaver?.InsertContinuousRawData(Dict_ListNewData, List_TimeLog);
        }

        private void WirteSingleData(Dictionary<string, double> Dict_NewData, DateTime TimeLog)
        {
            SQLDataSaver?.InsertRawData(Dict_NewData, TimeLog);
            TxtDataSaver.WriteRawData(Dict_NewData, TimeLog);

        }

        public void ImportNewSensorData(Dictionary<string, double> Dict_NewData, DateTime TimeLog, bool IsListData = false)
        {
            if (!IsListData)
            {
                WirteSingleData(Dict_NewData, TimeLog);
            }

            bool IsWriteHourlyData = HourlyData.ImportNewData(Dict_NewData, TimeLog);
            if (IsWriteHourlyData)
            {
                SQLDataSaver?.InsertHourlyRawData(HourlyData.Dict_AverageData, TimeLog);
            }

            var IsUpdateCheckStatus = CheckThreshold(Dict_NewData, TimeLog);
            if (IsListData)
            {
                IsUpdateCheckStatus_ContinuousData = IsUpdateCheckStatus_ContinuousData || IsUpdateCheckStatus;
            }

            if (ISOFunctionEnable && ISOCheckObject != null)
            {
                if (SensorInfo.ISOCheckDataName != null && Dict_NewData.ContainsKey(SensorInfo.ISOCheckDataName))
                {
                    var ISOCheckResult = ISOCheckObject.CalculateResult(Dict_NewData[SensorInfo.ISOCheckDataName]);
                    TxtDataSaver.WriteISOResult(ISOCheckResult, SensorInfo.ISONumber, TimeLog);
                }
            }

            lock (RawDataDict_Lock)
            {
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
            }

            if (IsListData)
            {
                return;
            }
            if (IsUpdateCheckStatus)
                Event_UpdateSensorCheckStates?.Invoke(SensorInfo.SensorName);
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


        Thread lastThread = null;

        public void RefreshSignalChart()
        {
            lastThread = Thread.CurrentThread;
            lock (RawDataDict_Lock)
            {
                lastThread = Thread.CurrentThread;
                Event_UpdateChartSeries?.Invoke(SensorInfo.SensorName, Queue_TimeLog, Dict_SensorDataSeries);
            }
        }

        public void RefreshISOChart()
        {
            Event_RefreshSensorISOSetting?.Invoke(SensorInfo.SensorName);
        }

        private bool CheckThreshold(Dictionary<string, double> Dict_NewData, DateTime TimeLog)
        {
            bool IsUpdateStatus = false;    
            Dictionary<string, bool> Dict_OOCResult = new Dictionary<string, bool>();
            Dictionary<string, bool> Dict_OOSResult = new Dictionary<string, bool>();
            foreach (var item in Dict_NewData)
            {
                string DataName = item.Key;
                double Value = item.Value;
                string oocThreshodlKey = DataName + "_OOC";
                string oosThreshodlKey = DataName + "_OOS";
                double ooc_threshold;
                double oos_threshold;
                if (!Dict_DataThreshold.ContainsKey(oocThreshodlKey))
                    Dict_DataThreshold.Add(oocThreshodlKey, 999999);
                if (!Dict_DataThreshold.ContainsKey(oosThreshodlKey))
                    Dict_DataThreshold.Add(oosThreshodlKey, 999999);

                Dict_DataThreshold.TryGetValue(oocThreshodlKey, out ooc_threshold);
                Dict_DataThreshold.TryGetValue(oosThreshodlKey, out oos_threshold);

                if (!Dict_OutOfItemStates.ContainsKey(DataName))
                    Dict_OutOfItemStates.Add(item.Key, new OutOfState());

                Dict_OOCResult.Add(DataName, Value > ooc_threshold);
                Dict_OOSResult.Add(DataName, Value > oos_threshold);

                IsUpdateStatus= UpdateCheckOutStatus(DataName, Dict_OOCResult[DataName],Dict_OOSResult[DataName]);
            }
            PassRateObjejct.AddNewCheckResult(Dict_OOCResult,Dict_OOSResult, TimeLog);
            return IsUpdateStatus;
        }

        public Dictionary<string, double> CreateThresholdByTemData()
        {
            while (Queue_TimeLog.Count < 100)
            {
                if (!Status.ConnecStatus)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            Dictionary<string, double> OutputData = new Dictionary<string, double>();
            foreach (var item in Dict_SensorDataSeries)
            {
                string DataName = item.Key;
                double DataAverage = item.Value.Average();
                double DataDeviation = clsMathTool.standardDeviation(item.Value);
                OutputData.Add($"{DataName}_OOC", DataAverage + 3 * DataDeviation);
                OutputData.Add($"{DataName}_OOS", DataAverage + 3.5 * DataDeviation);
            }
            return OutputData;
        }

        private bool UpdateCheckOutStatus(string fieldKey, bool OOC,bool OOS)
        {
            OutOfState outofState = Dict_OutOfItemStates[fieldKey];
            bool IsUpdateStatus = false;
            if (!outofState.isOutofControl)
            {
                outofState.isOutofControl = OOC;
                IsUpdateStatus = OOC;
            }
            if (!outofState.isOutofSPEC)
            {
                outofState.isOutofSPEC = OOS;
                IsUpdateStatus = OOS|| IsUpdateStatus;
            }
            return IsUpdateStatus;
        }
    }

    public class clsMathTool
    {
        /// <summary>
        /// 計算序列數據的標準差 
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static double standardDeviation(IEnumerable<double> sequence)
        {
            double result = 0;

            if (sequence.Any())
            {
                double average = sequence.Average();
                double sum = sequence.Sum(d => Math.Pow(d - average, 2));
                result = Math.Sqrt((sum) / sequence.Count());
            }
            return result;
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
        public Dictionary<string, double> Dict_OOC_Count = new Dictionary<string, double>();
        public Dictionary<string, double> Dict_OOS_Count = new Dictionary<string, double>();
        public DateTime TimeLog;
        private cls_txtDataSaver TXT_DataSaver;

        public DataPassRateObject(cls_txtDataSaver DataSaver)
        {
            this.TimeLog = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            this.TXT_DataSaver = DataSaver;
        }

        public void AddNewCheckResult(Dictionary<string,bool >Dict_New_OOC_Result,Dictionary<string,bool> Dict_New_OOS_Result, DateTime NewTimelog)
        {
            if (NewTimelog.Minute != this.TimeLog.Minute)
            {
                if (Dict_OOC_Count.Keys.Count != 0)
                {
                    TXT_DataSaver.WritePassRateLog(this);
                }

                Dict_TotalCount = new Dictionary<string, double>();
                Dict_OOC_Count = new Dictionary<string, double>();
                Dict_OOS_Count = new Dictionary<string, double>();
                this.TimeLog = new DateTime(NewTimelog.Year, NewTimelog.Month, NewTimelog.Day, NewTimelog.Hour, NewTimelog.Minute, 0);
            }

            foreach (var item in Dict_New_OOC_Result)
            {
                string DataName = item.Key; 
                if (!Dict_TotalCount.ContainsKey(DataName))
                {
                    Dict_TotalCount.Add(DataName, 0);
                    Dict_OOC_Count.Add(DataName, 0);
                    Dict_OOS_Count.Add(DataName, 0);
                }
                Dict_TotalCount[DataName] += 1;

                if (Dict_New_OOC_Result[DataName])
                    Dict_OOC_Count[DataName] += 1;

                if (Dict_New_OOS_Result[DataName])
                    Dict_OOS_Count[DataName] += 1;
            }
        }
    }

    public class SensorInfo
    {
        public string IP = "";
        public int Port = 0;
        public string SensorType = "";
        public string SensorName = "";
        public string EQName = "undefined";
        public string UnitName = "undefined";
        public string DataUnit = "";
        public string EdgeName = "";
        public string SensorNameWithOutEdgeName
        {
            get
            {
                return SensorName.Split('-').Last();
            }
        }
        public Enum_ISOInspectionNumber ISONumber = Enum_ISOInspectionNumber.None;
        public string ISOCheckDataName = "";
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
