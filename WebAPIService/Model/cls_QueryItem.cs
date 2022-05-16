using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

}
