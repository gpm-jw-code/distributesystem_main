using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataQuery.Functions
{
    public class cls_SensorParametersProcess
    {
        static string SensorRootDirectory = System.IO.Path.Combine("Parameters", "SensorInfos");

        public static void LoadAllSensorInfos()
        {
            string[] EdgeDirectorys = System.IO.Directory.GetDirectories(SensorRootDirectory);
            for (int i = 0; i < EdgeDirectorys.Length; i++)
            {
                string EdgeName = EdgeDirectorys[i].Split('\\').Last();
                staobj.Dict_EdgeName_SensroInfo.Add(EdgeName, new Dictionary<string, SensorDataProcess.SensorInfo>());
                string[] SensorDirectorys = Directory.GetDirectories(EdgeDirectorys[i]);
                for (int j = 0; j < SensorDirectorys.Length; j++)
                {
                    string FileName = Path.Combine(SensorDirectorys[j], "SensorInfo.json");
                    using (FileStream FS = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader SR = new StreamReader(FS))
                        {
                            string SensorName = SensorDirectorys[j].Split('\\').Last();
                            var SensorInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<SensorDataProcess.SensorInfo>(SR.ReadToEnd());
                            staobj.Dict_EdgeName_SensroInfo[EdgeName].Add(SensorInfo.SensorName,SensorInfo);
                        }
                    }
                }
            }
        }
    }
}
