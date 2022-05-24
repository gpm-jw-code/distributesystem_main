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
            Staobj.SystemParam.LoadSystemParam();
            Systems.cls_SignalsChartManager.InitialManager(TablePanel_SignalChart, PageSwitch_Signals);
            
            Systems.cls_SignalsChartManager.SetChartRowColumnNumber(Staobj.SystemParam.ChartSetting.RowNumber, Staobj.SystemParam.ChartSetting.ColumnNumber);
            Systems.cls_MQTTModule.BuildServer(Staobj.SystemParam.Mqtt.MqttServerIP, Staobj.SystemParam.Mqtt.MqttServerPort);
            SensorDataProcess.cls_txtDataSaver.RootPath = Staobj.SystemParam.DataSaveRootPath;
            TabControl_Main.ItemSize = new Size(0,1);
            foreach (TabPage item in TabControl_Main.TabPages)
            {
                item.Text = "";
            }
            EventRegist();
            Staobj.Forms.Form_Main = this;
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



        #endregion


        #region SideBar
        private void BTN_OpenSystemSetting_Click(object sender, EventArgs e)
        {
            Views.Form_SystemSetting SettingForm = new Views.Form_SystemSetting();
            SettingForm.ShowDialog();
        }
        private void BTN_RawData_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_Signal;
            Panel_RawData.BackColor = Color.FromArgb(0, 43, 54);
            panStatus.BackColor = panLog.BackColor = Color.FromArgb(0, 64, 82);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_Log;
            panLog.BackColor = Color.FromArgb(0, 43, 54);
            panStatus.BackColor = Panel_RawData.BackColor = Color.FromArgb(0, 64, 82);
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_SensorInfo;
            panStatus.BackColor = Color.FromArgb(0, 43, 54);
            Panel_RawData.BackColor = panLog.BackColor = Color.FromArgb(0, 64, 82);
        }

        private void BTN_Query_Click(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcessesByName("DataQuery");
            if ( procs.Length != 0)
            {
                MessageBox.Show("DataQuery已開啟");
                return;
            }

            string dataQueryExeFilename = Path.Combine( Directory.GetCurrentDirectory() ,"DataQuery.exe");
            if ( !File.Exists(dataQueryExeFilename))
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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("即將關閉系統", "Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Raw Data Chart

        private void AddNewSensorToUI(string SensorName)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { AddNewSensorToUI(SensorName); });
                return;
            }
            var TargetSensorProcessObject = Staobj.Dict_SensorProcessObject[SensorName];
            var SensorInfo = TargetSensorProcessObject.SensorInfo;
            DGV_SensorInfo.Rows.Add("", SensorInfo.EQName, SensorInfo.UnitName, SensorInfo.SensorName, SensorInfo.SensorType);
            DataGridViewRow TargetRow = DGV_SensorInfo.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[3].Value.ToString() == SensorInfo.SensorName).First();
            TargetRow.Cells[0].Style.BackColor = Color.Lime;

            cls_SignalsChartManager.FilterAndSortSensor();

            TargetSensorProcessObject.Event_UpdateChartSeries += UpdateSensorChart;
            TargetSensorProcessObject.Event_RefreshSensorInfo += UpdateSensorInfo;
            TargetSensorProcessObject.Event_RefreshSensorThreshold += UpdateSensorThreshold;
        }

        private void UpdateSensorThreshold(string SensorName)
        {
            Invoke((MethodInvoker)delegate { cls_SignalsChartManager.UpdateThresholdToChart(SensorName,Staobj.Dict_SensorProcessObject[SensorName].Dict_DataThreshold); });
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
        #endregion

    }
}
