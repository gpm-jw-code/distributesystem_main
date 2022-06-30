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
            if (RowName.ToUpper()=="ALL"&DataName.ToUpper()=="ALL")
            {
                foreach (var item in Systems.cls_HomePageManager.Dict_GroupObject[GroupName].List_SensorName)
                {
                    foreach (var EachDataState in Staobj.Dict_SensorProcessObject[item].Dict_OutOfItemStates)
                    {
                        EachDataState.Value.RESET();
                    }
                }
                return;
            }
            var List_SensorName = Systems.cls_HomePageManager.Dict_GroupObject[GroupName].GetSensorNameByRowColumnName(RowName, DataName);
            foreach (var item in List_SensorName)
            {
                Staobj.Dict_SensorProcessObject[item].Dict_OutOfItemStates[DataName].RESET();
            }
        }
    }

}
