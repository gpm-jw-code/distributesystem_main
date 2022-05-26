using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ISOInspection
{
    public class ISObase
    {
        private double ThresholdA;
        private double ThresholdB;
        private double ThresholdC;

        private static string ISOFilePath = Path.Combine("Resources","ISOStandard.json");

        private static Dictionary<Enum_ISOInspectionNumber, Dictionary<int, double[]>> Dict_AllISOThreshold ;

        public ResultLevel CalculateResult(double VelocityRMS)
        {
            if (VelocityRMS<ThresholdA)
            {
                return ResultLevel.A;
            }
            if (VelocityRMS<ThresholdB)
            {
                return ResultLevel.B;
            }
            if (VelocityRMS<ThresholdC)
            {
                return ResultLevel.C;
            }
            return ResultLevel.D;
        }

        public void LoadGroupThreshold(Enum_ISOInspectionNumber ISOName, int GroupNumber)
        {
            if (Dict_AllISOThreshold == null)
            {
                LoadAllThresholdDictionary(ISOFilePath);
            }
            ThresholdA = Dict_AllISOThreshold[ISOName][GroupNumber][0];
            ThresholdB = Dict_AllISOThreshold[ISOName][GroupNumber][1];
            ThresholdC = Dict_AllISOThreshold[ISOName][GroupNumber][2];
        }

        public static void LoadAllThresholdDictionary(string FilePath)
        {
            using (StreamReader SR = new StreamReader(FilePath))
            {
                string DataString = SR.ReadLine();
                Dict_AllISOThreshold = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<Enum_ISOInspectionNumber, Dictionary<int, double[]>>>(DataString);
            }
            
        }
    }


}
