using DistributedSystem_Main.Systems;
using DistributedSystem_Main.WebService.WebsocketExtensions;
using System;
using System.Linq;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    /// <summary>
    /// /?edgeName={edgename}&edid={eqid}&field={field}&type={oos/ooc}&value={threshold_value}
    /// </summary>
    internal class ThresholdValueSettingBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            base.OnOpen();
            try
            {
                string GroupName = Context.QueryString[0];
                string RowName = Context.QueryString[1];
                string DataName = Context.QueryString[2];
                string threshold_type = Context.QueryString[3];
                string value = Context.QueryString[4];
                SettingThresholdValue(GroupName, RowName, DataName, threshold_type, double.Parse(value));
                Send("ok"); //TODO 
            }
            catch (Exception ex)
            {
                Send(ex.Message);
            }
        }
        private void SettingThresholdValue(string GroupName,string RowName,string DataName, string thresholdType, double thresholdValue)
        {
            string ThresholdKey = $"{DataName}_{thresholdType}";
            var List_SensorName =Systems.cls_HomePageManager.Dict_GroupObject[GroupName].GetSensorNameByRowColumnName(RowName, DataName);
            foreach (var item in List_SensorName)
            {
                var TargetSensorItem = Staobj.Dict_SensorProcessObject[item];
                if (!TargetSensorItem.Dict_DataThreshold.ContainsKey(ThresholdKey))
                {
                    TargetSensorItem.Dict_DataThreshold.Add(ThresholdKey, 0);
                }
                TargetSensorItem.Dict_DataThreshold[ThresholdKey] = thresholdValue;
                Systems.Staobj.SensorParam.SaveThresholdToFile(TargetSensorItem.Dict_DataThreshold, TargetSensorItem.SensorInfo.SensorName);
            }
        }
        //private void SettingThresholdValue(string edgeName, string eqid, string field, string thresholdType, double thresholdValue)
        //{
        //    SensorDataProcess.cls_SensorDataProcess sensor = Staobj.Dict_SensorProcessObject.Values.First(s => s.SensorInfo.EdgeName == edgeName && s.SensorInfo.GetEQIDForWebsocket() == eqid && s.SensorInfo.SensorType == field);
        //    string thresholdKey = field + "_" + thresholdType;
        //    double _thresholdValue;
        //    bool thresholdExist = sensor.Dict_DataThreshold.TryGetValue(thresholdKey, out _thresholdValue);
        //    if (thresholdExist)
        //    {
        //        sensor.Dict_DataThreshold[thresholdKey] = thresholdValue;
        //    }
        //    else
        //    {
        //        sensor.Dict_DataThreshold.Add(thresholdKey, thresholdValue);
        //    }
        //    Systems.Staobj.SensorParam.SaveThresholdToFile(sensor.Dict_DataThreshold, sensor.SensorInfo.SensorName);

        //}
    }

}
