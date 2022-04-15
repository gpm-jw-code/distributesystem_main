

using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataQuery.Functions
{
    public class cls_txtQuery
    {
        private static string RawDataDirectoryPath(SensorInfo SensorInfo)
        {
            return Path.Combine(staobj.SystemParameters.DataSaveRootPath, "RawData", SensorInfo.EdgeName, SensorInfo.SensorNameWithOutEdgeName);
        }

        private static  string LogDirectoryPath(SensorInfo SensorInfo)
        {
            return Path.Combine(staobj.SystemParameters.DataSaveRootPath, "Log", SensorInfo.EdgeName, SensorInfo.SensorName);
        }

        private static string HourlyRawDataDirectoryPath(SensorInfo SensorInfo)
        {
            return Path.Combine(staobj.SystemParameters.DataSaveRootPath, "HourlyRawData", SensorInfo.EdgeName, SensorInfo.SensorNameWithOutEdgeName);
        }

        public static cls_RawDataObject QueryIntervalRawData(DateTime StartTime,DateTime EndTime,SensorInfo SensorInfo)
        {
            cls_RawDataObject OutputData = new cls_RawDataObject();
            if ((EndTime-StartTime).TotalDays>7) //讀HourlyRawData
            {
                List<string> IntervalFileNames = GetIntervalFileNames(HourlyRawDataDirectoryPath(SensorInfo), StartTime, EndTime, new List<string>() { "yyyyMMdd" });
                OutputData= QueryRawData(StartTime, EndTime, IntervalFileNames);
            }
            else //讀原始RawData
            {
                List<string> IntervalFileNames = GetIntervalFileNames(RawDataDirectoryPath(SensorInfo), StartTime, EndTime, new List<string>() { "yyyyMMdd_HH" });
                OutputData = QueryRawData(StartTime, EndTime, IntervalFileNames);
            }

            return OutputData;
        }


        private static cls_RawDataObject QueryRawData(DateTime StartTime,DateTime EndTime,List<string> IntervalFileNames)
        {
            cls_RawDataObject OutputData = new cls_RawDataObject();
            bool AlreadyReadHeader = false;
            foreach (var EachFileName in IntervalFileNames)
            {
                using (FileStream FS = new FileStream(EachFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        int ReadRowNumber = -1;
                        while (!SR.EndOfStream)
                        {
                            string DataString = SR.ReadLine();
                            ReadRowNumber += 1;
                            if (ReadRowNumber < 2)  //第一行是Sensor資訊 , 第二行空白
                                continue;
                            if (ReadRowNumber == 2)
                            {
                                if (!AlreadyReadHeader)
                                {
                                    if (!OutputData.ImportDataHeader(DataString))  //表示檔案格式有問題 直接不讀
                                    {
                                        break;
                                    }
                                    AlreadyReadHeader = true;
                                }
                                continue;
                            }
                            OutputData.ImportNewDataString(DataString);
                        }
                    }
                }
            }
            return OutputData;
        }

        internal static List<string> GetIntervalFileNames(string InputPath, DateTime StartTime, DateTime EndTime, List<string> NameFormat, List<string> ExtensionNames = null)
        {
            try
            {
                List<string> OutputFileNameList = new List<string>();
                if (!Directory.Exists(InputPath))
                {
                    return new List<string>();
                }
                List<string> OutputFileNamesWithoutExtension = new List<string>();
                string[] AllFileNames = Directory.GetFiles(InputPath);
                string FileNameWithoutExtension;
                DateTime FileNameToDateTime = new DateTime();
                string PreviousFileName = null;
                for (int i = 0; i < AllFileNames.Length; i++)
                {
                    if (ExtensionNames != null)
                    {
                        bool ExtensionNotMeet = false;
                        foreach (string Extension in ExtensionNames)
                            if (Path.GetExtension(AllFileNames[i]) == Extension)
                                ExtensionNotMeet = true;

                        if (!ExtensionNotMeet)
                            continue;
                    }
                    FileNameWithoutExtension = Path.GetFileNameWithoutExtension(AllFileNames[i]);
                    bool ParseSuccess = false;
                    foreach (string EachFormat in NameFormat)
                    {
                        try
                        {
                            FileNameToDateTime = DateTime.ParseExact(FileNameWithoutExtension, EachFormat, CultureInfo.CurrentCulture);
                            ParseSuccess = true;
                            break;
                        }
                        catch (Exception)
                        {
                            ParseSuccess = false;
                        }
                    }
                    if (!ParseSuccess)
                    {
                        continue;
                    }
                    if (FileNameToDateTime < StartTime)
                    {
                        PreviousFileName = AllFileNames[i];
                        continue;
                    }
                    else if (FileNameToDateTime > EndTime)
                        break;
                    if (OutputFileNamesWithoutExtension.Contains(FileNameWithoutExtension))
                        continue;
                    OutputFileNameList.Add(AllFileNames[i]);
                    OutputFileNamesWithoutExtension.Add(FileNameWithoutExtension);

                }
                if (!string.IsNullOrEmpty(PreviousFileName) && !OutputFileNamesWithoutExtension.Contains(Path.GetFileNameWithoutExtension(PreviousFileName)))
                {
                    OutputFileNameList.Insert(0, PreviousFileName);
                }
                return OutputFileNameList;
            }
            catch (Exception exp)
            {
                return new List<string>();
            }
        }
    }

    public class cls_RawDataObject
    {
        public Dictionary<string, List<double>> Dict_DataSeries = new Dictionary<string, List<double>>();
        public List<DateTime> List_TimeLog = new List<DateTime>();
        private List<string> List_HeaderName = new List<string>();

        public Dictionary<string, List<double>> Dict_DownSampleData = new Dictionary<string, List<double>>();
        public List<DateTime> List_DownSampleTimeLog = new List<DateTime>();

        public bool ImportDataHeader(string Header)
        {
            string[] HeaderArray = Header.Split(',');
            List_HeaderName = HeaderArray.ToList();
            if (HeaderArray[0].Trim().ToUpper() != "Time".ToUpper())
            {
                return false;
            }
            else
            {
                Dict_DataSeries = new Dictionary<string, List<double>>();
                for (int i = 1; i < HeaderArray.Length; i++)
                {
                    Dict_DataSeries.Add(HeaderArray[i], new List<double>());
                }
                return true;
            }
        }

        public void ImportNewDataString(string DataString)
        {
            string[] DataArray = DataString.Split(',');
            List_TimeLog.Add(DateTime.ParseExact(DataArray[0], "yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture));
            for (int i = 1; i < DataArray.Length; i++)
            {
                Dict_DataSeries[List_HeaderName[i]].Add(Convert.ToDouble(DataArray[i]));
            }
        }

        public void Downsampling(int OutputPointNumber)
        {
            int OriginDataNumber = List_TimeLog.Count;
            double Double_SampleRate = OriginDataNumber / (OutputPointNumber*1.5) +1;
            int SampleRate = (int)Math.Floor(Double_SampleRate);

            Dict_DownSampleData = new Dictionary<string, List<double>>();
            List_DownSampleTimeLog = new List<DateTime>();
            for (int i = 0; i < OriginDataNumber; i+=SampleRate)
            {
                foreach (var item in Dict_DataSeries)
                {
                    if (!Dict_DownSampleData.ContainsKey(item.Key))
                    {
                        Dict_DownSampleData.Add(item.Key, new List<double>());
                    }
                    Dict_DownSampleData[item.Key].Add(item.Value[i]);
                }
                List_DownSampleTimeLog.Add(List_TimeLog[i]);
            }

        }
    }
}
