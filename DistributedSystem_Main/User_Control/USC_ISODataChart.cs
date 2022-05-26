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

namespace DistributedSystem_Main.User_Control
{
    public partial class USC_ISODataChart : UserControl
    {
        public USC_ISODataChart()
        {
            InitializeComponent();
            InitialBackColorStripLine();
        }

        private string _SensorName = "";
        private string _EQName = "";
        private string _UnitName = "";
        private string _SensorType = "";

        public string SensorName
        {
            set { this._SensorName = value; this.LAB_SensorName.Text = value; }
        }

        public string EQName
        {
            set { this._EQName = value; this.labEqName.Text = value; }
        }

        public string UnitName
        {
            set { this._UnitName = value; this.labUnitName.Text = value; }
        }


        List<Color> List_Color = new List<Color> { Color.Green, Color.Yellow, Color.Orange, Color.Red };
        List<StripLine> List_StripLine = new List<StripLine>();

        private void InitialBackColorStripLine()
        {
            for (int i = 0; i < 4; i++)
            {
                StripLine NewStripLine = new StripLine()
                {
                    BackColor = Color.FromArgb(100, List_Color[i]),
                    BorderWidth = 0,
                    Interval = 0
                };
                ChartForShow.ChartAreas[0].AxisY.StripLines.Add(NewStripLine);
                List_StripLine.Add(NewStripLine);
            }
        }

        public void SetBackColorThreshold(double ThresholdA, double ThresholdB, double ThresholdC)
        {
            List_StripLine[0].StripWidth = ThresholdA;
            List_StripLine[0].IntervalOffset = 0;

            List_StripLine[1].StripWidth = ThresholdB-ThresholdA;
            List_StripLine[1].IntervalOffset = ThresholdA;

            List_StripLine[2].StripWidth = ThresholdC-ThresholdB;
            List_StripLine[2].IntervalOffset = ThresholdB;

            List_StripLine[3].StripWidth = 100;
            List_StripLine[3].IntervalOffset = ThresholdC;
        }

        public void ImportISODataSeries(Queue<DateTime> TimeLogSeries, Queue<double> DataSeries)
        {
            ChartForShow.Series[0].Points.DataBindXY(TimeLogSeries, DataSeries);
            LastUpdateTime = DateTime.Now;
        }

        public DateTime LastUpdateTime
        {
            set { LAB_LastUpdateTime.Text = value.ToString("yyyy/MM/dd HH:mm:ss"); }
        }
    }
}
