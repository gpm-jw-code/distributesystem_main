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

        public static Action<string> Event_ReceiveSensorInfo_Websocket;
        public static Action<string> Event_UpdateSensorStatus_Websocket;

        public static WebService.cls_WebSocketModule WebsocketModule;

        //public static WebAPIService.cls_WebService WebAPIObject;

        public struct SystemParam
        {
            public static string DataSaveRootPath = "";
            public struct Mqtt
            {
                public static string MqttServerIP = "127.0.0.1";
                public static int MqttServerPort = 1883;
            }

            public struct WebSocket
            {
                public static bool Enable = true;
                public static string WebsocketIP = "0.0.0.0";
                public static int WebsocketPort = 8080;
            }

            public struct PostgreSQL
            {
                public static bool Enable = true;
                public static string IP = "localhost";
                public static int Port = 5432;
                public static string DataBaseName = "gpm_distribute";
                public static string UserName = "postgres";
                public static string Password = "changeme";
            }

            public static void LoadSystemParam()
            {
                Ini.IniFile SystemIniFile = new Ini.IniFile(System.IO.Path.Combine("Parameters", "SystemParameters.ini"));

                string SectionName = "MqttSetting";
                Mqtt.MqttServerIP = SystemIniFile.IniReadAndWriteValue(SectionName, "ServerIP", Mqtt.MqttServerIP);
                Mqtt.MqttServerPort = SystemIniFile.IniReadAndWriteValue(SectionName, "ServerPort", Mqtt.MqttServerPort);

                string RootDirectory = System.IO.Directory.GetDirectoryRoot(System.IO.Directory.GetCurrentDirectory());
                DataSaveRootPath = SystemIniFile.IniReadAndWriteValue("Path", "RootPath", System.IO.Path.Combine(RootDirectory, "GPM", "DistributeSystem"));

                SectionName = "WebSocket";
                WebSocket.WebsocketIP = SystemIniFile.IniReadAndWriteValue(SectionName, "ServerIP", "0.0.0.0");
                WebSocket.WebsocketPort = SystemIniFile.IniReadAndWriteValue(SectionName, "Port", 8080);
                Staobj.WebsocketModule = new WebService.cls_WebSocketModule(WebSocket.WebsocketIP, WebSocket.WebsocketPort);

                SectionName = "PostgreSQL";
                PostgreSQL.IP = SystemIniFile.IniReadAndWriteValue(SectionName, "IP", "localhost");
                PostgreSQL.Port = SystemIniFile.IniReadAndWriteValue(SectionName, "Port", 5432);
                PostgreSQL.DataBaseName = SystemIniFile.IniReadAndWriteValue(SectionName, "DataBaseName", "gpm_distribute");
                PostgreSQL.UserName = SystemIniFile.IniReadAndWriteValue(SectionName, "UserName", "postgres");
                PostgreSQL.Password = SystemIniFile.IniReadAndWriteValue(SectionName, "Password", "changeme");
            }

            public static async void SaveMqttParam()
            {
                string SectionName = "MqttSetting";
                Ini.IniFile SystemIniFile = new Ini.IniFile(System.IO.Path.Combine("Parameters", "SystemParameters.ini"));
                await SystemIniFile.IniWriteValue(SectionName, "ServerIP", Mqtt.MqttServerIP);
                await SystemIniFile.IniWriteValue(SectionName, "ServerPort", Mqtt.MqttServerPort.ToString());
            }
        }


        public static void ReceiveSensorInfoList(List<cls_SensorInfo_Mqtt> List_SensorInfo, string EdgeName)
        {
            foreach (var item in List_SensorInfo)
            {
                item.SensorName = $"{EdgeName}-{item.SensorName}";
                if (Dict_SensorProcessObject.ContainsKey(item.SensorName))
                    continue;

                var SensorInfo = SensorParam.LoadSensorInfoFromFile(item, EdgeName);
                Dict_SensorProcessObject.Add(item.SensorName, new cls_SensorDataProcess(SensorInfo));

                var SensorThreshold = SensorParam.LoadThreasholdFromFile(item.SensorName);
                Dict_SensorProcessObject[item.SensorName].Dict_DataThreshold = SensorThreshold;

                Event_ReceiveNewSensorInfo?.Invoke(item.SensorName);
                Event_ReceiveSensorInfo_Websocket?.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(SensorInfo));
            }
        }

        internal static void UpdateSensorInfo(cls_SensorStatus_Mqtt newSensorStatus, string EdgeName)
        {
            var SensorName = $"{EdgeName}-{newSensorStatus.SensorName}";
            Dict_SensorProcessObject[SensorName].Status.ConnecStatus = newSensorStatus.ConnectStatus;
            Dict_SensorProcessObject[SensorName].Status.LastUpdateTime = newSensorStatus.LastUpdateTime;
            Event_UpdateSensorStatus?.Invoke(SensorName);
            WebService.cls_SensorStatus WebsocketSensorStatus = new WebService.cls_SensorStatus()
            {
                EdgeName = EdgeName,
                SensorName = newSensorStatus.SensorName,
                LastUpdateTime = newSensorStatus.LastUpdateTime,
                Status = newSensorStatus.ConnectStatus
            };
            Event_UpdateSensorStatus_Websocket?.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(WebsocketSensorStatus));
        }

        public struct SensorParam
        {

            public static string SensorDataRootPath(string SensorName)
            {
                string[] Edge_SensorArray = SensorName.Split('-');
                string SensorInfoDirectory = Path.Combine("Parameters", "SensorInfos", Edge_SensorArray[0], Edge_SensorArray[1]);
                if (!Directory.Exists(SensorInfoDirectory))
                {
                    Directory.CreateDirectory(SensorInfoDirectory);
                }
                return SensorInfoDirectory;
            }

            public static SensorInfo LoadSensorInfoFromFile(cls_SensorInfo_Mqtt ReceiveInfo, string EdgeName)
            {
                string SensorInfoFileName = System.IO.Path.Combine(SensorDataRootPath(ReceiveInfo.SensorName), "SensorInfo.json");
                SensorInfo OutputData = new SensorInfo() { SensorName = ReceiveInfo.SensorName, IP = ReceiveInfo.IP, Port = ReceiveInfo.Port, SensorType = ReceiveInfo.SensorType, EdgeName = EdgeName, DataUnit = ReceiveInfo.DataUnit };

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

            public static Dictionary<string, double> LoadThreasholdFromFile(string SensorName)
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

            public static void SaveThresholdToFile(Dictionary<string, double> Dict_Threshold, string SensorName)
            {
                string SensorInfoDirectory = SensorDataRootPath(SensorName);
                using (StreamWriter SW = new StreamWriter(Path.Combine(SensorInfoDirectory, "Threshold.json")))
                {
                    SW.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(Dict_Threshold, Newtonsoft.Json.Formatting.Indented));
                }
            }
        }
    }
}
