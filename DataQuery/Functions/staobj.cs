using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataQuery.Functions
{
    public class staobj
    {
        

        public static Dictionary<string, Dictionary<string, SensorInfo>> Dict_EdgeName_SensroInfo = new Dictionary<string, Dictionary<string, SensorInfo>>();
        public static Views.Form_DataCharts Form_MainQueryChart = new Views.Form_DataCharts()
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
        };


       
        public struct QueryParam
        {
            public enum ShowDataChartMode
            {
                Single, Multi
            }
            public static ShowDataChartMode NowShowChartMode = ShowDataChartMode.Single;
            public static DateTime StartTime;
            public static DateTime EndTime;
            public static SensorDataProcess.SensorInfo NowQuerySensorInfo;

            public static Dictionary<string, Views.Form_DataCharts> Dict_SensorName_Chart = new Dictionary<string, Views.Form_DataCharts>();

        }


        public struct SystemParameters
        {
            public static string DataSaveRootPath = "";
            public static void LoadSystemParam()
            {
                Ini.IniFile SystemIniFile = new Ini.IniFile(System.IO.Path.Combine("Parameters", "SystemParameters.ini"));

                DataSaveRootPath = SystemIniFile.IniReadValue("Path", "RootPath");

            }
        }

    }
}
