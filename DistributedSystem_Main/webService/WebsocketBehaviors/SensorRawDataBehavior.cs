using DistributedSystem_Main.Systems;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    public class SensorRawDataBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            cls_MQTTModule.Event_ReceiveSensorRawData_Websocket += SendRawData;
        }

        private void SendRawData(string obj)
        {
            Sessions.BroadcastAsync(obj, null);
        }
    }

}
