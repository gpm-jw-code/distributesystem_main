using DistributedSystem_Main.Systems;
using DistributedSystem_Main.WebService.WebsocketExtensions;
using Newtonsoft.Json;
using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    internal class GetThresholdSetting : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            base.OnOpen();
            var GroupName = Context.QueryString[0];
            var RowName = Context.QueryString[1];
            var DataName = Context.QueryString[2];
            var List_SensorName = Systems.cls_HomePageManager.Dict_GroupObject[GroupName].GetSensorNameByRowColumnName(RowName, DataName);
            Dictionary<string, double> ThresholdData = new Dictionary<string, double>();
            ThresholdData.Add("OOC", Staobj.Dict_SensorProcessObject[List_SensorName[0]].Dict_DataThreshold[$"{DataName}_OOC"]);
            ThresholdData.Add("OOS", Staobj.Dict_SensorProcessObject[List_SensorName[0]].Dict_DataThreshold[$"{DataName}_OOS"]);
            Send(JsonConvert.SerializeObject(ThresholdData));
        }
    }
}