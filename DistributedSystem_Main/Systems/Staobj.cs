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
       public static Dictionary<string, User_Control.USC_SensorDataChart> Dict_SensorDataCharts = new Dictionary<string, User_Control.USC_SensorDataChart>();

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

            public static async void SaveMqttParam()
            {
                string SectionName = "MqttSetting";
                Ini.IniFile SystemIniFile = new Ini.IniFile(System.IO.Path.Combine("Parameters", "SystemParameters.ini"));
                await SystemIniFile.IniWriteValue(SectionName, "ServerIP", MqttServerIP);
                await SystemIniFile.IniWriteValue(SectionName, "ServerPort", MqttServerPort.ToString());
            }
        }


        public static void ReceiveSensorInfoList(List<cls_SensorInfo_Mqtt> List_SensorInfo,string EdgeName)
        {
            foreach (var item in List_SensorInfo)
            {
                item.SensorName = $"{EdgeName}-{item.SensorName}";
                if (Dict_SensorProcessObject.ContainsKey(item.SensorName))
                    continue;

                var SensorInfo = SensorParam.LoadSensorInfoFromFile(item,EdgeName);
                Dict_SensorProcessObject.Add(item.SensorName, new cls_SensorDataProcess(SensorInfo));
                
                var SensorThreshold = SensorParam.LoadThreasholdFromFile(item.SensorName);
                Dict_SensorProcessObject[item.SensorName].Dict_DataThreshold = SensorThreshold;

                Event_ReceiveNewSensorInfo?.Invoke(item.SensorName);
            }
        }

        internal static void UpdateSensorInfo(cls_SensorStatus_Mqtt newSensorStatus,string EdgeName)
        {
            var SensorName = $"{EdgeName}-{newSensorStatus}";
            Dict_SensorProcessObject[SensorName].Status.ConnecStatus = newSensorStatus.ConnecStatus;
            Dict_SensorProcessObject[SensorName].Status.LastUpdateTime = newSensorStatus.LastUpdateTime;
            Event_UpdateSensorStatus?.Invoke(SensorName);
        }

        public struct SensorParam
        {

            public static string SensorDataRootPath(string SensorName)
            {
                string[] Edge_SensorArray= SensorName.Split('-');
                string SensorInfoDirectory = Path.Combine("Parameters", "SensorInfos",Edge_SensorArray[0], Edge_SensorArray[1]);
                if (!Directory.Exists(SensorInfoDirectory))
                {
                    Directory.CreateDirectory(SensorInfoDirectory);
                }
                return SensorInfoDirectory;
            }

            public static SensorInfo LoadSensorInfoFromFile(cls_SensorInfo_Mqtt ReceiveInfo,string EdgeName)
            {
                string SensorInfoFileName = System.IO.Path.Combine(SensorDataRootPath(ReceiveInfo.SensorName), "SensorInfo.json");
                SensorInfo OutputData = new SensorInfo() { SensorName = ReceiveInfo.SensorName, IP = ReceiveInfo.IP, Port = ReceiveInfo.Port, SensorType = ReceiveInfo.SensorType,EdgeName = EdgeName };

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
