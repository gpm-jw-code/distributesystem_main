using DistributedSystem_Main.Systems;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    public class SensorStatusBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Staobj.Event_UpdateSensorStatus_Websocket += SendSensorStatus;
        }

        private void SendSensorStatus(string obj)
        {
            Sessions.BroadcastAsync(obj, null);
        }
    }

}
