using cls_PostgreSQL_Tool;
using DistributedSystem_Main.Systems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
            Staobj.Forms.Form_Main = this;
            Staobj.SystemParam.LoadSystemParam();
            Systems.cls_SignalsChartManager.InitialManager(TablePanel_SignalChart, PageSwitch_Signals);
            Systems.cls_SignalsChartManager.SetChartRowColumnNumber(Staobj.SystemParam.ChartSetting.RowNumber, Staobj.SystemParam.ChartSetting.ColumnNumber);

            cls_ISOChartManager.InitialManager(TablePanel_ISOChart, PageSwitch_ISOChart);
            cls_ISOChartManager.SetChartRowColumnNumber(Staobj.SystemParam.ChartSetting.RowNumber, Staobj.SystemParam.ChartSetting.ColumnNumber);

            cls_HomePageManager.InitialManager(DGV_HomePaeTable, GroupSwitch_HomePage,PageSwitch_HomePage,Panel_HomePageSwitch);

            Systems.cls_MQTTModule.BuildServer(Staobj.SystemParam.Mqtt.MqttServerIP, Staobj.SystemParam.Mqtt.MqttServerPort);
            SensorDataProcess.cls_txtDataSaver.RootPath = Staobj.SystemParam.DataSaveRootPath;
            TabControl_Main.ItemSize = new Size(0, 1);
            foreach (TabPage item in TabControl_Main.TabPages)
            {
                item.Text = "";
            }
            SetISOFunctionUIEnable(Staobj.SystemParam.ISOEnable);
            EventRegist();
            FormMain_SizeChanged(null,null);
        }

        #region System Initial
        private void EventRegist()
        {
            Systems.Staobj.Event_ReceiveNewSensorInfo += AddNewSensorToUI;
            Systems.Staobj.Event_UpdateSensorStatus += UpdateSensorConnectStatus;
            User_Control.USC_SensorDataChart.Event_SettingButtonClicked += OpenSystemSettingForm;
            PageSwitch_Signals.Event_PageChange += cls_SignalsChartManager.RefreshShowChart;
        }

        private void OpenSystemSettingForm(string SensorName)
        {
            var TargetSensorProcessobject = Staobj.Dict_SensorProcessObject[SensorName];
            Views.Form_SensorThresholdSetting ThresholdSettingForm = new Views.Form_SensorThresholdSetting(TargetSensorProcessobject.SensorInfo);
            ThresholdSettingForm.ImportThresholdSettings(TargetSensorProcessobject.Dict_DataThreshold);
            ThresholdSettingForm.ShowDialog();
        }


        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                return;
            }
            Systems.cls_HomePageManager.ResetRowHeight();
        }

        #endregion

        #region SideBar

        private void BTN_AlarmEvent_Click(object sender, EventArgs e)
        {
            Staobj.Forms.Form_AlarmEvent.Show();
            Staobj.Forms.Form_AlarmEvent.BringToFront();
        }

        private void BTN_OpenSystemSetting_Click(object sender, EventArgs e)
        {
            Views.Form_SystemSetting SettingForm = new Views.Form_SystemSetting();
            if (SettingForm.ShowDialog() == DialogResult.OK)
            {
                SetISOFunctionUIEnable(Staobj.SystemParam.ISOEnable);
            }
        }

        private void SetISOFunctionUIEnable(bool Enable)
        {
            Panel_ISO.Visible = Enable;
            SensorDataProcess.cls_SensorDataProcess.ISOFunctionEnable = Enable;
            DGV_SensorInfo.Columns["Column_ISOSetting"].Visible = Enable;
            BTN_RawData_Click(null, null);

            foreach (var item in Staobj.Dict_SensorProcessObject)
            {
                if (item.Value.SensorInfo.ISOCheckDataName == null)
                    continue;
                AddNewSensor_ISO(item.Key);
            }
        }

        private void BTN_RawData_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_Signal;
            Panel_RawData.BackColor = Color.FromArgb(0, 43, 54);
            Panel_ISO.BackColor = panStatus.BackColor = Panel_HomePage.BackColor = Color.FromArgb(0, 64, 82);
        }

        private void BTN_HomePage_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_HomePage;
            Panel_HomePage.BackColor = Color.FromArgb(0, 43, 54);
            Panel_ISO.BackColor = panStatus.BackColor = Panel_RawData.BackColor = Color.FromArgb(0, 64, 82);
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_SensorInfo;
            panStatus.BackColor = Color.FromArgb(0, 43, 54);
            Panel_ISO.BackColor = Panel_RawData.BackColor = Panel_HomePage.BackColor = Color.FromArgb(0, 64, 82);
        }
        private void BTN_ISO_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_ISO;
            Panel_ISO.BackColor = Color.FromArgb(0, 43, 54);
            panStatus.BackColor = Panel_RawData.BackColor = Panel_HomePage.BackColor = Color.FromArgb(0, 64, 82);
        }
        private void BTN_Query_Click(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcessesByName("DataQuery");
            if (procs.Length != 0)
            {
                MessageBox.Show("DataQuery已開啟");
                return;
            }

            string dataQueryExeFilename = Path.Combine(Directory.GetCurrentDirectory(), "DataQuery.exe");
            if (!File.Exists(dataQueryExeFilename))
            {
                MessageBox.Show("找不到DataQuery程式");
                return;
            }


            Task.Run(() =>
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetDirectoryName(dataQueryExeFilename),
                    FileName = dataQueryExeFilename
                };
                Process.Start(startInfo);//呼叫Query程式(外部程式)
            });
        }

        private void picbOFF_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void picbRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即將重啟系統", "RESTART", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) //進行重啟的時候的時候
                Application.Exit();
            else
            {
                if (MessageBox.Show("即將關閉系統", "Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region Buttom Infomation
        public void SetMqttConnectState(bool BuildState)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { SetMqttConnectState(BuildState); });
                return;
            }
            LAB_MQTTServerState.BackColor = BuildState ? Color.Lime : Color.Red;
        }
        #endregion

        #region Raw Data Chart

        private void TXT_RawDataChartFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Systems.cls_SignalsChartManager.FilterAndSortSensor(TXT_RawDataChartFilter.Text);
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (TXT_RawDataChartFilter.Text == "")
                {
                    return;
                }
                Systems.cls_SignalsChartManager.FilterAndSortSensor("");
                TXT_RawDataChartFilter.Text = "";
            }

        }

        private void AddNewSensorToUI(string SensorName)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { AddNewSensorToUI(SensorName); });
                return;
            }
            var TargetSensorProcessObject = Staobj.Dict_SensorProcessObject[SensorName];
            var SensorInfo = TargetSensorProcessObject.SensorInfo;
            DGV_SensorInfo.Rows.Add("", SensorInfo.EQName, SensorInfo.UnitName, SensorInfo.SensorName, SensorInfo.SensorType, "Setting");
            DataGridViewRow TargetRow = DGV_SensorInfo.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[3].Value.ToString() == SensorInfo.SensorName).First();
            TargetRow.Cells[0].Style.BackColor = Color.Lime;

            cls_SignalsChartManager.FilterAndSortSensor();

            TargetSensorProcessObject.Event_UpdateMainTable += UpdateMainTable;
            TargetSensorProcessObject.Event_UpdateChartSeries += UpdateSensorChart;
            TargetSensorProcessObject.Event_RefreshSensorInfo += UpdateSensorInfo;
            TargetSensorProcessObject.Event_RefreshSensorThreshold += UpdateSensorThreshold;
            TargetSensorProcessObject.Event_UpdateSensorCheckStates += UpdateSensorCheckStates; 

            AddNewSensor_ISO(SensorName);
        }

        private void UpdateMainTable(string SensorName, Dictionary<string, double> Dict_LastData)
        {
            Invoke((MethodInvoker)delegate { Systems.cls_HomePageManager.UpdateSensorData(SensorName, Dict_LastData); });
            
        }

        private void UpdateSensorCheckStates(string SensorName)
        {
            var SensorInfo = Staobj.Dict_SensorProcessObject[SensorName].SensorInfo;
            var CheckStatus = Staobj.Dict_SensorProcessObject[SensorName].Dict_OutOfItemStates;
            Invoke((MethodInvoker)delegate { Staobj.Forms.Form_AlarmEvent.InsertNewEventLog(SensorInfo, CheckStatus); });
        }

        private void UpdateSensorThreshold(string SensorName)
        {
            Invoke((MethodInvoker)delegate { cls_SignalsChartManager.UpdateThresholdToChart(SensorName, Staobj.Dict_SensorProcessObject[SensorName].Dict_DataThreshold); });
        }

        private void UpdateSensorInfo(string SensorName)
        {
            Invoke((MethodInvoker)delegate { cls_SignalsChartManager.UpdateSensorInfoToChart(SensorName); });
        }

        private void UpdateSensorChart(string SensorName, Queue<DateTime> Queue_Time, Dictionary<string, Queue<double>> Dict_DataQueue)
        {
            Invoke((MethodInvoker)delegate { cls_SignalsChartManager.UpdateSensorData(SensorName, Queue_Time, Dict_DataQueue); });
        }

        #endregion

        #region Status (SensorInfo)

        private void UpdateSensorConnectStatus(string SensorName)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { UpdateSensorConnectStatus(SensorName); });
                return;
            }
            //Staobj.Dict_SensorDataCharts[SensorName].LastUpdateTime = Staobj.Dict_SensorProcessObject[SensorName].Status.LastUpdateTime;
            DataGridViewRow TargetRow = DGV_SensorInfo.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[3].Value.ToString() == SensorName).First();
            TargetRow.Cells[0].Style.BackColor = Staobj.Dict_SensorProcessObject[SensorName].Status.ConnecStatus ? Color.Lime : Color.Red;
        }
        private void BTN_EditSensorInfo_Click(object sender, EventArgs e)
        {
            SetDGVSensorInfoEditEnable(true);
        }

        private void SetDGVSensorInfoEditEnable(bool Enable)
        {
            DGV_SensorInfo.Columns[1].ReadOnly = !Enable; //EQName
            DGV_SensorInfo.Columns[2].ReadOnly = !Enable; //UnitName

            BTN_EditSensorInfo.Enabled = !Enable;
            BTN_SaveSensorInfo.Visible = BTN_CancelEditSensorInfo.Visible = Enable;
        }

        private void BTN_SaveSensorInfo_Click(object sender, EventArgs e)
        {
            foreach (var item in DGV_SensorInfo.Rows.Cast<DataGridViewRow>())
            {
                string SensorName = item.Cells[3].Value.ToString();
                Staobj.Dict_SensorProcessObject[SensorName].SensorInfo.EQName = item.Cells[1].Value.ToString();
                Staobj.Dict_SensorProcessObject[SensorName].SensorInfo.UnitName = item.Cells[2].Value.ToString();
                Staobj.Dict_SensorProcessObject[SensorName].RefreshSensorInfo();
                Staobj.SensorParam.SaveSensorInfoToFile(Staobj.Dict_SensorProcessObject[SensorName].SensorInfo);
            }
            SetDGVSensorInfoEditEnable(false);
        }
        private void DGV_SensorInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int RowNumber = e.RowIndex;
                string SensorName = DGV_SensorInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                var SensorProcessObject = Staobj.Dict_SensorProcessObject[SensorName];

                Views.Form_ISOSetting FormISO = new Views.Form_ISOSetting(SensorProcessObject);
                if (FormISO.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in Staobj.Dict_SensorProcessObject)
                    {
                        if (item.Value.SensorInfo.ISOCheckDataName == null)
                            continue;
                        AddNewSensor_ISO(item.Key);
                    }
                }
                return;
            }
        }

        #endregion

        #region ISO Chart

        //private void TXT_RawDataChartFilter_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Systems.cls_SignalsChartManager.FilterAndSortSensor(TXT_RawDataChartFilter.Text);
        //        return;
        //    }
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        if (TXT_RawDataChartFilter.Text == "")
        //        {
        //            return;
        //        }
        //        Systems.cls_SignalsChartManager.FilterAndSortSensor("");
        //        TXT_RawDataChartFilter.Text = "";
        //    }

        //}
        private void AddNewSensor_ISO(string SensorName)
        {
            if (!Staobj.SystemParam.ISOEnable)
            {
                return;
            }
            var TargetSensorProcessObject = Staobj.Dict_SensorProcessObject[SensorName];
            var SensorInfo = TargetSensorProcessObject.SensorInfo;

            if (TargetSensorProcessObject.ISOCheckObject == null)
            {
                return;
            }

            cls_ISOChartManager.FilterAndSortSensor();

            if (TargetSensorProcessObject.Event_RefreshSensorISOSetting != null)
                return;
            TargetSensorProcessObject.Event_UpdateChartSeries += UpdateSensorChart_ISO;
            TargetSensorProcessObject.Event_RefreshSensorInfo += UpdateSensorInfo_ISO;
            TargetSensorProcessObject.Event_RefreshSensorISOSetting += UpdateISONumber;
        }

        private void UpdateISONumber(string SensorName)
        {
            if (!Staobj.SystemParam.ISOEnable)
            {
                return;
            }
            var ISOObject = Staobj.Dict_SensorProcessObject[SensorName].ISOCheckObject;
            Invoke((MethodInvoker)delegate { cls_ISOChartManager.UpdateSensorISOThreshold(SensorName, ISOObject.ThresholdA, ISOObject.ThresholdB, ISOObject.ThresholdC); });
        }

        private void UpdateSensorInfo_ISO(string SensorName)
        {
            if (!Staobj.SystemParam.ISOEnable)
            {
                return;
            }
            Invoke((MethodInvoker)delegate { cls_ISOChartManager.UpdateSensorInfoToChart(SensorName); });
        }

        private void UpdateSensorChart_ISO(string SensorName, Queue<DateTime> Queue_Time, Dictionary<string, Queue<double>> Dict_DataQueue)
        {
            if (!Staobj.SystemParam.ISOEnable)
            {
                return;
            }
            if (Staobj.Dict_SensorProcessObject[SensorName].SensorInfo.ISOCheckDataName == null)
            {
                return;
            }
            if (!Dict_DataQueue.ContainsKey(Staobj.Dict_SensorProcessObject[SensorName].SensorInfo.ISOCheckDataName))
            {
                return;
            }
            var ISODataQueue = Dict_DataQueue[Staobj.Dict_SensorProcessObject[SensorName].SensorInfo.ISOCheckDataName];
            Invoke((MethodInvoker)delegate { cls_ISOChartManager.UpdateSensorData(SensorName, Queue_Time, ISODataQueue); });
        }


        #endregion

        #region HomePage
        private void BTN_HomeGroupSetting_Click(object sender, EventArgs e)
        {
            Views.Form_HomeGroupSetting Form_GroupSetting = new Views.Form_HomeGroupSetting();
            Form_GroupSetting.ShowDialog();
        }
        #endregion

    }
}
