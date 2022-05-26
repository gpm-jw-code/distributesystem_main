using DataQuery.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataQuery
{
    public partial class Form_DataQuery : Form
    {
        public Form_DataQuery()
        {
            InitializeComponent();
            Functions.staobj.SystemParameters.LoadSystemParam();
            cls_SensorParametersProcess.LoadAllSensorInfos();
            RefreshSensorInfoToTreeView_SensorList();
            staobj.QueryParam.StartTime = DateTime.Now.AddDays(-1);
            staobj.QueryParam.EndTime = DateTime.Now;
        }

        #region TreeView (Sensor List)
        private void RefreshSensorInfoToTreeView_SensorList()
        {
            TreeView_SensorList.Nodes.Clear();

            foreach (var Dict_EdgeInfo in staobj.Dict_EdgeName_SensroInfo)
            {
                TreeView_SensorList.Nodes.Add(Dict_EdgeInfo.Key, Dict_EdgeInfo.Key);
                List<string> List_EQName = new List<string>();
                foreach (var EachSensorInfo in Dict_EdgeInfo.Value.Values)
                {
                    string EQNodeName = $"{Dict_EdgeInfo.Key}_{EachSensorInfo.EQName}";
                    if (!List_EQName.Contains(EachSensorInfo.EQName))
                    {
                        List_EQName.Add(EachSensorInfo.EQName);
                        TreeView_SensorList.Nodes[Dict_EdgeInfo.Key].Nodes.Add(EQNodeName,EachSensorInfo.EQName);
                    }
                    string SensorText = $"{EachSensorInfo.UnitName} || {EachSensorInfo.SensorNameWithOutEdgeName}";
                    TreeView_SensorList.Nodes[Dict_EdgeInfo.Key].Nodes[EQNodeName].Nodes.Add(EachSensorInfo.SensorName, SensorText);
                }
            }
        }

        private void TreeView_SensorList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var TargetNode = TreeView_SensorList.SelectedNode;
            if (TargetNode.Nodes.Count != 0) //選到EdgeName或EQName
            {
                return;
            }
            string EdgeName= TargetNode.FullPath.Split('\\')[0];
            var TargetSensorInfo = staobj.Dict_EdgeName_SensroInfo[EdgeName][TargetNode.Name];
            staobj.QueryParam.NowQuerySensorInfo = TargetSensorInfo;

            switch (staobj.QueryParam.NowShowChartMode)
            {
                case staobj.QueryParam.ShowDataChartMode.Single:
                    SingleModeQueryRawData();
                    break;
                case staobj.QueryParam.ShowDataChartMode.Multi:
                    MultiModeQueryRawData(TargetSensorInfo);
                    break;
                default:
                    break;
            }


           
        }

        private void SingleModeQueryRawData()
        {
            var StartTime = staobj.QueryParam.StartTime;
            var EndTime = staobj.QueryParam.EndTime;
            var TargetSensorInfo = staobj.QueryParam.NowQuerySensorInfo;
            if (TargetSensorInfo == null)
            {
                return;
            }
            Task.Run(() =>
            {
                var IntervalRawData = cls_txtQuery.QueryIntervalRawData(StartTime, EndTime, TargetSensorInfo);
                IntervalRawData.Downsampling(2000);
                Invoke((MethodInvoker)delegate
                {
                    staobj.Form_MainQueryChart.ImportSensorInfo(TargetSensorInfo);
                    staobj.Form_MainQueryChart.ImportSensorDataSeries(IntervalRawData.List_DownSampleTimeLog, IntervalRawData.Dict_DownSampleData);
                    staobj.Form_MainQueryChart.MdiParent = this;
                    staobj.Form_MainQueryChart.Parent = SplitContainer_Sensor_Chart.Panel2;
                    staobj.Form_MainQueryChart.WindowState = FormWindowState.Maximized;
                    staobj.Form_MainQueryChart.Show();
                });
            });
        }

        private void MultiModeQueryRawData(SensorDataProcess.SensorInfo TargetSensorInfo = default)
        {
            if (TargetSensorInfo != default)
            {

                if (!staobj.QueryParam.Dict_SensorName_Chart.ContainsKey(TargetSensorInfo.SensorName))
                {
                    var NewSensorChart = new Views.Form_DataCharts(TargetSensorInfo)
                    {
                        MdiParent = this,
                        Parent = SplitContainer_Sensor_Chart.Panel2
                    };
                    staobj.QueryParam.Dict_SensorName_Chart.Add(TargetSensorInfo.SensorName, NewSensorChart);

                }
            }
            var StartTime = staobj.QueryParam.StartTime;
            var EndTime = staobj.QueryParam.EndTime;
            if (TargetSensorInfo == default) //表示使用者更改查詢區間，所以全部要重新查詢
            {
                foreach (var item in staobj.QueryParam.Dict_SensorName_Chart)
                {
                    Task.Run(() =>
                    {
                        var TargetChart = item.Value;
                        var IntervalRawData = cls_txtQuery.QueryIntervalRawData(StartTime, EndTime, item.Value.SensorInfo);
                        IntervalRawData.Downsampling(1000);
                        Invoke((MethodInvoker)delegate
                        {
                            TargetChart.ImportSensorDataSeries(IntervalRawData.List_DownSampleTimeLog, IntervalRawData.Dict_DownSampleData);
                            TargetChart.Show();
                        });
                    });
                }
                return;
            }

            //只查新增的Sensor
            Task.Run(() =>
            {
                var TargetChart = staobj.QueryParam.Dict_SensorName_Chart[TargetSensorInfo.SensorName];
                var IntervalRawData = cls_txtQuery.QueryIntervalRawData(StartTime, EndTime,TargetSensorInfo );
                IntervalRawData.Downsampling(1000);
                Invoke((MethodInvoker)delegate
                {
                    TargetChart.ImportSensorDataSeries(IntervalRawData.List_DownSampleTimeLog, IntervalRawData.Dict_DownSampleData);
                    TargetChart.BringToFront();
                    TargetChart.Event_FormClicked += MultiSensorFormBringToFront;
                    TargetChart.Show();
                });
            });

        }
        private void MultiSensorFormBringToFront(string SensorName)
        {
            staobj.QueryParam.Dict_SensorName_Chart[SensorName].BringToFront();
        }
        #endregion



        #region Functions
        private void LAB_ShowMulti_Click(object sender, EventArgs e)
        {
            LAB_ShowSingle.ForeColor = Color.White;
            LAB_ShowMulti.ForeColor = Color.FromArgb(131, 222, 220);
            staobj.QueryParam.NowShowChartMode = staobj.QueryParam.ShowDataChartMode.Multi;
            staobj.Form_MainQueryChart.Hide();
            foreach (var item in staobj.QueryParam.Dict_SensorName_Chart)
            {
                item.Value.Show();
            }
        }
        private void LAB_ShowSingle_Click(object sender, EventArgs e)
        {
            LAB_ShowSingle.ForeColor = Color.FromArgb(131, 222, 220);
            LAB_ShowMulti.ForeColor = Color.White;
            staobj.QueryParam.NowShowChartMode = staobj.QueryParam.ShowDataChartMode.Single;
            SingleModeQueryRawData();
            foreach (var item in staobj.QueryParam.Dict_SensorName_Chart)
            {
                item.Value.Hide();
            }
        }
        private void LAB_QueryTime_Click(object sender,EventArgs e)
        {
            LAB_QueryADay.ForeColor = LAB_QueryAWeek.ForeColor = LAB_QueryAMonth.ForeColor = LAB_QuerySixMonth.ForeColor = LAB_QueryAYear.ForeColor = LAB_QueryCustom.ForeColor = Color.White;
            Panel_CustomQueryTime.Visible = false;
            Label TargetLabel = sender as Label;
            TargetLabel.ForeColor = Color.FromArgb(131, 222, 220);
            DateTime EndTime = DateTime.Now;
            staobj.QueryParam.StartTime = EndTime.AddDays(-1*Convert.ToInt32(TargetLabel.Tag));
            staobj.QueryParam.EndTime = EndTime;
            switch (staobj.QueryParam.NowShowChartMode)
            {
                case staobj.QueryParam.ShowDataChartMode.Single:
                    SingleModeQueryRawData();
                    break;
                case staobj.QueryParam.ShowDataChartMode.Multi:
                    MultiModeQueryRawData();
                    break;
                default:
                    break;
            }
        }
        private void LAB_QueryCustom_Click(object sender, EventArgs e)
        {
            LAB_QueryADay.ForeColor = LAB_QueryAWeek.ForeColor = LAB_QueryAMonth.ForeColor = LAB_QuerySixMonth.ForeColor = LAB_QueryAYear.ForeColor = Color.White;
            LAB_QueryCustom.ForeColor = Color.FromArgb(131, 222, 220);

            Panel_CustomQueryTime.Visible = true;
        }

        private void BTN_QueryCustomTime_Click(object sender, EventArgs e)
        {
            DateTime StartTime = DateTimePicker_StartTime.Value;
            DateTime EndTime = DateTimePicker_EndTime.Value;
            if (StartTime>=EndTime)
            {
                MessageBox.Show("Start Time must early than End Time");
                return;
            }
            staobj.QueryParam.StartTime = StartTime;
            staobj.QueryParam.EndTime = EndTime;
            switch (staobj.QueryParam.NowShowChartMode)
            {
                case staobj.QueryParam.ShowDataChartMode.Single:
                    SingleModeQueryRawData();
                    break;
                case staobj.QueryParam.ShowDataChartMode.Multi:
                    MultiModeQueryRawData();
                    break;
                default:
                    break;
            }
        }
        private void BTN_ResizeMultiForm_Click(object sender, EventArgs e)
        {
            int FormCount = staobj.QueryParam.Dict_SensorName_Chart.Count;
            int ColumnCount = (int)Math.Ceiling(Math.Sqrt(FormCount));
            int RowCount = ColumnCount * (ColumnCount - 1) >= FormCount ? (ColumnCount-1) : ColumnCount ;

            int FormWidth = SplitContainer_Sensor_Chart.Panel2.Width / ColumnCount;
            int FormHeight= SplitContainer_Sensor_Chart.Panel2.Height / RowCount;
            int ItemNum = 0;

            foreach (var item in staobj.QueryParam.Dict_SensorName_Chart)
            {
                int RowNumber = ItemNum / ColumnCount;
                int ColumnNumber = ItemNum % ColumnCount;
                Point StartPosition = new Point(ColumnNumber * FormWidth, RowNumber * FormHeight);
                item.Value.Location = StartPosition;
                item.Value.Size = new Size(FormWidth, FormHeight);

                ItemNum += 1;
            }
        }
        #endregion


    }
}
