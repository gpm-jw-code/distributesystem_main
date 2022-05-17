using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService
{
    public class cls_WebSocketModule
    {
        WebSocketServer _server;
        cls_PostgreSQL_Tool.SQL_controller SqlQueryItem;
        public cls_WebSocketModule(string IP,int Port)
        {
            try
            {
                _server = new WebSocketServer(IPAddress.Parse(IP), Port);
                _server.AddWebSocketService<SensorInfoBehavior>("/GPM/SensorInfo");
                _server.AddWebSocketService<SensorStatusBehavior>("/GPM/SensorStatus");
                _server.AddWebSocketService<SensorRawDataBehavior>("/GPM/SensorRawData");
                _server.Start();
            }
            catch (Exception)
            {

            }
        }
    }
    public class SensorInfoBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Systems.Staobj.Event_ReceiveSensorInfo_Websocket += SendSensorInfo;
            foreach (var item in Systems.Staobj.Dict_SensorProcessObject.ToArray())
            {
                SendSensorInfo( Newtonsoft.Json.JsonConvert.SerializeObject(item.Value.SensorInfo));
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
            Systems.Staobj.Event_UpdateSensorStatus_Websocket += SendSensorStatus;
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
            Systems.cls_MQTTModule.Event_ReceiveSensorRawData_Websocket += SendRawData;

        }

        private void SendRawData(string obj)
        {
            Sessions.BroadcastAsync(obj, null);
        }
    }

}
