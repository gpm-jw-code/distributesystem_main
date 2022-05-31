﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataQuery.Views
{
    public partial class Form_DataCharts : Form
    {
        public SensorDataProcess.SensorInfo SensorInfo;
        public Action<string> Event_FormClicked;

        /// <summary>
        /// Multi Mode專用
        /// </summary>
        /// <param name="NewSensorInfo"></param>
        public Form_DataCharts(SensorDataProcess.SensorInfo NewSensorInfo)
        {
            InitializeComponent();
            ImportSensorInfo(NewSensorInfo);
            ChartForShow.Series.Clear();
            this.FormClosed += CloseMultiModeQueryChart;
            this.SensorInfo = NewSensorInfo;
            TimeLogAnnotation = new RectangleAnnotation()
            {
                BackColor = Color.Black,
                LineColor = Color.Aqua,
                LineWidth = 2,
                ForeColor = Color.White,
                Visible = true
            };
            ChartForShow.Annotations.Add(TimeLogAnnotation);
        }

        private void CloseMultiModeQueryChart(object sender, FormClosedEventArgs e)
        {
            Functions.staobj.QueryParam.Dict_SensorName_Chart.Remove(SensorInfo.SensorName);
        }

        /// <summary>
        /// Single Mode專用
        /// </summary>
        public Form_DataCharts()
        {
            InitializeComponent();
            ChartForShow.Series.Clear();
            this.FormClosing += CancelClosingEvent;
            TimeLogAnnotation = new RectangleAnnotation()
            {
                BackColor = Color.Black,
                LineColor = Color.Aqua,
                LineWidth = 2,
                ForeColor = Color.White,
                Visible = true
            };
            ChartForShow.Annotations.Add(TimeLogAnnotation);
        }

        private void CancelClosingEvent(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        Dictionary<string, Series> Dict_SensorSeries = new Dictionary<string, Series>();
        Dictionary<string, RectangleAnnotation> Dict_SensorAnnotation = new Dictionary<string, RectangleAnnotation>();
        RectangleAnnotation TimeLogAnnotation;

        public void ImportSensorInfo(SensorDataProcess.SensorInfo SensorInfo)
        {
            this.SensorInfo = SensorInfo;
            this.Text = $"{SensorInfo.EdgeName}-{SensorInfo.EQName}-{SensorInfo.UnitName}-{SensorInfo.SensorNameWithOutEdgeName}";
            LAB_SensorName.Text = $"{SensorInfo.EdgeName}-{SensorInfo.EQName}-{SensorInfo.UnitName}-{SensorInfo.SensorNameWithOutEdgeName}";
            Panel_DataType.Visible = !string.IsNullOrEmpty(SensorInfo.ISOCheckDataName);
        }

        public void ImportSensorDataSeries(List<DateTime> TimeLogSeries, Dictionary<string, List<double>> Dict_DataSeries)
        {
            int IntForColor = 0;
            TimeLogAnnotation.Visible = false;
            this.Dict_SensorSeries.Clear();
            Dict_SensorAnnotation.Clear();
            ChartForShow.Series.Clear();
            ChartForShow.Annotations.Clear();
            rawDataToolStripMenuItem.DropDownItems.Clear();
            thresholdToolStripMenuItem.DropDownItems.Clear();
            AddNewSeriesToolItem("All");
            AddNewThresholdToolItem("All");
            foreach (var item in Dict_DataSeries)
            {
                IntForColor += 1;
                Color NewSeriesColor = ColorFromHSV(360 * IntForColor / Dict_DataSeries.Count, 1, 1);
                Color StripLineColor = ColorFromHSV(360 * IntForColor / Dict_DataSeries.Count, 1, 0.5);
                CreateNewSensorUIObjects(item.Key, NewSeriesColor);
                Dict_SensorSeries[item.Key].Points.DataBindXY(TimeLogSeries, item.Value);
            }
        }
        Dictionary<string,StripLine> Dict_ThresholdStripLine = new Dictionary<string, StripLine>();
        public void ImportThreshold(Dictionary<string, double> Dict_Threshold)
        {
            ChartForShow.ChartAreas[0].AxisY.StripLines.Clear();
            Dict_ThresholdStripLine.Clear();
            foreach (var item in Dict_Threshold)
            {
                string DataName = item.Key.Replace("_OOC", "").Replace("_OOS", "");
                AddNewThresholdToolItem(DataName);
                if (item.Key.ToUpper().Contains("_OOS"))
                {
                    StripLine NewStripLine = new StripLine
                    {
                        BorderColor = Color.Red,
                        BorderDashStyle = ChartDashStyle.Dash,
                        BorderWidth = 2,
                        Text = item.Key,
                        ForeColor = Color.White,
                        IntervalOffset = item.Value
                    };

                    ChartForShow.ChartAreas[0].AxisY.StripLines.Add(NewStripLine);
                    Dict_ThresholdStripLine.Add(item.Key,NewStripLine);
                    continue;
                }
                if (item.Key.ToUpper().Contains("_OOC"))
                {
                    StripLine NewStripLine = new StripLine
                    {
                        BorderColor = Color.Yellow,
                        BorderDashStyle = ChartDashStyle.Dash,
                        BorderWidth = 2,
                        Text = item.Key,
                        ForeColor = Color.White,
                        IntervalOffset = item.Value
                    };

                    ChartForShow.ChartAreas[0].AxisY.StripLines.Add(NewStripLine);
                    Dict_ThresholdStripLine.Add(item.Key, NewStripLine);
                    continue;
                }
            }
        }
        private void CreateNewSensorUIObjects(string DataName, Color SeriesColor)
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
            RectangleAnnotation NewSeriesAnnotation = new RectangleAnnotation() { BackColor = Color.Black, LineColor = SeriesColor, LineWidth = 2, ForeColor = Color.White, Visible = true };
            ChartForShow.Annotations.Add(NewSeriesAnnotation);

            Dict_SensorSeries.Add(DataName, NewDataSeries);
            Dict_SensorAnnotation.Add(DataName, NewSeriesAnnotation);

            ChartForShow.Series.Add(NewDataSeries);
            AddNewSeriesToolItem(DataName);
        }

        private void AddNewSeriesToolItem(string DataName)
        {
            var NewItem = rawDataToolStripMenuItem.DropDownItems.Add(DataName) as ToolStripMenuItem;
            NewItem.Name = $"Series_{DataName}";
            NewItem.Checked = NewItem.CheckOnClick = true;
            NewItem.Click += ContextMenuStrip_ShowSeries_ClickEvent;
        }

        private void ContextMenuStrip_ShowSeries_ClickEvent(object sender, EventArgs e)
        {
            ToolStripMenuItem TargetItem = sender as ToolStripMenuItem;
            string DataName = TargetItem.Name.Replace("Series_", "");
            if (DataName == "All")
            {
                foreach (var item in Dict_SensorSeries)
                {
                    item.Value.Enabled = TargetItem.Checked;
                }
            }
            else
            {
                Dict_SensorSeries[DataName].Enabled = TargetItem.Checked;
            }
        }

        private void AddNewThresholdToolItem(string DataName)
        {
            if (thresholdToolStripMenuItem.DropDownItems.ContainsKey($"Threshold_{DataName}"))
            {
                return;
            }
            var NewThreshold = thresholdToolStripMenuItem.DropDownItems.Add(DataName) as ToolStripMenuItem;
            NewThreshold.Name = $"Threshold_{DataName}";
            NewThreshold.Checked = NewThreshold.CheckOnClick = true;
            NewThreshold.Click += ContextMenuStrip_ShowThreshold_ClickEvent;
        }

        private void ContextMenuStrip_ShowThreshold_ClickEvent(object sender, EventArgs e)
        {
            ToolStripMenuItem Targetitem = sender as ToolStripMenuItem;
            string DataName = Targetitem.Name.Replace("Threshold_", "");
            if (DataName == "All")
            {
                foreach (var item in Dict_ThresholdStripLine)
                {
                    item.Value.Text = Targetitem.Checked?item.Key:"";
                    item.Value.BorderWidth = Targetitem.Checked ? 2 : 0;
                }
            }
            else
            {
                if (Targetitem.Checked)
                {
                    Dict_ThresholdStripLine[$"{DataName}_OOS"].Text = $"{DataName}_OOS";
                    Dict_ThresholdStripLine[$"{DataName}_OOC"].Text = $"{DataName}_OOC";
                    Dict_ThresholdStripLine[$"{DataName}_OOS"].BorderWidth = Dict_ThresholdStripLine[$"{DataName}_OOC"].BorderWidth = 2;
                }
                else
                {
                    Dict_ThresholdStripLine[$"{DataName}_OOS"].Text = "";
                    Dict_ThresholdStripLine[$"{DataName}_OOC"].Text = "";
                    Dict_ThresholdStripLine[$"{DataName}_OOS"].BorderWidth = Dict_ThresholdStripLine[$"{DataName}_OOC"].BorderWidth = 0;
                }
                
            }
        }

        /// <summary>
        /// HSV
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

        private void Form_DataCharts_MouseDown(object sender, MouseEventArgs e)
        {
            Event_FormClicked?.Invoke(SensorInfo.SensorName);
        }

        private void ChartForShow_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            var Position_X = ChartForShow.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            DateTime ClickedTime = DateTime.FromOADate(Position_X);
            TimeLogAnnotation.Text = ClickedTime.ToString("yyyy/MM/dd HH:mm:ss");

            var EnableSeries = ChartForShow.Series.Where(item => item.Enabled == true).ToList();
            var List_SeriesName = Dict_SensorSeries.Where(item => item.Value.Enabled == true).Select(item => item.Key).ToList();

            var DistanceArray = EnableSeries[0].Points.Select(point => Math.Abs(point.XValue - Position_X)).ToList();
            int Min_Index = DistanceArray.IndexOf(DistanceArray.Min());

            TimeLogAnnotation.AnchorDataPoint = Dict_SensorSeries[List_SeriesName[0]].Points[Min_Index];
            TimeLogAnnotation.AnchorY = 0;
            TimeLogAnnotation.Visible = true;
            foreach (var item in List_SeriesName)
            {
                Dict_SensorAnnotation[item].Visible = true;
                Dict_SensorAnnotation[item].Text = Convert.ToDouble(Dict_SensorSeries[item].Points[Min_Index].YValues[0].ToString("F5")).ToString();
                Dict_SensorAnnotation[item].AnchorDataPoint = Dict_SensorSeries[item].Points[Min_Index];
            }
        }

        private void LAB_ShowRawData_Click(object sender, EventArgs e)
        {
            ChartForShow.ChartAreas[0].AxisY.StripLines.Clear();
            foreach (var item in Dict_ThresholdStripLine)
            {
                ChartForShow.ChartAreas[0].AxisY.StripLines.Add(item.Value);
            }
            foreach (var item in Dict_SensorSeries)
            {
                item.Value.Enabled = true;
            }
        }

        #region ISO UI Object

        private void LAB_ShowISO_Click(object sender, EventArgs e)
        {
            var ISOThreshold = Functions.staobj.SensorParam.LoadISOParameters(SensorInfo.SensorName, SensorInfo.ISONumber);
            if (ISOThreshold == null)
            {
                return;
            }

            foreach (var item in Dict_SensorSeries)
            {
                item.Value.Enabled = SensorInfo.ISOCheckDataName == item.Key;
                Dict_SensorAnnotation[item.Key].Visible =SensorInfo.ISOCheckDataName == item.Key;
            }
            ChartForShow.ChartAreas[0].AxisY.StripLines.Clear();
            if (List_ISOStripLine.Count == 0)
            {
                InitialBackColorStripLine();
            }
            else
            {
                foreach (var item in List_ISOStripLine)
                {
                    ChartForShow.ChartAreas[0].AxisY.StripLines.Add(item);
                }
            }
            SetBackColorThreshold(ISOThreshold.ThresholdA, ISOThreshold.ThresholdB, ISOThreshold.ThresholdC);

        }
        List<Color> List_Color = new List<Color> { Color.Green, Color.Yellow, Color.Orange, Color.Red };
        private List<StripLine> List_ISOStripLine = new List<StripLine>();

        private void InitialBackColorStripLine()
        {
            for (int i = 0; i < 4; i++)
            {
                StripLine NewStripLine = new StripLine()
                {
                    BackColor = Color.FromArgb(50, List_Color[i]),
                    BorderWidth = 0,
                    Interval = 0
                };
                ChartForShow.ChartAreas[0].AxisY.StripLines.Add(NewStripLine);
                List_ISOStripLine.Add(NewStripLine);
            }
        }

        public void SetBackColorThreshold(double ThresholdA, double ThresholdB, double ThresholdC)
        {
            List_ISOStripLine[0].StripWidth = ThresholdA;
            List_ISOStripLine[0].IntervalOffset = 0;

            List_ISOStripLine[1].StripWidth = ThresholdB - ThresholdA;
            List_ISOStripLine[1].IntervalOffset = ThresholdA;

            List_ISOStripLine[2].StripWidth = ThresholdC - ThresholdB;
            List_ISOStripLine[2].IntervalOffset = ThresholdB;

            List_ISOStripLine[3].StripWidth = 100;
            List_ISOStripLine[3].IntervalOffset = ThresholdC;
        }
        #endregion
    }
}
