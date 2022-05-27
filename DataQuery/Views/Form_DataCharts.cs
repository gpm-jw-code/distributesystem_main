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
        RectangleAnnotation TimeLogAnnotation ;

        public void ImportSensorInfo(SensorDataProcess.SensorInfo SensorInfo)
        {
            this.Text = $"{SensorInfo.EdgeName}-{SensorInfo.EQName}-{SensorInfo.UnitName}-{SensorInfo.SensorNameWithOutEdgeName}";
            LAB_SensorName.Text = $"{SensorInfo.EdgeName}-{SensorInfo.EQName}-{SensorInfo.UnitName}-{SensorInfo.SensorNameWithOutEdgeName}";
        }

        public void ImportSensorDataSeries(List<DateTime> TimeLogSeries, Dictionary<string, List<double>> Dict_DataSeries)
        {
            int IntForColor = 0;
            TimeLogAnnotation.Visible = false;
            foreach (var item in Dict_SensorSeries)
            {
                item.Value.Enabled = false;
                Dict_SensorAnnotation[item.Key].Visible = false;
            }
            foreach (var item in Dict_DataSeries)
            {
                IntForColor += 1;
                if (!Dict_SensorSeries.ContainsKey(item.Key))
                {
                    Color NewSeriesColor = ColorFromHSV(360 * IntForColor / Dict_DataSeries.Count, 1, 1);
                    Color StripLineColor = ColorFromHSV(360 * IntForColor / Dict_DataSeries.Count, 1, 0.5);
                    CreateNewSensorUIObjects(item.Key, NewSeriesColor, StripLineColor);
                }
                if (!Dict_SensorSeries[item.Key].Enabled)
                {
                    Dict_SensorSeries[item.Key].Enabled = true;
                }
                Dict_SensorSeries[item.Key].Points.DataBindXY(TimeLogSeries, item.Value);
            }
        }
        private void CreateNewSensorUIObjects(string DataName, Color SeriesColor, Color StripLineColor)
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

        private void Form_DataCharts_MouseDown(object sender, MouseEventArgs e)
        {
            Event_FormClicked?.Invoke(SensorInfo.SensorName);
        }

        private void ChartForShow_MouseClick(object sender, MouseEventArgs e)
        {
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
                Dict_SensorAnnotation[item].Text = Convert.ToDouble( Dict_SensorSeries[item].Points[Min_Index].YValues[0].ToString("F5")).ToString();
                Dict_SensorAnnotation[item].AnchorDataPoint = Dict_SensorSeries[item].Points[Min_Index];
            }
        }
    }
}
