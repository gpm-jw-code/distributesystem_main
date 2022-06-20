using DistributedSystem_Main.Systems;
using DistributedSystem_Main.WebService.WebsocketExtensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    public class GetEqListOfEdgeBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            base.OnOpen();
            var action = Context.QueryString[0];
            var edgeName = Context.QueryString[1];
            Send(JsonConvert.SerializeObject(ActionAcolate(action, edgeName)));

        }

        private object ActionAcolate(string action, string edgeName)
        {
            if (action == "GetEqListOfEdge")
            {
                return Staobj.Dict_SensorProcessObject.Values.ToList().FindAll(x => x.SensorInfo.EdgeName == edgeName).Select(s => s.SensorInfo.GetEQIDForWebsocket()).Distinct().ToList();
            }
            else if (action == "GetSensorTypeListOfEdge")
            {
                List<string> typeList = Staobj.Dict_SensorProcessObject.Values.ToList().FindAll(x => x.SensorInfo.EdgeName == edgeName).Select(s => s.SensorInfo.SensorType).Distinct().ToList();
                //Staobj.Dict_SensorProcessObject.Values.ToList().FindAll(x=>x.SensorInfo.EdgeName == edgeName).Select(s=>s.SensorInfo)
                cls_QuerySensorTypeListOfEdge result = new cls_QuerySensorTypeListOfEdge { edgeName = edgeName };

                foreach (var type in typeList)
                {
                    result.sensorTypeList.Add(new SensorType
                    {
                        field = type,
                    });
                }
                return result;
            }
            else
            {
                return "";
            }
        }
    }

}
