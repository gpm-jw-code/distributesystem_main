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

        private string RawDataString(IEnumerable<double> DataValueList,DateTime TimeLog)
        {
            string DataString = $"{TimeLog:yyyy/MM/dd HH:mm:ss},";
            DataString += string.Join(",", DataValueList);

            return DataString;
        }

        private string RawDataHeader(IEnumerable<string> DataNameList)
        {
            string Header = "Time,";
            Header += string.Join(",", DataNameList);

            return Header;
        }
    }
}
