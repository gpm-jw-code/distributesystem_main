using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebAPIService.Model
{
    public class cls_QueryItem
    {

        public string SensorName { get; set; }

        public string EdgeName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
    public class cls_QueryReturn
    {
        public List<DateTime> List_TimeLog = new List<DateTime>();
        public Dictionary<string, List<double>> Dict_DataList = new Dictionary<string, List<double>>();
        public Dictionary<string, string> Dict_DataUnit = new Dictionary<string, string>();
    }

    public class cls_QueryEqListOfEdge
    {
        public string edgeName { get; set; }
        public List<string> eqList { get; set; }
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

}
