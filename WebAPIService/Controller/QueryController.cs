using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPIService.Model;

namespace WebAPIService.Controller
{
    public class QueryController : ApiController
    {
        public static event EventHandler<cls_QueryEqListOfEdge> GetEqListOfEdgeOnRequest;
        public static event EventHandler<cls_QuerySensorTypeListOfEdge> GetSensorTypeListOfEdgeOnRequest;

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
            var IntervalData = DataQuery.Functions.cls_txtQuery.QueryIntervalRawData(QueryInfo.StartTime, QueryInfo.EndTime, SensorInfo);
            Model.cls_QueryReturn ReturnData = new Model.cls_QueryReturn();
            ReturnData.List_TimeLog = IntervalData.List_TimeLog;
            ReturnData.Dict_DataList = IntervalData.Dict_DataSeries;

            return ReturnData;
        }

        [HttpGet]
        [ActionName("GetEqListOfEdge")]
        public async Task<cls_QueryEqListOfEdge> GetEqListOfEdge(string edgeName)
        {
            System.Threading.CancellationTokenSource ctokenSource = new System.Threading.CancellationTokenSource();
            cls_QueryEqListOfEdge result = new cls_QueryEqListOfEdge { edgeName = edgeName };
            GetEqListOfEdgeOnRequest?.BeginInvoke(this, result, new AsyncCallback((IAsyncResult ar) =>
            {
                ctokenSource.Cancel();
            }), result);
            try
            {
                await Task.Delay(-1, ctokenSource.Token);
            }
            catch
            {
            }

            return result;
        }


        [HttpGet]
        [ActionName("GetSensorTypeListOfEdge")]
        public async Task<cls_QuerySensorTypeListOfEdge> GetSensorTypeListOfEdge(string edgeName)
        {
            System.Threading.CancellationTokenSource ctokenSource = new System.Threading.CancellationTokenSource();
            cls_QuerySensorTypeListOfEdge result = new cls_QuerySensorTypeListOfEdge { edgeName = edgeName };
            GetSensorTypeListOfEdgeOnRequest?.BeginInvoke(this, result, new AsyncCallback((IAsyncResult ar) =>
            {
                ctokenSource.Cancel();
            }), result);
            try
            {
                await Task.Delay(-1, ctokenSource.Token);
            }
            catch
            {
            }
            return result;
        }
    }
}
