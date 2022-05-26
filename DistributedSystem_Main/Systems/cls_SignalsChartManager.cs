using SensorDataProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main.Systems
{
    public class cls_SignalsChartManager
    {
        public static TableLayoutPanel ParentControls = null;
        public static List<User_Control.USC_SensorDataChart> List_AllSignalsChart = new List<User_Control.USC_SensorDataChart>();
        public static User_Control.PageSwitch SignalPageSwitch = null;

        public static List<string> List_NowShowSensorNames = new List<string>();
        public static List<string> List_SelectedSensorNames = new List<string>();
        public static int TotalChartNumber = 6;

        private static string OriginFilterString = "";
        private static SortType OriginSortType = SortType.None;

        public static void InitialManager(TableLayoutPanel ParentControl, User_Control.PageSwitch PageSwitch)
        {
            ParentControls = ParentControl;
            SignalPageSwitch = PageSwitch;
        }

        public static void SetChartRowColumnNumber(int RowNumber, int ColumnNumber)
        {
            int OriginChartNumber = List_AllSignalsChart.Count;
            ParentControls.Controls.Clear();
            ParentControls.RowStyles.Clear();
            ParentControls.ColumnStyles.Clear();

            ParentControls.RowCount = RowNumber;
            ParentControls.ColumnCount = ColumnNumber;
            for (int i = 0; i < ColumnNumber; i++)
                ParentControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)1.0 / ColumnNumber));

            for (int i = 0; i < RowNumber; i++)
                ParentControls.RowStyles.Add(new RowStyle(SizeType.Percent, (float)1.0 / RowNumber));

            TotalChartNumber = RowNumber * ColumnNumber;
            if (OriginChartNumber < TotalChartNumber)
            {
                for (int i = 0; i < TotalChartNumber - OriginChartNumber; i++)
                {
                    List_AllSignalsChart.Add(new User_Control.USC_SensorDataChart() { Dock = System.Windows.Forms.DockStyle.Fill ,Visible = false});
                }
            }
            if (OriginChartNumber > TotalChartNumber)
            {
                List_AllSignalsChart.RemoveRange(TotalChartNumber, OriginChartNumber - TotalChartNumber);
            }
            foreach (var item in List_AllSignalsChart)
            {
                ParentControls.Controls.Add(item);
            }
            SignalPageSwitch.NowPageNumber = 1;
            FilterAndSortSensor();
        }

        public static void FilterAndSortSensor(string NewFilterString = null, SortType NewSortType = SortType.None)
        {
            OriginFilterString = NewFilterString ?? OriginFilterString;
            OriginSortType = NewSortType == SortType.None ? OriginSortType : NewSortType;

            var List_SensorInfo = Staobj.Dict_SensorProcessObject.Select(item => item.Value.SensorInfo);

            var List_FilterSensorInfos
                = List_SensorInfo.Where(item => item.SensorName.ToUpper().Contains(OriginFilterString.ToUpper())
                || item.IP.ToUpper().Contains(OriginFilterString.ToUpper())
                || item.EQName.ToUpper().Contains(OriginFilterString.ToUpper())
                || item.UnitName.ToUpper().Contains(OriginFilterString.ToUpper())).ToList();

            switch (NewSortType)
            {
                case SortType.IP:
                    List_SelectedSensorNames = List_FilterSensorInfos.OrderBy(item => item.IP).Select(item => item.SensorName).ToList();
                    break;
                case SortType.EQName:
                    List_SelectedSensorNames = List_FilterSensorInfos.OrderBy(item => item.IP).OrderBy(item => item.EQName).Select(item => item.SensorName).ToList();
                    break;
                default:
                    List_SelectedSensorNames = List_FilterSensorInfos.Select(item => item.SensorName).ToList();
                    break;
            }
            SignalPageSwitch.SetMaximumPageNumber((int)Math.Ceiling(List_SelectedSensorNames.Count / (double)TotalChartNumber));
            RefreshShowChart(SignalPageSwitch.NowPageNumber);
        }

        public static void RefreshShowChart(int PageNumber)
        {
            int StartNum = (PageNumber-1) * TotalChartNumber;
            int EndNum = Math.Min((PageNumber) * TotalChartNumber, List_SelectedSensorNames.Count);
            List_NowShowSensorNames.Clear();

            for (int i = 0; i < List_AllSignalsChart.Count; i++)
            {
                List_AllSignalsChart[i].Visible = i+StartNum < EndNum;
            }

            for (int i = StartNum; i < EndNum; i++)
            {
                string SensorName = List_SelectedSensorNames[i];
                List_NowShowSensorNames.Add(SensorName);
                UpdateSensorInfoToChart(SensorName);
                UpdateThresholdToChart(SensorName, Staobj.Dict_SensorProcessObject[SensorName].Dict_DataThreshold);
                Staobj.Dict_SensorProcessObject[SensorName].RefreshSignalChart();
            }
        }

        public static void UpdateSensorInfoToChart(string SensorName)
        {
            if (!List_NowShowSensorNames.Contains(SensorName))
                return;

            var SensorInfo = Staobj.Dict_SensorProcessObject[SensorName].SensorInfo;
            int ChartIndex = List_NowShowSensorNames.IndexOf(SensorName);
            var TargetChart = List_AllSignalsChart[ChartIndex];
            if (TargetChart.Visible == false)
            {
                TargetChart.Visible = true;
            }
            TargetChart.EQName = SensorInfo.EQName;
            TargetChart.UnitName = SensorInfo.UnitName;
            TargetChart.SensorName = SensorInfo.SensorName;
            TargetChart.DataUnit= SensorInfo.DataUnit;
            TargetChart.SensorType = SensorInfo.SensorType;
        }

        public static void UpdateThresholdToChart(string SensorName,Dictionary<string,double> DictThreshold)
        {
            if (!List_NowShowSensorNames.Contains(SensorName))
                return;
            int ChartIndex = List_NowShowSensorNames.IndexOf(SensorName);
            List_AllSignalsChart[ChartIndex].SetSensorThreshold(DictThreshold);
        }
        public static void UpdateSensorData(string SensorName, Queue<DateTime> Queue_Time, Dictionary<string, Queue<double>> Dict_DataQueue)
        {
            if (!List_NowShowSensorNames.Contains(SensorName))
                return;
            int ChartIndex = List_NowShowSensorNames.IndexOf(SensorName);
            if (List_AllSignalsChart[ChartIndex].Visible ==false)
            {
                List_AllSignalsChart[ChartIndex].Visible = true;
            }
            List_AllSignalsChart[ChartIndex].ImportSensorDataSeries(Queue_Time, Dict_DataQueue);
        }



        public enum SortType
        {
            IP, EQName, None
        }
    }
}
