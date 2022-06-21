using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_Main.WebService.WebsocketExtensions
{
    internal static class SensorInfoExtension
    {
        internal static string GetEQIDForWebsocket(this SensorInfo sensorInfo)
        {
            return sensorInfo.SensorNameWithOutEdgeName.Split('_')[0];
        }
    }
}
