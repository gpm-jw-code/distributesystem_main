using DistributedSystem_Main.WebService.WebsocketBehaviors;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                _server.AddWebSocketService<QuerySensorDataBehavior>("/GPM/QuerySensorRawData");
                _server.AddWebSocketService<GetEqListOfEdgeBehavior>("/GPM/Query");
                _server.AddWebSocketService<ThresholdValueSettingBehavior>("/GPM/ThresholdSetting");
                _server.AddWebSocketService<AlarmResetBehavior>("/GPM/AlarmReset"); ///GPM/AlarmReset/?edgeName={edgename}&edid={eqid}&field={field}
                _server.AddWebSocketService<GroupInfoBehavior>("/GPM/GroupSetting");
                _server.Start();
            }
            catch (Exception)
            {

            }
        }
    }

}
