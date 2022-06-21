using DistributedSystem_Main.Systems;
using DistributedSystem_Main.WebService.WebsocketExtensions;
using SensorDataProcess;
using System;
using System.Linq;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    /// <summary>
    /// path: /GPM/AlarmReset/?edgeName={edgename}&edid={eqid}&field={field}
    /// </summary>
    internal class AlarmResetBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            base.OnOpen();
            try
            {
                string edgeName = Context.QueryString[0];
                string eqid = Context.QueryString[1];
                string field = Context.QueryString[2];
                ResetAlarm(edgeName, eqid, field);
                Send("ok");
            }
            catch (Exception ex)
            {
                Send(ex.Message);
            }
        }
        private void ResetAlarm(string eqgeName, string eqid, string field)
        {

            if (eqid == "all" && field == "all")
            {
                var edgeSensors = Staobj.Dict_SensorProcessObject.Values.ToList().FindAll(s => s.SensorInfo.EdgeName == eqgeName);
                foreach (var item in edgeSensors)
                {
                    foreach (OutOfState state in item.Dict_OutOfItemStates.Values)
                    {
                        state.RESET();
                    }
                }
            }
            else
            {
                cls_SensorDataProcess sensor = Staobj.Dict_SensorProcessObject.Values.First(s => s.SensorInfo.EdgeName == eqgeName && s.SensorInfo.GetEQIDForWebsocket() == eqid && s.SensorInfo.SensorType == field);
                if (sensor == null) return;
                if (sensor.Dict_OutOfItemStates.TryGetValue(field, out OutOfState state))
                {
                    state.RESET();
                }

            }
        }
    }

}
