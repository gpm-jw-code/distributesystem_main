using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIService.Controller
{
    public class QueryController : ApiController
    {
        [HttpGet]
        public string TestGet()
        {
            return "Test123";
        }

        [HttpPost]
        public Model.cls_QueryReturn IntervalDataQuery([FromBody] Model.cls_QueryItem QueryInfo)
        {
            var SensorInfo = new SensorDataProcess.SensorInfo();
            SensorInfo.SensorName = QueryInfo.SensorName;
            SensorInfo.EdgeName = QueryInfo.EdgeName;
            var IntervalData= DataQuery.Functions.cls_txtQuery.QueryIntervalRawData(QueryInfo.StartTime, QueryInfo.EndTime, SensorInfo);
            Model.cls_QueryReturn ReturnData = new Model.cls_QueryReturn();
            ReturnData.List_TimeLog = IntervalData.List_TimeLog;
            ReturnData.Dict_DataList = IntervalData.Dict_DataSeries;

            return ReturnData;
        }

      
    }
}
