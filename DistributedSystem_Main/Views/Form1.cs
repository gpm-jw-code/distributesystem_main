﻿using DistributedSystem_Main.Systems;
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
            Systems.cls_MQTTModule.BuildServer(Staobj.SystemParam.MqttServerIP, Staobj.SystemParam.MqttServerPort);
            SensorDataProcess.cls_txtDataSaver.RootPath = Staobj.SystemParam.DataSaveRootPath;
            EventRegist();
        }

        #region System Initial
        private void EventRegist()
        {
            Systems.Staobj.Event_ReceiveNewSensorInfo += AddNewSensorToUI;
            Systems.Staobj.Event_UpdateSensorStatus+= UpdateSensorConnectStatus;
            Views.USC_SensorDataChart.Event_SettingButtonClicked += OpenSystemSettingForm;
        }

        private void OpenSystemSettingForm(string SensorName)
        {
            var TargetSensorProcessobject = Staobj.Dict_SensorProcessObject[SensorName];
            Views.Form_SensorThresholdSetting ThresholdSettingForm = new Views.Form_SensorThresholdSetting(TargetSensorProcessobject.SensorInfo);
            ThresholdSettingForm.ImportThresholdSettings(TargetSensorProcessobject.Dict_DataThreshold);
            ThresholdSettingForm.ShowDialog();
            Staobj.Dict_SensorDataCharts[SensorName].SetSensorThreshold(TargetSensorProcessobject.Dict_DataThreshold);
        }

        private void UpdateSensorConnectStatus(string SensorName)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { UpdateSensorConnectStatus(SensorName); });
                return;
            }
            Staobj.Dict_SensorDataCharts[SensorName].LastUpdateTime=Staobj.Dict_SensorProcessObject[SensorName].Status.LastUpdateTime;
            DataGridViewRow TargetRow = DGV_SensorInfo.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[3].Value.ToString() == SensorName).First();
            TargetRow.Cells[0].Style.BackColor = Staobj.Dict_SensorProcessObject[SensorName].Status.ConnecStatus ? Color.Lime : Color.Red;
        }

        private void AddNewSensorToUI(string SensorName)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { AddNewSensorToUI(SensorName); });
                return;
            }
            TablePanel_SignalChart.Controls.Add(Staobj.Dict_SensorDataCharts[SensorName]);
            var SensorInfo = Staobj.Dict_SensorProcessObject[SensorName].SensorInfo;
            DGV_SensorInfo.Rows.Add("", SensorInfo.EQName, SensorInfo.UnitName, SensorInfo.SensorName, SensorInfo.SensorType);
            DataGridViewRow TargetRow = DGV_SensorInfo.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[3].Value.ToString() == SensorInfo.SensorName).First();
            TargetRow.Cells[0].Style.BackColor = Color.Lime;

            Staobj.Dict_SensorProcessObject[SensorName].Event_UpdateChartSeries += UpdateSensorChart;
        }

        private void UpdateSensorChart(string SensorName, Queue<DateTime> Queue_Time, Dictionary<string, Queue<double>> Dict_DataQueue)
        {
            Invoke((MethodInvoker)delegate { Staobj.Dict_SensorDataCharts[SensorName].ImportSensorDataSeries(Queue_Time, Dict_DataQueue); });
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
        #endregion

        #region Chart



        #endregion

        private void picbOFF_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即將關閉系統", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            } 
        }
    }
}
