using ISOInspection;
using Newtonsoft.Json;
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

        public static Action<string> Event_ReceiveNewSensorInfo;
        public static Action<string> Event_UpdateSensorStatus;

        public static Action<string> Event_ReceiveSensorInfo_Websocket;
        public static Action<string> Event_UpdateSensorStatus_Websocket;

        public static WebService.cls_WebSocketModule WebsocketModule;


        public struct Forms
        {
            public static FormMain Form_Main;
            public static Views.Form_Alarm Form_AlarmEvent = new Views.Form_Alarm();
        }

        public struct SystemParam
        {
            public static string DataSaveRootPath = "";
            public static bool ISOEnable = true;

            public static string SystemIniFilePath
            {
                get
                {
                    return System.IO.Path.Combine("Parameters", "SystemParameters.ini");
                }
            }
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

            public struct ChartSetting
            {
                public static int RowNumber = 2;
                public static int ColumnNumber = 2;
            }

            public static void LoadSystemParam()
            {
                Ini.IniFile SystemIniFile = new Ini.IniFile(SystemIniFilePath);

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
                cls_PostgreSQLHandler.ServerIP = PostgreSQL.IP = SystemIniFile.IniReadAndWriteValue(SectionName, "IP", "localhost");
                cls_PostgreSQLHandler.Port = PostgreSQL.Port = SystemIniFile.IniReadAndWriteValue(SectionName, "Port", 5432);
                cls_PostgreSQLHandler.Database = PostgreSQL.DataBaseName = SystemIniFile.IniReadAndWriteValue(SectionName, "DataBaseName", "gpm_distribute");
                cls_PostgreSQLHandler.Username = PostgreSQL.UserName = SystemIniFile.IniReadAndWriteValue(SectionName, "UserName", "postgres");
                cls_PostgreSQLHandler.Password = PostgreSQL.Password = SystemIniFile.IniReadAndWriteValue(SectionName, "Password", "changeme");

                SectionName = "ChartSetting";
                ChartSetting.RowNumber = SystemIniFile.IniReadAndWriteValue(SectionName, "RowNumber", 2);
                ChartSetting.ColumnNumber = SystemIniFile.IniReadAndWriteValue(SectionName, "ColumnNumber", 2);

                SectionName = "Functions";
                ISOEnable = Convert.ToBoolean(SystemIniFile.IniReadAndWriteValue(SectionName, "ISO", false.ToString()));
            }

            public static async void SaveMqttParam()
            {
                string SectionName = "MqttSetting";
                Ini.IniFile SystemIniFile = new Ini.IniFile(SystemIniFilePath);
                await SystemIniFile.IniWriteValue(SectionName, "ServerIP", Mqtt.MqttServerIP);
                await SystemIniFile.IniWriteValue(SectionName, "ServerPort", Mqtt.MqttServerPort.ToString());
            }

            public static async void SaveChartSetting()
            {
                Ini.IniFile SystemIniFile = new Ini.IniFile(SystemIniFilePath);

                string SectionName = "ChartSetting";
                await SystemIniFile.IniWriteValue(SectionName, "RowNumber", ChartSetting.RowNumber.ToString());
                await SystemIniFile.IniWriteValue(SectionName, "ColumnNumber", ChartSetting.ColumnNumber.ToString());
            }

            public static async void SaveFuncionSetting()
            {
                Ini.IniFile SystemIniFile = new Ini.IniFile(SystemIniFilePath);

                string SectionName = "Functions";
                await SystemIniFile.IniWriteValue(SectionName, "ISO", ISOEnable.ToString());
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
                var NewSensorProcessObject = new cls_SensorDataProcess(SensorInfo);
                Dict_SensorProcessObject.Add(item.SensorName, NewSensorProcessObject);

                var SensorThreshold = SensorParam.LoadThreasholdFromFile(item.SensorName);
                NewSensorProcessObject.Dict_DataThreshold = SensorThreshold;

                NewSensorProcessObject.ISOCheckObject = SensorParam.LoadISOParameters(item.SensorName, SensorInfo.ISONumber);

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
                            var settings = new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                                MissingMemberHandling = MissingMemberHandling.Ignore
                            };
                            OutputData = Newtonsoft.Json.JsonConvert.DeserializeObject<SensorInfo>(SR.ReadToEnd(), settings);
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

            public static ISObase LoadISOParameters(string SensorName,Enum_ISOInspectionNumber ISONumber)
            {
                ISObase ISOCheckObject = null;
                string Filepath = Path.Combine(SensorDataRootPath(SensorName), "ISOParameters.json");
                if (!File.Exists(Filepath))
                {
                    return null;
                }
                try
                {
                    using (StreamReader Sr = new StreamReader(Filepath))
                    {
                        string JsonString = Sr.ReadLine();
                        switch (ISONumber)
                        {
                            case Enum_ISOInspectionNumber.None:
                                break;
                            case Enum_ISOInspectionNumber.ISO10816_1:
                                ISOCheckObject = Newtonsoft.Json.JsonConvert.DeserializeObject<cls_ISO10816_1>(JsonString);
                                break;
                            case Enum_ISOInspectionNumber.ISO10816_3:
                                ISOCheckObject = Newtonsoft.Json.JsonConvert.DeserializeObject<cls_ISO10816_3>(JsonString);
                                break;
                            case Enum_ISOInspectionNumber.ISO10816_8:
                                ISOCheckObject = Newtonsoft.Json.JsonConvert.DeserializeObject<cls_ISO10816_8>(JsonString);
                                break;
                            default:
                                break;
                        }
                    }
                    return ISOCheckObject;
                }
                catch (Exception)
                {
                    return ISOCheckObject;
                }
            }
            public static void SaveISOParameters(string SensorName,ISObase ISOData)
            {
                string Filepath = Path.Combine(SensorDataRootPath(SensorName), "ISOParameters.json");
                using (FileStream FS = new FileStream(Filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter SR = new StreamWriter(FS))
                    {
                        SR.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(ISOData));
                    }
                }
            }
        }
    }
}
