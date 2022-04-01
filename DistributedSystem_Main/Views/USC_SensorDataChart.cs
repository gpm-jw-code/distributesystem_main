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
        }

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

        public void ImportSensorDataSeries(IEnumerable<DateTime> TimeLogSeries ,Dictionary<string,IEnumerable<double>> Dict_DataSeries)
        {
            foreach (var item in Dict_DataSeries)
            {
                if (!Dict_SensorSeries.ContainsKey(item.Key))
                {
                    CreateNewSensorUIObjects(item.Key);
                }
                Dict_SensorSeries[item.Key].Points.DataBindXY(TimeLogSeries, item.Value);
            }
            LastUpdateTime = DateTime.Now;
        }

        public void SetSensorThreshold(Dictionary<string,double> Dict_Threshold)
        {
            foreach (var item in Dict_Threshold)
            {
                if (!Dict_SensorStripLines.ContainsKey(item.Key))
                {
                    CreateNewSensorUIObjects(item.Key);
                }
                Dict_SensorStripLines[item.Key].IntervalOffset = item.Value;
            }
        }

        

        private void CreateNewSensorUIObjects(string DataName)
        {
            Series NewDataSeries = new Series
            {
                ChartArea = "ChartArea1",
                ChartType = SeriesChartType.Line,
                Legend = "Legend1",
                Name = "PM_0.3",
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double
            };
            Dict_SensorSeries.Add(DataName, NewDataSeries);

            var SeriesColor = NewDataSeries.Color;
            var StripLineColor = Color.FromArgb((int)(SeriesColor.R * 0.75), (int)(SeriesColor.G * 0.75), (int)(SeriesColor.B * 0.75));

            StripLine NewStripLine = new StripLine
            {
                BorderColor = StripLineColor,
                BorderDashStyle = ChartDashStyle.Dash
            };
            Dict_SensorStripLines.Add(DataName, NewStripLine);
        }


    }
}
