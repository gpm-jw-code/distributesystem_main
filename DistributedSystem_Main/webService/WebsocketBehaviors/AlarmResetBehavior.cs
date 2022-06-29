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
                string GroupName = Context.QueryString[0];
                string RowName = Context.QueryString[1];
                string DataName = Context.QueryString[2];
                ResetAlarm(GroupName, RowName, DataName);
                Send("ok");
            }
            catch (Exception ex)
            {
                Send(ex.Message);
            }
        }
        private void ResetAlarm(string GroupName, string RowName, string DataName)
        {
            var List_SensorName = Systems.cls_HomePageManager.Dict_GroupObject[GroupName].GetSensorNameByRowColumnName(RowName, DataName);
            foreach (var item in List_SensorName)
            {
                Staobj.Dict_SensorProcessObject[item].Dict_OutOfItemStates[DataName].RESET();
            }
            //if (eqid == "all" && field == "all")
            //{
            //    var edgeSensors = Staobj.Dict_SensorProcessObject.Values.ToList().FindAll(s => s.SensorInfo.EdgeName == eqgeName);
            //    foreach (var item in edgeSensors)
            //    {
            //        foreach (OutOfState state in item.Dict_OutOfItemStates.Values)
            //        {
            //            state.RESET();
            //        }
            //    }
            //}
            //else
            //{
            //    cls_SensorDataProcess sensor = Staobj.Dict_SensorProcessObject.Values.First(s => s.SensorInfo.EdgeName == eqgeName && s.SensorInfo.GetEQIDForWebsocket() == eqid && s.SensorInfo.SensorType == field);
            //    if (sensor == null) return;
            //    if (sensor.Dict_OutOfItemStates.TryGetValue(field, out OutOfState state))
            //    {
            //        state.RESET();
            //    }

            //}
        }
    }

}
