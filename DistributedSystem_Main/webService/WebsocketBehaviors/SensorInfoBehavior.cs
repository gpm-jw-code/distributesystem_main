using DistributedSystem_Main.Systems;
using Newtonsoft.Json;
using System.Linq;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    public class SensorInfoBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Staobj.Event_ReceiveSensorInfo_Websocket = SendSensorInfo;
            foreach (var item in Staobj.Dict_SensorProcessObject.ToArray())
            {
                SendSensorInfo(JsonConvert.SerializeObject(item.Value.SensorInfo));
            }
        }

        private void SendSensorInfo(string obj)
        {
            Sessions.BroadcastAsync(obj, null);
        }
    }

}
