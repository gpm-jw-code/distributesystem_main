using DistributedSystem_Main.Systems;
using Newtonsoft.Json;
using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var strGroupName = Context.QueryString[2];
            var strRowNames= Context.QueryString[3];
            var strSensorTypes = Context.QueryString[4];

            var List_FilterSensorNames = GetSensorNames(strGroupName, strRowNames.Split(',').ToList(), strSensorTypes.Split(',').ToList());
            List<QueryResult> List_AllResult = new List<QueryResult>();
            foreach (var item in List_FilterSensorNames)
            {
                var TargetSensorInfo = Staobj.Dict_SensorProcessObject[item].SensorInfo;
                QueryResult NewResult = new QueryResult();
                NewResult.QueryData= QueryRawData(strStartTime, strEndTime, TargetSensorInfo.EdgeName, TargetSensorInfo.SensorNameWithOutEdgeName);
                NewResult.GroupName = strGroupName;
                NewResult.RowName = cls_HomePageManager.Dict_GroupObject[strGroupName].FindRowNameWithSensorName(TargetSensorInfo.SensorName);
                NewResult.SensorType = TargetSensorInfo.SensorName;
                List_AllResult.Add(NewResult);
            }
            Send(JsonConvert.SerializeObject(List_AllResult));
        }

        private cls_QueryReturn QueryRawData(string strStartTime, string strEndTime, string EdgeName, string SenosorID)
        {
            string SensorName = $"{EdgeName}-{SenosorID}";
            SensorDataProcess.cls_PostgreSQLHandler SqlHandler = new SensorDataProcess.cls_PostgreSQLHandler(EdgeName, SenosorID);
            var ReturnData = SqlHandler.GetIntervalRawData(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime), "timelog");
            ReturnData.DataUnit = Staobj.Dict_SensorProcessObject[SensorName].SensorInfo.DataUnit;
            return ReturnData;
        }

        private List<string> GetSensorNames(string GroupName,List<string> RowNames, List<string> SensorTypes)
        {
            var TargetGroupItem = cls_HomePageManager.Dict_GroupObject[GroupName];
            List<string> RowsSensorNames= new List<string>();
            if (RowNames.Count == 0)
                RowsSensorNames = TargetGroupItem.List_SensorName;
            else
            {
                foreach (var EachRowName in RowNames)
                {
                    foreach (var item in TargetGroupItem.Dict_RowListSensor[EachRowName])
                    {
                        if (!RowsSensorNames.Contains(item))
                            RowsSensorNames.Add(item);
                    }
                }
            }
            if (SensorTypes.Count == 0)
            {
                return RowsSensorNames;
            }
            List<string> OutputSensorNames = new List<string>();
            foreach (var item in RowsSensorNames)
            {
                if (SensorTypes.Contains(Staobj.Dict_SensorProcessObject[item].SensorInfo.SensorType))
                {
                    OutputSensorNames.Add(item);
                }
            }
            return OutputSensorNames;
        }
    }

}
