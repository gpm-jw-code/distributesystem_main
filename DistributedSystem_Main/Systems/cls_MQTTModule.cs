using MQTTnet;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_Main.Systems
{
    public class cls_MQTTModule
    {

        private static IMqttServer DataMqttServer = null;
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
            }
            catch (Exception)
            {

            }
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


        }
    }
}
