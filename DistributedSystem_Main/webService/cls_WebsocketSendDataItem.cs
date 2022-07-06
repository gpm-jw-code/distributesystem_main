using SensorDataProcess;
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

    public class cls_QuerySensorTypeListOfEdge
    {
        public string edgeName { get; set; }
        public List<SensorType> sensorTypeList { get; set; } = new List<SensorType>();
    }
    public class SensorType
    {
        public string field { get; set; }
        public string label { get; set; }
    }
    public class cls_RawData
    {
        public string SensorName;
        public string EdgeName;
        public DateTime TimeLog;
        public List<DateTime> List_TimeLog;

        public Dictionary<string, double> Dict_RawData = new Dictionary<string, double>();

        public Dictionary<string, List<double>> Dict_ListRawData = new Dictionary<string, List<double>>();

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

        public cls_RawData(string SensorName, string EdgeName, DateTime TimeLog, Dictionary<string, double> Dict_RawData, Dictionary<string, double> dict_DataThreshold, Dictionary<string, OutOfState> outOfState) : this(SensorName, EdgeName, TimeLog, Dict_RawData)
        {
            this.SensorName = SensorName;
            this.EdgeName = EdgeName;
            this.TimeLog = TimeLog;
            this.Dict_RawData = Dict_RawData;
            Dict_DataThreshold = dict_DataThreshold;
            foreach (var item in Dict_RawData)
            {
                Dict_RawData_WithState.Add(item.Key, new RawDataState
                {
                    value = item.Value,
                    isOutofControl = outOfState[item.Key].isOutofControl,
                    isOutofSpec = outOfState[item.Key].isOutofSPEC,
                });
            }
        }


        public cls_RawData(string SensorName, string EdgeName, List<DateTime> List_TimeLog, Dictionary<string, List<double>> Dict_ListRawData, Dictionary<string, double> dict_DataThreshold, Dictionary<string, OutOfState> outOfState)
        {
            this.SensorName = SensorName;
            this.EdgeName = EdgeName;
            this.List_TimeLog = List_TimeLog;
            this.Dict_ListRawData = Dict_ListRawData;
            Dict_DataThreshold = dict_DataThreshold;
            foreach (var item in Dict_ListRawData)
            {
                Dict_RawData_WithState.Add(item.Key, new RawDataState
                {
                    value = item.Value.Last(),
                    isOutofControl = outOfState[item.Key].isOutofControl,
                    isOutofSpec = outOfState[item.Key].isOutofSPEC,
                });
            }
        }


    }

    public class RawDataState
    {
        public double value { get; set; }
        public bool isOutofSpec { get; set; }
        public bool isOutofControl { get; set; }
    }

    public class QueryResult
    {
        public string GroupName { get; set; }
        public string RowName { get; set; }
        public string SensorType { get; set; }
        public cls_QueryReturn QueryData { get; set; }
    }
}
