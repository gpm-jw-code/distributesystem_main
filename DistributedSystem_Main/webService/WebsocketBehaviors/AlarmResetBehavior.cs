using DistributedSystem_Main.Systems;
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

            cls_SensorDataProcess sensor = Staobj.Dict_SensorProcessObject.Values.First(s => s.SensorInfo.EdgeName == eqgeName && s.SensorInfo.IP == eqid && s.SensorInfo.SensorType == field);
            if (sensor == null) return;

            if (sensor.Dict_OutOfItemStates.TryGetValue(field, out OutOfState state))
            {
                state.RESET();
            }

        }
    }

}
