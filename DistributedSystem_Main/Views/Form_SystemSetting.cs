using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main.Views
{
    public partial class Form_SystemSetting : Form
    {
        public Form_SystemSetting()
        {
            InitializeComponent();
            ReloadMqttInfo();
            ReloadGeneralSetting();
        }

        bool IsFunctionsEnableChange =false;
        private void Form_SystemSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = IsFunctionsEnableChange ? DialogResult.OK : DialogResult.Cancel;
        }

        #region General

        private void ReloadGeneralSetting()
        {
            NUM_Chart_RowNumber.Value = (decimal)Systems.Staobj.SystemParam.ChartSetting.RowNumber;
            NUM_Chart_ColumnNumber.Value = (decimal)Systems.Staobj.SystemParam.ChartSetting.ColumnNumber;
            ToggleSwitch_ISO.IsOn = Systems.Staobj.SystemParam.ISOEnable;
        }
        private void BTN_SaveChartSetting_Click(object sender, EventArgs e)
        {
            Systems.Staobj.SystemParam.ChartSetting.RowNumber = (int)NUM_Chart_RowNumber.Value;
            Systems.Staobj.SystemParam.ChartSetting.ColumnNumber = (int)NUM_Chart_ColumnNumber.Value;
            Systems.cls_SignalsChartManager.SetChartRowColumnNumber(Systems.Staobj.SystemParam.ChartSetting.RowNumber, Systems.Staobj.SystemParam.ChartSetting.ColumnNumber);
            Systems.Staobj.SystemParam.SaveChartSetting();
        }
        private void BTN_CancelChartSetting_Click(object sender, EventArgs e)
        {
            NUM_Chart_RowNumber.Value = (decimal)Systems.Staobj.SystemParam.ChartSetting.RowNumber;
            NUM_Chart_ColumnNumber.Value = (decimal)Systems.Staobj.SystemParam.ChartSetting.ColumnNumber;
        }
        private void BTN_SaveFunctionEnable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否儲存Functions設定", "Functions Setting", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            Systems.Staobj.SystemParam.ISOEnable = ToggleSwitch_ISO.IsOn;
            Systems.Staobj.SystemParam.SaveFuncionSetting();
            IsFunctionsEnableChange = true;
        }
        private void BTN_CancelFuncionsSetting_Click(object sender, EventArgs e)
        {
            ToggleSwitch_ISO.IsOn = Systems.Staobj.SystemParam.ISOEnable;
        }

        #endregion


        #region MqttSetting
        int selectedIndexOfMqttListBox = -1;
        List<MQTTnet.Server.Status.MqttClientStatus> List_MqttClients = null;

        private async void BTN_SaveMqttParameter_Click(object sender, EventArgs e)
        {
            string ServerIP = Systems.Staobj.SystemParam.Mqtt.MqttServerIP = TXT_MqttServerIP.Text;
            int port = Systems.Staobj.SystemParam.Mqtt.MqttServerPort = (int)NUM_MqttPort.Value;
            await Systems.cls_MQTTModule.DestoryServer();
            Systems.cls_MQTTModule.BuildServer(ServerIP, port);
            Systems.Staobj.SystemParam.SaveMqttParam();
        }
        private void ListBox_ClientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndexOfMqttListBox = ListBox_ClientList.SelectedIndex;
            if (selectedIndexOfMqttListBox is -1)
                return;
            RefreshInfomationOfClient(List_MqttClients[selectedIndexOfMqttListBox]);
        }

        private void RefreshInfomationOfClient(MQTTnet.Server.Status.MqttClientStatus mqttClientStatus)
        {
            LAB_MqttClientID.Text = mqttClientStatus.ClientId;
            LAB_MqttClientConnectTime.Text = mqttClientStatus.ConnectedTimestamp.ToString("yyyy/MM/dd HH:mm:ss");
            Panel_MqttClientTopics.Controls.Clear();
            foreach (var item in Systems.cls_MQTTModule.List_TopicNames)
            {
                if (item.Contains(mqttClientStatus.ClientId))
                {
                    Button NewTopicLabel = new Button ()
                    {
                        Text = item,
                        Dock = DockStyle.Top,
                        AutoSize = true,
                        Font = new System.Drawing.Font("微軟正黑體", 12),
                        BackColor = Color.FromArgb(64, 86, 141),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleLeft
                };
                    NewTopicLabel.FlatAppearance.BorderColor = Color.White;
                    Panel_MqttClientTopics.Controls.Add(NewTopicLabel);
                }
            }
        }

        internal void ReloadMqttInfo()
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { ReloadMqttInfo(); });
                return;
            }
            TXT_MqttServerIP.Text = Systems.Staobj.SystemParam.Mqtt.MqttServerIP;
            NUM_MqttPort.Value= Systems.Staobj.SystemParam.Mqtt.MqttServerPort ;
            ListBox_ClientList.Items.Clear(); 
            List_MqttClients = Systems.cls_MQTTModule.GetClientList();
            foreach (var item in List_MqttClients)
            {
                ListBox_ClientList.Items.Add(item.ClientId);
            }
        }


        #endregion
    }
}
