using DistributedSystem_Main.Systems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPIService.Model;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService
{
    public class cls_WebSocketModule
    {
        WebSocketServer _server;
        public cls_WebSocketModule(string IP, int Port)
        {
            try
            {
                _server = new WebSocketServer(IPAddress.Parse(IP), Port);
                _server.AddWebSocketService<SensorInfoBehavior>("/GPM/SensorInfo");
                _server.AddWebSocketService<SensorStatusBehavior>("/GPM/SensorStatus");
                _server.AddWebSocketService<SensorRawDataBehavior>("/GPM/SensorRawData");
                _server.AddWebSocketService<GetEqListOfEdgeBehavior>("/GPM/Query");
                _server.AddWebSocketService<ThresholdValueSettingBehavior>("/GPM/ThresholdSetting");
                _server.AddWebSocketService<AlarmResetBehavior>("/GPM/AlarmReset"); ///GPM/AlarmReset/?edgeName={edgename}&edid={eqid}&field={field}
                _server.Start();
            }
            catch (Exception)
            {

            }
        }
    }

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
                string edgeName = Context.QueryString[0];
                string eqid = Context.QueryString[1];
                string field = Context.QueryString[2];
                string threshold_type = Context.QueryString[3];
                string value = Context.QueryString[4];
                SettingThresholdValue(edgeName, eqid, field, threshold_type, double.Parse(value));
                Send("ok"); //TODO 
            }
            catch (Exception ex)
            {
                Send(ex.Message);
            }
        }
        private void SettingThresholdValue(string edgeName, string eqid, string field, string thresholdType, double thresholdValue)
        {
            SensorDataProcess.cls_SensorDataProcess sensor = Staobj.Dict_SensorProcessObject.Values.First(s => s.SensorInfo.EdgeName == edgeName && s.SensorInfo.IP == eqid);
            string thresholdKey = field + "_" + thresholdType;
            double _thresholdValue;
            bool thresholdExist = sensor.Dict_DataThreshold.TryGetValue(thresholdKey, out _thresholdValue);
            if (thresholdExist)
            {
                sensor.Dict_DataThreshold[thresholdKey] = thresholdValue;
            }
            else
            {
                sensor.Dict_DataThreshold.Add(thresholdKey, thresholdValue);
            }
        }
    }

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

        }
    }

    public class SensorInfoBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Staobj.Event_ReceiveSensorInfo_Websocket += SendSensorInfo;
            foreach (var item in Staobj.Dict_SensorProcessObject.ToArray())
            {
                SendSensorInfo(JsonConvert.SerializeObject(item.Value.SensorInfo));
            }
        }

        private void SendSensorInfo(string obj)
        {
            Sessions.BroadcastAsync(obj, null);
        }
    }

    public class SensorStatusBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Staobj.Event_UpdateSensorStatus_Websocket += SendSensorStatus;
        }

        private void SendSensorStatus(string obj)
        {
            Sessions.BroadcastAsync(obj, null);
        }
    }

    public class SensorRawDataBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            cls_MQTTModule.Event_ReceiveSensorRawData_Websocket += SendRawData;
        }

        private void SendRawData(string obj)
        {
            Sessions.BroadcastAsync(obj, null);
        }
    }

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
                return Staobj.Dict_SensorProcessObject.Values.ToList().FindAll(x => x.SensorInfo.EdgeName == edgeName).Select(s => s.SensorInfo.IP).Distinct().ToList();
            }
            else if (action == "GetSensorTypeListOfEdge")
            {
                List<string> typeList = Staobj.Dict_SensorProcessObject.Values.ToList().FindAll(x => x.SensorInfo.EdgeName == edgeName).Select(s => s.SensorInfo.SensorType).Distinct().ToList();
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
