﻿using System;
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
        }


        #region MqttSetting
        int selectedIndexOfMqttListBox = -1;
        List<MQTTnet.Server.Status.MqttClientStatus> List_MqttClients = null;

        private async void BTN_SaveMqttParameter_Click(object sender, EventArgs e)
        {
            string ServerIP = Systems.Staobj.SystemParam.MqttServerIP = TXT_MqttServerIP.Text;
            int port = Systems.Staobj.SystemParam.MqttServerPort = (int)NUM_MqttPort.Value;
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