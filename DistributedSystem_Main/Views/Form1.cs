using DistributedSystem_Main.Systems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Staobj.SystemParam.LoadSystemParam();
            Systems.cls_SignalsChartManager.InitialManager(TablePanel_SignalChart, PageSwitch_Signals);
            Systems.cls_SignalsChartManager.SetChartRowColumnNumber(2, 2);
            Systems.cls_MQTTModule.BuildServer(Staobj.SystemParam.MqttServerIP, Staobj.SystemParam.MqttServerPort);
            SensorDataProcess.cls_txtDataSaver.RootPath = Staobj.SystemParam.DataSaveRootPath;
            EventRegist();
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
        private void BTN_RawData_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_Signal;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_Log;
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            TabControl_Main.SelectedTab = TabPage_SensorInfo;
        }

        private void picbOFF_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即將關閉系統", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Chart

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
