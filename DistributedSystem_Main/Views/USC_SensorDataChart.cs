using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DistributedSystem_Main.Views
{
    public partial class USC_SensorDataChart : UserControl
    {
        public USC_SensorDataChart()
        {
            InitializeComponent();
            ChartForShow.Series.Clear();
        }

        public static Action<string> Event_SettingButtonClicked;

        private string _SensorName = "";
        private string _EQName = "";
        private string _UnitName = "";
        
        public string SensorName
        {
            set { this._SensorName = value; this.LAB_SensorName.Text = value; }
        }

        public string EQName
        {
            set { this._EQName = value;this.labEqName.Text = value; }
        }

        public string UnitName
        {
            set { this._UnitName = value;this.labUnitName.Text = value; }
        }

        public DateTime LastUpdateTime
        {
            set { LAB_LastUpdateTime.Text = value.ToString("yyyy/MM/dd HH:mm:ss"); }
        }

        private Dictionary<string, Series> Dict_SensorSeries = new Dictionary<string, Series>();
        private Dictionary<string, StripLine> Dict_SensorStripLines = new Dictionary<string, StripLine>();

        public void ImportSensorDataSeries(Queue<DateTime> TimeLogSeries ,Dictionary<string,Queue<double>> Dict_DataSeries)
        {
            int IntForColor = 0;
            foreach (var item in Dict_DataSeries)
            {
                IntForColor += 1;
                if (!Dict_SensorSeries.ContainsKey(item.Key))
                {
                    Color NewSeriesColor = ColorFromHSV(360*IntForColor / Dict_DataSeries.Count, 1, 1);
                    Color StripLineColor = ColorFromHSV(360 * IntForColor / Dict_DataSeries.Count, 1, 0.5);
                    CreateNewSensorUIObjects(item.Key, NewSeriesColor, StripLineColor);
                }
                Dict_SensorSeries[item.Key].Points.DataBindXY(TimeLogSeries, item.Value);
            }
            LastUpdateTime = DateTime.Now;
        }

        public void SetSensorThreshold(Dictionary<string,double> Dict_Threshold)
        {
            int IntForColor = 0;
            foreach (var item in Dict_Threshold)
            {
                IntForColor += 1;
                if (!Dict_SensorStripLines.ContainsKey(item.Key))
                {
                    Color NewSeriesColor = ColorFromHSV(360 * IntForColor / Dict_Threshold.Count, 1, 1);
                    Color StripLineColor = ColorFromHSV(360 * IntForColor / Dict_Threshold.Count, 1, 0.5);
                    CreateNewSensorUIObjects(item.Key,NewSeriesColor, StripLineColor);
                }
                Dict_SensorStripLines[item.Key].IntervalOffset = item.Value;
            }
        }

        

        private void CreateNewSensorUIObjects(string DataName,Color SeriesColor,Color StripLineColor )
        {
            Series NewDataSeries = new Series
            {
                ChartArea = "ChartArea1",
                ChartType = SeriesChartType.Line,
                Legend = "Legend1",
                Name = DataName,
                Color = SeriesColor,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double
            };
            Dict_SensorSeries.Add(DataName, NewDataSeries);

            ChartForShow.Series.Add(NewDataSeries);

            StripLine NewStripLine = new StripLine
            {
                BorderColor = StripLineColor,
                BorderDashStyle = ChartDashStyle.Dash
            };
            Dict_SensorStripLines.Add(DataName, NewStripLine);

            ChartForShow.ChartAreas[0].AxisY.StripLines.Add(NewStripLine);
        }

        private void picSettingIcon_Click(object sender, EventArgs e)
        {
            Event_SettingButtonClicked?.Invoke(_SensorName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hue">0~360</param>
        /// <param name="saturation">0~1</param>
        /// <param name="value">0~1</param>
        /// <returns></returns>
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
    }
}
