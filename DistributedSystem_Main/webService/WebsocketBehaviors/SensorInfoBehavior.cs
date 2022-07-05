using DistributedSystem_Main.Systems;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    public class SensorInfoBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Staobj.Event_ReceiveSensorInfo_Websocket = SendSensorInfo;
            List<SensorDataProcess.SensorInfo> List_AllSensorInfo = new List<SensorDataProcess.SensorInfo>();
            foreach (var item in Staobj.Dict_SensorProcessObject.ToArray())
            {
                List_AllSensorInfo.Add(item.Value.SensorInfo);
            }
            SendSensorInfo(JsonConvert.SerializeObject(List_AllSensorInfo));
        }

        private void SendSensorInfo(string obj)
        {
            Sessions.BroadcastAsync(obj, null);
        }
    }

}
