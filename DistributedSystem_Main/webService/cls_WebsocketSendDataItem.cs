using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_Main.WebService
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
        public Dictionary<string, RawDataState> Dict_RawData_WithState = new Dictionary<string, RawDataState>();
        public Dictionary<string, double> Dict_DataThreshold { get; }
        public cls_RawData(string SensorName, string EdgeName, DateTime TimeLog, Dictionary<string, double> Dict_RawData)
        {
            this.SensorName = SensorName;
            this.EdgeName = EdgeName;
            this.TimeLog = TimeLog;
            this.Dict_RawData = Dict_RawData;
        }

        public cls_RawData(string SensorName, string EdgeName, DateTime TimeLog, Dictionary<string, RawDataState> Dict_RawData_WithState)
        {
            this.SensorName = SensorName;
            this.EdgeName = EdgeName;
            this.TimeLog = TimeLog;
            this.Dict_RawData_WithState = Dict_RawData_WithState;
        }

        public cls_RawData(string SensorName, string EdgeName, DateTime TimeLog, Dictionary<string, double> Dict_RawData, Dictionary<string, double> dict_DataThreshold) : this(SensorName, EdgeName, TimeLog, Dict_RawData)
        {
            this.SensorName = SensorName;
            this.EdgeName = EdgeName;
            this.TimeLog = TimeLog;
            this.Dict_RawData = Dict_RawData;
            Dict_DataThreshold = dict_DataThreshold;
            foreach (var item in Dict_RawData)
            {
                bool isOutOfControl = item.Value > Dict_DataThreshold[item.Key];
                Dict_RawData_WithState.Add(item.Key, new RawDataState
                {
                    value = item.Value,
                    isOutofControl = isOutOfControl,
                    isOutOfSpec = isOutOfControl,
                });
            }
        }

    }

    public class RawDataState
    {
        public double value { get; set; }
        public bool isOutOfSpec { get; set; }
        public bool isOutofControl { get; set; }
    }
}
