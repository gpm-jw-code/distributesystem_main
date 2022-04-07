using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_Main.Systems
{
    public class Staobj
    {
        public static Dictionary<string, cls_SensorDataProcess> Dict_SensorProcessObject = new Dictionary<string, cls_SensorDataProcess>();
        public static Dictionary<string, Views.USC_SensorDataChart> Dict_SensorDataCharts = new Dictionary<string, Views.USC_SensorDataChart>();

        public static Action<string> Event_ReceiveNewSensorInfo;
        public static Action<string> Event_UpdateSensorStatus;

        public struct SystemParam
        {
            public static string MqttServerIP = "127.0.0.1";
            public static int MqttServerPort = 1883;
            public static string DataSaveRootPath = "";

            public static void LoadSystemParam()
            {
                Ini.IniFile SystemIniFile = new Ini.IniFile(System.IO.Path.Combine("Parameters", "SystemParameters.ini"));
                MqttServerIP = SystemIniFile.IniReadAndWriteValue("MqttSetting", "ServerIP", MqttServerIP);
                MqttServerPort = SystemIniFile.IniReadAndWriteValue("MqttSetting", "ServerPort", MqttServerPort);

                string RootDirectory = System.IO.Directory.GetDirectoryRoot(System.IO.Directory.GetCurrentDirectory());
                DataSaveRootPath = SystemIniFile.IniReadAndWriteValue("Path", "RootPath", System.IO.Path.Combine(RootDirectory, "GPM", "DistributeSystem"));
            }
        }


        public static void ReceiveSensorInfoList(List<cls_SensorInfo_Mqtt> List_SensorInfo)
        {
            foreach (var item in List_SensorInfo)
            {
                string SensorName = item.SensorName;
                if (Dict_SensorProcessObject.ContainsKey(SensorName))
                    continue;

                var SensorInfo = SensorParam.LoadSensorInfoFromFile(item);

                Dict_SensorProcessObject.Add(SensorName, new cls_SensorDataProcess(SensorInfo));
                Dict_SensorDataCharts.Add(SensorName, new Views.USC_SensorDataChart() { SensorName = SensorName, Dock = System.Windows.Forms.DockStyle.Fill });

                var SensorThreshold = SensorParam.LoadThreasholdFromFile(SensorName);
                Dict_SensorProcessObject[SensorName].Dict_DataThreshold = SensorThreshold;
                Dict_SensorDataCharts[SensorName].SetSensorThreshold(SensorThreshold);

                Event_ReceiveNewSensorInfo?.Invoke(SensorName);
            }
        }

        internal static void UpdateSensorInfo(cls_SensorStatus_Mqtt newSensorStatus)
        {
            Dict_SensorProcessObject[newSensorStatus.SensorName].Status.ConnecStatus = newSensorStatus.ConnecStatus;
            Dict_SensorProcessObject[newSensorStatus.SensorName].Status.LastUpdateTime = newSensorStatus.LastUpdateTime;
            Event_UpdateSensorStatus?.Invoke(newSensorStatus.SensorName);
        }

        public struct SensorParam
        {

            public static string SensorDataRootPath(string SensorName)
            {
                string SensorInfoDirectory = Path.Combine("Parameters", "SensorInfos", SensorName);
                if (!Directory.Exists(SensorInfoDirectory))
                {
                    Directory.CreateDirectory(SensorInfoDirectory);
                }
                return SensorInfoDirectory;
            }

            public static SensorInfo LoadSensorInfoFromFile(cls_SensorInfo_Mqtt ReceiveInfo)
            {
                string SensorInfoFileName = System.IO.Path.Combine(SensorDataRootPath(ReceiveInfo.SensorName), "SensorInfo.json");
                SensorInfo OutputData = new SensorInfo() { SensorName = ReceiveInfo.SensorName, IP = ReceiveInfo.IP, Port = ReceiveInfo.Port, SensorType = ReceiveInfo.SensorType };

                if (System.IO.File.Exists(SensorInfoFileName))
                {
                    using (FileStream FS = new FileStream(SensorInfoFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader SR = new StreamReader(FS))
                        {
                            OutputData = Newtonsoft.Json.JsonConvert.DeserializeObject<SensorInfo>(SR.ReadToEnd());
                        }
                    }
                }
                else
                {
                    SaveSensorInfoToFile(OutputData);
                }
                return OutputData;
            }

            public static void SaveSensorInfoToFile(SensorInfo SensorInfo)
            {
                string SensorInfoFileName = System.IO.Path.Combine(SensorDataRootPath(SensorInfo.SensorName), "SensorInfo.json");
                using (StreamWriter SW = new StreamWriter(SensorInfoFileName))
                {
                    SW.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(SensorInfo, Newtonsoft.Json.Formatting.Indented));
                }
            }

            public static Dictionary<string,double> LoadThreasholdFromFile(string SensorName)
            {
                Dictionary<string, double> OutputData = new Dictionary<string, double>();
                string ThresholdFileName = Path.Combine(SensorDataRootPath(SensorName), "Threshold.json");
                if (!File.Exists(ThresholdFileName))
                {
                    return new Dictionary<string, double>();
                }
                using (StreamReader SR = new StreamReader(ThresholdFileName))
                {
                    OutputData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, double>>(SR.ReadToEnd());
                }
                return OutputData;
            }

            public static void SaveThresholdToFile(Dictionary<string,double> Dict_Threshold,string SensorName)
            {
                string SensorInfoDirectory = SensorDataRootPath(SensorName);
                using (StreamWriter SW = new StreamWriter(Path.Combine( SensorInfoDirectory, "Threshold.json")))
                {
                    SW.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(Dict_Threshold, Newtonsoft.Json.Formatting.Indented));
                }
            }
        }
    }
}
