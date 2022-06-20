using DistributedSystem_Main.Systems;
using Newtonsoft.Json;
using System;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    internal class QuerySensorDataBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            base.OnOpen();
            var strStartTime = Context.QueryString[0];
            var strEndTime = Context.QueryString[1];
            var strEdgeName = Context.QueryString[2];
            var strSensorName = Context.QueryString[3];

            Send(JsonConvert.SerializeObject(QueryRawData(strStartTime, strEndTime, strEdgeName, strSensorName)));
        }

        private object QueryRawData(string strStartTime, string strEndTime, string EdgeName, string SenosorID)
        {
            string SensorName = $"{EdgeName}-{SenosorID}";
            SensorDataProcess.cls_PostgreSQLHandler SqlHandler = new SensorDataProcess.cls_PostgreSQLHandler(EdgeName, SenosorID);
            var ReturnData = SqlHandler.GetIntervalRawData(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime), "timelog");
            ReturnData.DataUnit = Staobj.Dict_SensorProcessObject[SensorName].SensorInfo.DataUnit;
            return ReturnData;
        }
    }

}
