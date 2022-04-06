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
                return Path.Combine(RootPath, "RawData", SensorInfo.SensorName);
            }
        }

        private string LogPath
        {
            get
            {
                return Path.Combine(RootPath, "Log", SensorInfo.SensorName);
            }
        }

        public cls_txtDataSaver(SensorInfo SensorInfo)
        {
            this.SensorInfo = SensorInfo;
            if (!Directory.Exists(RawDataPath))
                Directory.CreateDirectory(RawDataPath);
            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);
        }

        public void WriteRawData(Dictionary<string, double> NewData,DateTime TimeLog)
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
                if (!Directory.Exists(RawDataPath))
                    Directory.CreateDirectory(RawDataPath);
                if (!Directory.Exists(LogPath))
                    Directory.CreateDirectory(LogPath);
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
                            SW.WriteLine(PassRateLogHeader(PassRateObject.Dict_PassCount.Keys));
                        }
                        SW.WriteLine(PassRateLogString(PassRateObject));
                    }
                }
            }
            catch (IOException exp)
            {
                if (!Directory.Exists(RawDataPath))
                    Directory.CreateDirectory(RawDataPath);
                if (!Directory.Exists(LogPath))
                    Directory.CreateDirectory(LogPath);
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

        private string RawDataString(IEnumerable<double> DataValueList,DateTime TimeLog)
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
                Header += $"{item}_Pass,{item}_Total,{item}_PassRate,";
            }
            return Header;
        }

        private string PassRateLogString(DataPassRateObject PassResult)
        {
            string LogString = $"{PassResult.TimeLog:yyyy/MM/dd HH:mm},";
            foreach (var item in PassResult.Dict_PassCount.Keys)
            {
                LogString += $"{PassResult.Dict_PassCount[item]},";
                LogString += $"{PassResult.Dict_TotalCount[item]},";
                LogString += $"{(PassResult.Dict_PassCount[item] / PassResult.Dict_TotalCount[item]):F2}";
            }
            return LogString;
        }

    }
}
