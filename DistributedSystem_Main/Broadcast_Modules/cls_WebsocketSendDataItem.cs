using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_Main.Broadcast_Modules
{
    public class cls_SensorStatus
    {
        public string SensorName;
        public bool Status;
        public string EdgeName;
        public DateTime LastUpdateTime;
    }

    public class cls_RawData
    {
        public string SensorName;
        public string EdgeName;
        public DateTime TimeLog;
        public Dictionary<string, double> Dict_RawData = new Dictionary<string, double>();
        public cls_RawData(string SensorName,string EdgeName,DateTime TimeLog,Dictionary<string,double> Dict_RawData)
        {
            this.SensorName = SensorName;
            this.EdgeName = EdgeName;
            this.TimeLog = TimeLog;
            this.Dict_RawData = Dict_RawData;
        }
    }
}
