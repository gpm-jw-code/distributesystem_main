using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebAPIService
{
    public class cls_WebService
    {
        public string IP;
        public int Port;

        public cls_WebService(string IP,int Port)
        {
            this.IP = IP;
            this.Port = Port;
        }

        public void Start()
        {
            //開cmd執行這一段才不會跳錯 netsh http add urlacl url=http://+:{Port}/ user=machine\username
            var config = new HttpSelfHostConfiguration($"http://{IP}:{Port}");
            config.Routes.MapHttpRoute(
                "API Default", "GPM/{controller}/{id}",
                new { id = RouteParameter.Optional });
            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();

            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
            DataQuery.Functions.staobj.SystemParameters.LoadSystemParam();

        }
        public class JsonContentNegotiator : IContentNegotiator
        {
            private readonly JsonMediaTypeFormatter _jsonFormatter;

            public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
            {
                _jsonFormatter = formatter;
            }

            public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
            {
                var result = new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));

                return result;
            }

        }
    }
}
