using MQTTnet;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DistributedSystem_Main.Systems
{
    public class cls_MQTTModule
    {

        private static IMqttServer DataMqttServer = null;
        public static Dictionary<string, List<string>> Dict_ClientTopic = new Dictionary<string, List<string>>();

        public static Action<string> Event_ReceiveSensorRawData_Websocket;

        public static async void BuildServer(string IP, int Port)
        {
            try
            {
                var optionBuilder = new MqttServerOptionsBuilder()
                    .WithDefaultEndpointBoundIPAddress(IPAddress.Parse(IP))
                    .WithDefaultEndpointPort(Port)
                    .WithConnectionBacklog(50);
                DataMqttServer = new MqttFactory().CreateMqttServer();
                await DataMqttServer.StartAsync(optionBuilder.Build());

                DataMqttServer.ClientConnectedHandler = new MqttServerClientConnectedHandlerDelegate(new Action<MqttServerClientConnectedEventArgs>(ClientConnectEvent));
                DataMqttServer.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(new Action<MqttApplicationMessageReceivedEventArgs>(ReceiveNewMqttMessageAction));
                Staobj.Forms.Form_Main.SetMqttConnectState(true);
            }
            catch (Exception)
            {
                Thread.Sleep(3000);
                BuildServer(IP, Port);
            }
        }

        public static async Task<bool> DestoryServer()
        {
            if (!DataMqttServer.IsStarted)
            {
                return true;
            }
            try
            {
                await DataMqttServer.StopAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<MQTTnet.Server.Status.MqttClientStatus> GetClientList()
        {
            var Clients = DataMqttServer.GetClientStatusAsync();
            List<MQTTnet.Server.Status.MqttClientStatus> List_MqttClientStatus = Clients.Result.Cast<MQTTnet.Server.Status.MqttClientStatus>().ToList();
            return List_MqttClientStatus;
        }

        private static void ClientConnectEvent(MqttServerClientConnectedEventArgs obj)
        {
            string ID = obj.ClientId;
            SubscribeNewClientAndTopic(ID);
        }

        public static void SubscribeNewClientAndTopic(string ClientID)
        {
            MqttTopicFilter[] SubscribeTopicFilter = new MqttTopicFilter[]
              {
                new MqttTopicFilter()
                {
                    Topic = "GPM/#",
                    QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce
                }};
            DataMqttServer.SubscribeAsync(ClientID, SubscribeTopicFilter);

        }

        private static void ReceiveNewMqttMessageAction(MqttApplicationMessageReceivedEventArgs ReceivedMessage)
        {
            string TopicName = ReceivedMessage.ApplicationMessage.Topic;
            string Data = Encoding.UTF8.GetString(ReceivedMessage.ApplicationMessage.Payload);
            string EdgeName = TopicName.Split('/')[1];
            string ClientID = ReceivedMessage.ClientId;
            if (!Dict_ClientTopic.ContainsKey(ClientID))
            {
                Dict_ClientTopic.Add(ClientID, new List<string>());
            }
            if (!Dict_ClientTopic[ClientID].Contains(TopicName))
            {
                Dict_ClientTopic[ClientID].Add(TopicName);
            }

            if (TopicName.ToUpper().Contains("SensorList".ToUpper()))
            {
                List<cls_SensorInfo_Mqtt> List_SensorInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<cls_SensorInfo_Mqtt>>(Data);
                Staobj.ReceiveSensorInfoList(List_SensorInfo, EdgeName);
            }
            else if (TopicName.ToUpper().Contains("UpdateSensorStatus".ToUpper()))
            {
                cls_SensorStatus_Mqtt NewSensorStatus = Newtonsoft.Json.JsonConvert.DeserializeObject<cls_SensorStatus_Mqtt>(Data);
                Staobj.UpdateSensorInfo(NewSensorStatus, EdgeName);
            }
            else
            {
                string OriginSensorName = TopicName.Split('/').Last();
                string SensorName = $"{EdgeName}-{OriginSensorName}";
                Systems.cls_SensorData_Mqtt NewData = Newtonsoft.Json.JsonConvert.DeserializeObject<cls_SensorData_Mqtt>(Data);

                WebService.cls_RawData RawData = null;
                if (Staobj.Dict_SensorProcessObject.ContainsKey(SensorName))
                {

                    var sensorPcrObj = Staobj.Dict_SensorProcessObject[SensorName];
                    var sensorType = sensorPcrObj.SensorInfo.SensorType;

                    if (NewData.IsArrayData)
                    {
                        sensorPcrObj.ImportContinuousSensorData(NewData.Dict_ListRawData, NewData.List_TimeLog);
                        RawData = new WebService.cls_RawData(OriginSensorName, EdgeName, NewData.List_TimeLog, NewData.Dict_ListRawData, sensorPcrObj.Dict_DataThreshold, sensorPcrObj.Dict_OutOfItemStates);
                    }
                    else
                    {
                        if (NewData.Dict_RawData.Count == 0)
                        {
                            return;
                        }
                        sensorPcrObj.ImportNewSensorData(NewData.Dict_RawData, NewData.TimeLog);
                        RawData = new WebService.cls_RawData(OriginSensorName, EdgeName, NewData.TimeLog, NewData.Dict_RawData, sensorPcrObj.Dict_DataThreshold, sensorPcrObj.Dict_OutOfItemStates);
                    }

                    Event_ReceiveSensorRawData_Websocket?.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(RawData));
                }
            }

        }
    }
}
