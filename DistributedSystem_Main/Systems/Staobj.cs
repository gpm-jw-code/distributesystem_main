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
                MqttServerIP= SystemIniFile.IniReadAndWriteValue("MqttSetting", "ServerIP", MqttServerIP);
                MqttServerPort = SystemIniFile.IniReadAndWriteValue("MqttSetting", "ServerIP", MqttServerPort);

                string RootDirectory = System.IO.Directory.GetDirectoryRoot(System.IO.Directory.GetCurrentDirectory());
                DataSaveRootPath = SystemIniFile.IniReadAndWriteValue("Path", "RootPath", System.IO.Path.Combine(RootDirectory,"GPM","DistributeSystem"));
            }
        }


        public static void ReceiveSensorInfoList(List<cls_SensorInfo_Mqtt> List_SensorInfo)
        {
            foreach (var item in List_SensorInfo)
            {
                string SensorName = item.SensorName;
                if (Dict_SensorProcessObject.ContainsKey(SensorName))
                    continue;
                var SensorInfo = LoadSensorInfoFromFile(item);

                Dict_SensorProcessObject.Add(SensorName, new cls_SensorDataProcess(SensorInfo));
                Dict_SensorDataCharts.Add(SensorName, new Views.USC_SensorDataChart() { SensorName = SensorName,Dock = System.Windows.Forms.DockStyle.Fill });
                Event_ReceiveNewSensorInfo?.Invoke(SensorName);
            }
        }

        public static SensorInfo LoadSensorInfoFromFile(cls_SensorInfo_Mqtt ReceiveInfo)
        {
            string SensorName = ReceiveInfo.SensorName;
            string SensorInfoFileName = System.IO.Path.Combine("Parameters", "SensorInfos", SensorName,"SensorInfo.json");
            SensorInfo OutputData = new SensorInfo() { SensorName = ReceiveInfo.SensorName,IP = ReceiveInfo.IP,Port = ReceiveInfo.Port,SensorType = ReceiveInfo.SensorType };
            if (System.IO.Directory.Exists(SensorInfoFileName))
            {
                using (FileStream FS = new FileStream(SensorInfoFileName,FileMode.Open,FileAccess.Read,FileShare.ReadWrite))
                {
                    using (StreamReader SR = new StreamReader(FS))
                    {
                         OutputData = Newtonsoft.Json.JsonConvert.DeserializeObject<SensorInfo>(SR.ReadToEnd());
                    }
                }
            }
            return OutputData;
        }

        internal static void UpdateSensorInfo(cls_SensorStatus_Mqtt newSensorStatus)
        {
            Dict_SensorProcessObject[newSensorStatus.SensorName].Status.ConnecStatus = newSensorStatus.ConnecStatus;
            Dict_SensorProcessObject[newSensorStatus.SensorName].Status.LastUpdateTime= newSensorStatus.LastUpdateTime;
            Event_UpdateSensorStatus?.Invoke(newSensorStatus.SensorName);
        }
    }
}
