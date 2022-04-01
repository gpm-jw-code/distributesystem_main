using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_Main.Systems
{
    public class Staobj
    {
        public static Dictionary<string, cls_SensorDataProcess> Dict_SensorProcessObject = new Dictionary<string, cls_SensorDataProcess>();
        public static Dictionary<string, Views.USC_SensorDataChart> Dict_SensorDataCharts = new Dictionary<string, Views.USC_SensorDataChart>();

        public static Action<string> Event_ReceiveNewSensorInfo;
        public static Action<string> Event_UpdateSensorStatus;

        public static void ReceiveSensorInfoList(List<cls_SensorInfo_Mqtt> List_SensorInfo)
        {
            foreach (var item in List_SensorInfo)
            {
                string SensorName = item.SensorName;
                if (Dict_SensorProcessObject.ContainsKey(SensorName))
                    continue;
                Dict_SensorProcessObject.Add(SensorName, new SensorDataProcess.cls_SensorDataProcess(item.IP, item.Port, item.SensorName));
                Dict_SensorDataCharts.Add(SensorName, new Views.USC_SensorDataChart() { SensorName = SensorName });
                Event_ReceiveNewSensorInfo?.Invoke(SensorName);
            }
        }

        internal static void UpdateSensorInfo(cls_SensorStatus_Mqtt newSensorStatus)
        {
            Dict_SensorProcessObject[newSensorStatus.SensorName].Status.ConnecStatus = newSensorStatus.ConnecStatus;
            Dict_SensorProcessObject[newSensorStatus.SensorName].Status.LastUpdateTime= newSensorStatus.LastUpdateTime;
            Event_UpdateSensorStatus?.Invoke(newSensorStatus.SensorName);
        }
    }
}
