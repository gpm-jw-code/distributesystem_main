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

        public string DataUnit
        {
            set
            {
                ChartForShow.ChartAreas[0].AxisY.Title = value;
            }
        }

        public string SensorType
        {
            get
            {
                return _SensorType;
            }
            set
            {
                //if (value != _SensorType)
                //{
                    foreach (var item in Dict_SensorSeries)
                    {
                        item.Value.Enabled = false;
                    }
                    foreach (var item in Dict_SensorOOC_StripLines)
                    {
                        item.Value.Text = "";
                        item.Value.BorderWidth = 0;
                    }
                    foreach (var item in Dict_SensorOOS_StripLines)
                    {
                        item.Value.Text = "";
                        item.Value.BorderWidth = 0;
                    }
                //}
                _SensorType = value;
            }
        }

        public DateTime LastUpdateTime
        {
            set { LAB_LastUpdateTime.Text = value.ToString("yyyy/MM/dd HH:mm:ss"); }
        }

        private Dictionary<string, Series> Dict_SensorSeries = new Dictionary<string, Series>();
        private Dictionary<string, StripLine> Dict_SensorOOC_StripLines = new Dictionary<string, StripLine>();
        private Dictionary<string, StripLine> Dict_SensorOOS_StripLines = new Dictionary<string, StripLine>();

        public void ImportSensorDataSeries(Queue<DateTime> TimeLogSeries, Dictionary<string, Queue<double>> Dict_DataSeries)
        {
            int IntForColor = 0;
            if (TimeLogSeries.Count == 0)
            {
                foreach (var item in Dict_SensorSeries)
                {
                    item.Value.Points.Clear();
                }
                return;
            }
            foreach (var item in Dict_DataSeries)
            {
                IntForColor += 1;
                if (!Dict_SensorSeries.ContainsKey(item.Key))
                {
                    Color NewSeriesColor = cls_Functions.ColorFromHSV(360 * IntForColor / Dict_DataSeries.Count, 1, 1);
                    Color StripLineColor = cls_Functions.ColorFromHSV(360 * IntForColor / Dict_DataSeries.Count, 1, 0.5);
                    CreateNewSensorUIObjects(item.Key, NewSeriesColor, StripLineColor);
                }
                Dict_SensorSeries[item.Key].Points.DataBindXY(TimeLogSeries, item.Value);
            }
            LastUpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 匯入Threshold，所有Series StripLine MenuStripItem 顯示狀態都回預設
        /// </summary>
        /// <param name="Dict_Threshold"></param>
        public void SetSensorThreshold(Dictionary<string, double> Dict_Threshold)
        {
            dataSeriesToolStripMenuItem.DropDownItems.Clear();
            thresholdLineToolStripMenuItem.DropDownItems.Clear();
            AddNewSeriesToolItem("All");
            AddNewThresholdToolItem("All");

            int IntForColor = 0;
            foreach (var item in Dict_Threshold)
            {
                string DataName = item.Key.Replace("_OOC", "");
                DataName = DataName.Replace("_OOS", "");
                IntForColor += 1;
                if (!dataSeriesToolStripMenuItem.DropDownItems.ContainsKey($"Series_{DataName}"))
                {
                    AddNewSeriesToolItem(DataName);
                    AddNewThresholdToolItem(DataName);
                }

                if (!Dict_SensorSeries.ContainsKey(DataName))
                {
                    Color NewSeriesColor = cls_Functions.ColorFromHSV(360 * IntForColor / (Dict_Threshold.Count/2), 1, 1);
                    Color StripLineColor = cls_Functions.ColorFromHSV(360 * IntForColor / (Dict_Threshold.Count/2), 1, 0.5);
                    CreateNewSensorUIObjects(DataName, NewSeriesColor, StripLineColor);
                }

                ///Series 跟 StripLine 都重新Show出來
                Dict_SensorSeries[DataName].Enabled = true;

                Dict_SensorOOC_StripLines[DataName].IntervalOffset = Dict_Threshold[DataName + "_OOC"];
                Dict_SensorOOS_StripLines[DataName].IntervalOffset = Dict_Threshold[DataName + "_OOS"];

                Dict_SensorOOC_StripLines[DataName].BorderWidth = Dict_SensorOOS_StripLines[DataName].BorderWidth = 1;
                Dict_SensorOOC_StripLines[DataName].Text = $"{DataName}_OOC";
                Dict_SensorOOS_StripLines[DataName].Text = $"{DataName}_OOS";
            }
        }

        private void AddNewSeriesToolItem(string DataName)
        {
            var NewItem = dataSeriesToolStripMenuItem.DropDownItems.Add(DataName) as ToolStripMenuItem;
            NewItem.Name = $"Series_{DataName}";
            NewItem.Checked = NewItem.CheckOnClick = true;
            NewItem.Click += ContextMenuStrip_ShowSeries_ClickEvent;
        }

        private void AddNewThresholdToolItem(string DataName)
        {
            var NewThreshold = thresholdLineToolStripMenuItem.DropDownItems.Add(DataName) as ToolStripMenuItem;
            NewThreshold.Name = $"Threshold_{DataName}";
            NewThreshold.Checked = NewThreshold.CheckOnClick = true;
            NewThreshold.Click += ContextMenuStrip_ShowThreshold_ClickEvent;
        }

        private void ContextMenuStrip_ShowThreshold_ClickEvent(object sender, EventArgs e)
        {
            ToolStripMenuItem TargetItem = sender as ToolStripMenuItem;
            string DataName = TargetItem.Name.Replace("Threshold_", "");

            if (DataName == "All")
            {
                foreach (var item in thresholdLineToolStripMenuItem.DropDownItems.Cast<ToolStripMenuItem>())
                {
                    string EachDataName = item.Name.Replace("Threshold_", "");
                    if (EachDataName == "All")
                    {
                        continue;
                    }
                    item.Checked = TargetItem.Checked;
                    if (TargetItem.Checked)
                    {
                        Dict_SensorOOC_StripLines[EachDataName].BorderWidth = Dict_SensorOOS_StripLines[EachDataName].BorderWidth = 1;
                        Dict_SensorOOC_StripLines[EachDataName].Text = $"{EachDataName}_OOC";
                        Dict_SensorOOS_StripLines[EachDataName].Text = $"{EachDataName}_OOS";
                    }
                    else
                    {
                        Dict_SensorOOC_StripLines[EachDataName].BorderWidth = Dict_SensorOOS_StripLines[EachDataName].BorderWidth = 0;
                        Dict_SensorOOC_StripLines[EachDataName].Text = "";
                        Dict_SensorOOS_StripLines[EachDataName].Text = "";
                    }
                }
            }
            else
            {
                if (TargetItem.Checked)
                {
                    Dict_SensorOOC_StripLines[DataName].BorderWidth = Dict_SensorOOS_StripLines[DataName].BorderWidth = 1;
                    Dict_SensorOOC_StripLines[DataName].Text = $"{DataName}_OOC";
                    Dict_SensorOOS_StripLines[DataName].Text = $"{DataName}_OOS";
                }
                else
                {
                    Dict_SensorOOC_StripLines[DataName].BorderWidth = Dict_SensorOOS_StripLines[DataName].BorderWidth = 0;
                    Dict_SensorOOC_StripLines[DataName].Text = "";
                    Dict_SensorOOS_StripLines[DataName].Text = "";
                }
            }

           
        }

        private void ContextMenuStrip_ShowSeries_ClickEvent(object sender, EventArgs e)
        {
            ToolStripMenuItem TargetItem = sender as ToolStripMenuItem;
            string DataName = TargetItem.Name.Replace("Series_", "");
            if (DataName == "All")
            {
                foreach (var item in dataSeriesToolStripMenuItem.DropDownItems.Cast<ToolStripMenuItem>())
                {
                    string EachDataName = item.Name.Replace("Series_", "");
                    if (EachDataName == "All")
                    {
                        continue;
                    }
                    item.Checked = TargetItem.Checked;
                    Dict_SensorSeries[EachDataName].Enabled = TargetItem.Checked;
                }
            }
            else
            {
                Dict_SensorSeries[DataName].Enabled = TargetItem.Checked;
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
            Dict_SensorSeries.Add(DataName, NewDataSeries);

            ChartForShow.Series.Add(NewDataSeries);

            StripLine NewStripLine = new StripLine
            {
                BorderColor = StripLineColor,
                BorderDashStyle = ChartDashStyle.Dash,
                Text = $"{DataName}_OOC",
                ForeColor = Color.White
            };
            Dict_SensorOOC_StripLines.Add(DataName, NewStripLine);

            StripLine NewOOSStripLine = new StripLine
            {
                BorderColor = StripLineColor,
                BorderDashStyle = ChartDashStyle.Dash,
                Text = $"{DataName}_OOS",
                ForeColor = Color.Yellow
            };
            Dict_SensorOOS_StripLines.Add(DataName, NewOOSStripLine);

            ChartForShow.ChartAreas[0].AxisY.StripLines.Add(NewStripLine);
            ChartForShow.ChartAreas[0].AxisY.StripLines.Add(NewOOSStripLine);
        }

        private void picSettingIcon_Click(object sender, EventArgs e)
        {
            Event_SettingButtonClicked?.Invoke(_SensorName);
        }

    }
}
