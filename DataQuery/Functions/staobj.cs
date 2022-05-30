using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataQuery.Functions
{
    public class staobj
    {
        

        public static Dictionary<string, Dictionary<string, SensorInfo>> Dict_EdgeName_SensroInfo = new Dictionary<string, Dictionary<string, SensorInfo>>();
        //public static Dictionary<string, Dictionary<string, Dictionary<string, double>>> Dict_EdgeName_SensorName_Threshold = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();
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

        public struct SensorParam
        {
            public static string SensorDataRootPath(string SensorName)
            {
                string[] Edge_SensorArray = SensorName.Split('-');
                string SensorInfoDirectory = Path.Combine("Parameters", "SensorInfos", Edge_SensorArray[0], Edge_SensorArray[1]);
                if (!Directory.Exists(SensorInfoDirectory))
                {
                    Directory.CreateDirectory(SensorInfoDirectory);
                }
                return SensorInfoDirectory;
            }
            public static Dictionary<string, double> LoadThreasholdFromFile(string SensorName)
            {
                Dictionary<string, double> OutputData = new Dictionary<string, double>();
                string ThresholdFileName = Path.Combine(SensorDataRootPath(SensorName), "Threshold.json");
                if (!File.Exists(ThresholdFileName))
                {
                    return new Dictionary<string, double>();
                }
                using (StreamReader SR = new StreamReader(ThresholdFileName))
                {
                    OutputData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, double>>(SR.ReadToEnd());
                }
                return OutputData;
            }
        }

    }
}
