using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DistributedSystem_Main
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //var config = new HttpSelfHostConfiguration("http://localhost:8080");
            //config.Routes.MapHttpRoute(
            //    "API Default", "api/{controller}/{id}",
            //    new { id = RouteParameter.Optional });
            //HttpSelfHostServer server = new HttpSelfHostServer(config);
            //server.OpenAsync().Wait();

            //var jsonFormatter = new JsonMediaTypeFormatter();
            //config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }


    }
}
