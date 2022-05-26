using ISOInspection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataProcess
{
    public class cls_txtDataSaver
    {
        public static string RootPath = "";

        private SensorInfo SensorInfo;

        private string RawDataPath
        {
            get
            {
                var Edge_SensorNameArray = SensorInfo.SensorName.Split('-');
                return Path.Combine(RootPath, "RawData", Edge_SensorNameArray[0], Edge_SensorNameArray[1]);
            }
        }

        private string HourlyRawDataPath
        {
            get
            {
                var Edge_SensorNameArray = SensorInfo.SensorName.Split('-');
                return Path.Combine(RootPath, "HourlyRawData", Edge_SensorNameArray[0], Edge_SensorNameArray[1]);
            }
        }

        private string LogPath
        {
            get
            {
                var Edge_SensorNameArray = SensorInfo.SensorName.Split('-');
                return Path.Combine(RootPath, "Log", Edge_SensorNameArray[0], Edge_SensorNameArray[1]);
            }
        }
        private string ISOResultFileDirectory { 
            get
            {
                var Edge_SensorNameArray = SensorInfo.SensorName.Split('-');
                return Path.Combine(RootPath, "ISOResult", Edge_SensorNameArray[0], Edge_SensorNameArray[1]);
            } 
        }

        public cls_txtDataSaver(SensorInfo SensorInfo)
        {
            this.SensorInfo = SensorInfo;
            CheckDirectoryPath();
        }

        private void CheckDirectoryPath()
        {
            if (!Directory.Exists(RawDataPath))
                Directory.CreateDirectory(RawDataPath);
            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);
            if (!Directory.Exists(HourlyRawDataPath))
                Directory.CreateDirectory(HourlyRawDataPath);
            if (!Directory.Exists(ISOResultFileDirectory))
                Directory.CreateDirectory(ISOResultFileDirectory);
        }

        public void WriteRawData(Dictionary<string, double> NewData, DateTime TimeLog)
        {
            string FileName = Path.Combine(RawDataPath, $"{TimeLog:yyyyMMdd_HH}.csv");
            bool IsNeedHeader = !File.Exists(FileName);
            try
            {
                using (FileStream FS = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter SW = new StreamWriter(FS))
                    {
                        if (IsNeedHeader)
                        {
                            SW.WriteLine(SensorInfoString);
                            SW.WriteLine(RawDataHeader(NewData.Keys));
                        }
                        SW.WriteLine(RawDataString(NewData.Values, TimeLog));
                    }
                }
            }
            catch (IOException exp)
            {
                CheckDirectoryPath();
            }
        }

        public void WriteHourlyRawData(Dictionary<string, double> NewData, DateTime TimeLog)
        {
            string FileName = Path.Combine(HourlyRawDataPath, $"{TimeLog:yyyyMMdd}.csv");
            bool IsNeedHeader = !File.Exists(FileName);
            try
            {
                using (FileStream FS = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter SW = new StreamWriter(FS))
                    {
                        if (IsNeedHeader)
                        {
                            SW.WriteLine(SensorInfoString);
                            SW.WriteLine(RawDataHeader(NewData.Keys));
                        }
                        SW.WriteLine(RawDataString(NewData.Values, TimeLog));
                    }
                }
            }
            catch (IOException exp)
            {
                CheckDirectoryPath();
            }
        }

        public void WritePassRateLog(DataPassRateObject PassRateObject)
        {
            string FileName = Path.Combine(LogPath, $"{PassRateObject.TimeLog:yyyyMMdd_HH}.csv");
            bool IsNeedHeader = !File.Exists(FileName);
            try
            {
                using (FileStream FS = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter SW = new StreamWriter(FS))
                    {
                        if (IsNeedHeader)
                        {
                            SW.WriteLine(SensorInfoString);
                            SW.WriteLine(PassRateLogHeader(PassRateObject.Dict_OOC_Count.Keys));
                        }
                        SW.WriteLine(PassRateLogString(PassRateObject));
                    }
                }
            }
            catch (IOException exp)
            {
                CheckDirectoryPath();
            }
        }

        public void WriteISOResult(ResultLevel Result, Enum_ISOInspectionNumber ISONumber, DateTime TimeLog = default)
        {
            TimeLog = TimeLog == default ? DateTime.Now : TimeLog;
            string FileName = Path.Combine(ISOResultFileDirectory, TimeLog.ToString("yyyyMMdd_HH") + ".csv");
            bool IsNeedHeader = !File.Exists(FileName);
            string DataString = $"{TimeLog:yyyy/MM/dd HH:mm:ss},{ISONumber},{Result}";
            try
            {
                using (FileStream FS = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter SW = new StreamWriter(FS))
                    {
                        if (IsNeedHeader)
                        {
                            SW.WriteLine(SensorInfoString);
                            SW.WriteLine("Time,ISO Number,Result");
                        }
                        SW.WriteLine(DataString);
                    }
                }
            }
            catch (Exception)
            {
                CheckDirectoryPath();
            }
        }

        private string SensorInfoString
        {
            get
            {
                string InfoString = $"Sensor IP:{SensorInfo.IP},";
                InfoString += $"EQ Name:{SensorInfo.EQName},";
                InfoString += $"Unit Name:{SensorInfo.UnitName},";
                InfoString += $"Sensor Type:{SensorInfo.SensorType}";
                InfoString += "\r\n";

                return InfoString;
            }
        }


        private string RawDataHeader(IEnumerable<string> DataNameList)
        {
            string Header = "Time,";
            Header += string.Join(",", DataNameList);

            return Header;
        }

        private string RawDataString(IEnumerable<double> DataValueList, DateTime TimeLog)
        {
            string DataString = $"{TimeLog:yyyy/MM/dd HH:mm:ss},";
            DataString += string.Join(",", DataValueList);

            return DataString;
        }


        private string PassRateLogHeader(IEnumerable<string> DataNameList)
        {
            string Header = "Time,";
            foreach (var item in DataNameList)
            {
                Header += $"{item}_OOC,{item}_OOS,{item}_Total,{item}_OOCRate,{item}_OOSRate,";
            }
            return Header;
        }

        private string PassRateLogString(DataPassRateObject PassResult)
        {
            string LogString = $"{PassResult.TimeLog:yyyy/MM/dd HH:mm},";
            foreach (var item in PassResult.Dict_OOC_Count.Keys)
            {
                LogString += $"{PassResult.Dict_OOC_Count[item]},";
                LogString += $"{PassResult.Dict_OOS_Count[item]},";
                LogString += $"{PassResult.Dict_TotalCount[item]},";
                LogString += $"{(PassResult.Dict_OOC_Count[item] / PassResult.Dict_TotalCount[item]):F2},";
                LogString += $"{(PassResult.Dict_OOS_Count[item] / PassResult.Dict_TotalCount[item]):F2},";
            }
            return LogString;
        }

    }
}
