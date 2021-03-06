
namespace DistributedSystem_Main.Views
{
    partial class Form_SystemSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl_Main = new System.Windows.Forms.TabControl();
            this.TabPage_UISetting = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTN_CancelFuncionsSetting = new System.Windows.Forms.Button();
            this.BTN_SaveFunctionEnable = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_CancelChartSetting = new System.Windows.Forms.Button();
            this.BTN_SaveChartSetting = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.NUM_Chart_RowNumber = new System.Windows.Forms.NumericUpDown();
            this.NUM_Chart_ColumnNumber = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TabPage_Mqtt = new System.Windows.Forms.TabPage();
            this.TablePanel_MqttClient = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_MqttClientList = new System.Windows.Forms.Panel();
            this.ListBox_ClientList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel_ClientInfo = new System.Windows.Forms.Panel();
            this.Panel_MqttClientTopics = new System.Windows.Forms.Panel();
            this.LAB_MqttClientConnectTime = new System.Windows.Forms.Label();
            this.LAB_MqttClientID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Panel_MqttSetting = new System.Windows.Forms.Panel();
            this.BTN_CancelMqttParam = new System.Windows.Forms.Button();
            this.BTN_SaveMqttParameter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.NUM_MqttPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.TXT_MqttServerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTN_CancelPathSetting = new System.Windows.Forms.Button();
            this.BTN_SavePath = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TXT_DataSavePath = new System.Windows.Forms.TextBox();
            this.BTN_SelectDataPath = new System.Windows.Forms.Button();
            this.ToggleSwitch_ISO = new USC_ModulePart.MyToggleSwitch();
            this.TabControl_Main.SuspendLayout();
            this.TabPage_UISetting.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Chart_RowNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Chart_ColumnNumber)).BeginInit();
            this.TabPage_Mqtt.SuspendLayout();
            this.TablePanel_MqttClient.SuspendLayout();
            this.Panel_MqttClientList.SuspendLayout();
            this.Panel_ClientInfo.SuspendLayout();
            this.Panel_MqttSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_MqttPort)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Controls.Add(this.TabPage_UISetting);
            this.TabControl_Main.Controls.Add(this.TabPage_Mqtt);
            this.TabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(636, 537);
            this.TabControl_Main.TabIndex = 0;
            // 
            // TabPage_UISetting
            // 
            this.TabPage_UISetting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TabPage_UISetting.Controls.Add(this.panel3);
            this.TabPage_UISetting.Controls.Add(this.panel2);
            this.TabPage_UISetting.Controls.Add(this.panel1);
            this.TabPage_UISetting.Location = new System.Drawing.Point(4, 26);
            this.TabPage_UISetting.Name = "TabPage_UISetting";
            this.TabPage_UISetting.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_UISetting.Size = new System.Drawing.Size(628, 507);
            this.TabPage_UISetting.TabIndex = 1;
            this.TabPage_UISetting.Text = "General";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.ToggleSwitch_ISO);
            this.panel2.Controls.Add(this.BTN_CancelFuncionsSetting);
            this.panel2.Controls.Add(this.BTN_SaveFunctionEnable);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(400, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 123);
            this.panel2.TabIndex = 6;
            // 
            // BTN_CancelFuncionsSetting
            // 
            this.BTN_CancelFuncionsSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BTN_CancelFuncionsSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_CancelFuncionsSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CancelFuncionsSetting.Location = new System.Drawing.Point(149, 76);
            this.BTN_CancelFuncionsSetting.Name = "BTN_CancelFuncionsSetting";
            this.BTN_CancelFuncionsSetting.Size = new System.Drawing.Size(65, 32);
            this.BTN_CancelFuncionsSetting.TabIndex = 5;
            this.BTN_CancelFuncionsSetting.Text = "Cancel";
            this.BTN_CancelFuncionsSetting.UseVisualStyleBackColor = false;
            this.BTN_CancelFuncionsSetting.Click += new System.EventHandler(this.BTN_CancelFuncionsSetting_Click);
            // 
            // BTN_SaveFunctionEnable
            // 
            this.BTN_SaveFunctionEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTN_SaveFunctionEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SaveFunctionEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SaveFunctionEnable.Location = new System.Drawing.Point(81, 76);
            this.BTN_SaveFunctionEnable.Name = "BTN_SaveFunctionEnable";
            this.BTN_SaveFunctionEnable.Size = new System.Drawing.Size(65, 32);
            this.BTN_SaveFunctionEnable.TabIndex = 5;
            this.BTN_SaveFunctionEnable.Text = "Save";
            this.BTN_SaveFunctionEnable.UseVisualStyleBackColor = false;
            this.BTN_SaveFunctionEnable.Click += new System.EventHandler(this.BTN_SaveFunctionEnable_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Functions";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "ISO 10816：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.BTN_CancelChartSetting);
            this.panel1.Controls.Add(this.BTN_SaveChartSetting);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.NUM_Chart_RowNumber);
            this.panel1.Controls.Add(this.NUM_Chart_ColumnNumber);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(8, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 147);
            this.panel1.TabIndex = 6;
            // 
            // BTN_CancelChartSetting
            // 
            this.BTN_CancelChartSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BTN_CancelChartSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_CancelChartSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CancelChartSetting.Location = new System.Drawing.Point(149, 104);
            this.BTN_CancelChartSetting.Name = "BTN_CancelChartSetting";
            this.BTN_CancelChartSetting.Size = new System.Drawing.Size(65, 32);
            this.BTN_CancelChartSetting.TabIndex = 5;
            this.BTN_CancelChartSetting.Text = "Cancel";
            this.BTN_CancelChartSetting.UseVisualStyleBackColor = false;
            this.BTN_CancelChartSetting.Click += new System.EventHandler(this.BTN_CancelChartSetting_Click);
            // 
            // BTN_SaveChartSetting
            // 
            this.BTN_SaveChartSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTN_SaveChartSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SaveChartSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SaveChartSetting.Location = new System.Drawing.Point(81, 104);
            this.BTN_SaveChartSetting.Name = "BTN_SaveChartSetting";
            this.BTN_SaveChartSetting.Size = new System.Drawing.Size(65, 32);
            this.BTN_SaveChartSetting.TabIndex = 5;
            this.BTN_SaveChartSetting.Text = "Save";
            this.BTN_SaveChartSetting.UseVisualStyleBackColor = false;
            this.BTN_SaveChartSetting.Click += new System.EventHandler(this.BTN_SaveChartSetting_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Chart";
            // 
            // NUM_Chart_RowNumber
            // 
            this.NUM_Chart_RowNumber.Location = new System.Drawing.Point(81, 35);
            this.NUM_Chart_RowNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUM_Chart_RowNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUM_Chart_RowNumber.Name = "NUM_Chart_RowNumber";
            this.NUM_Chart_RowNumber.Size = new System.Drawing.Size(127, 25);
            this.NUM_Chart_RowNumber.TabIndex = 3;
            this.NUM_Chart_RowNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // NUM_Chart_ColumnNumber
            // 
            this.NUM_Chart_ColumnNumber.Location = new System.Drawing.Point(81, 66);
            this.NUM_Chart_ColumnNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUM_Chart_ColumnNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUM_Chart_ColumnNumber.Name = "NUM_Chart_ColumnNumber";
            this.NUM_Chart_ColumnNumber.Size = new System.Drawing.Size(127, 25);
            this.NUM_Chart_ColumnNumber.TabIndex = 4;
            this.NUM_Chart_ColumnNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Column : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Row : ";
            // 
            // TabPage_Mqtt
            // 
            this.TabPage_Mqtt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TabPage_Mqtt.Controls.Add(this.TablePanel_MqttClient);
            this.TabPage_Mqtt.Controls.Add(this.Panel_MqttSetting);
            this.TabPage_Mqtt.Location = new System.Drawing.Point(4, 26);
            this.TabPage_Mqtt.Name = "TabPage_Mqtt";
            this.TabPage_Mqtt.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Mqtt.Size = new System.Drawing.Size(628, 507);
            this.TabPage_Mqtt.TabIndex = 0;
            this.TabPage_Mqtt.Text = "Mqtt";
            // 
            // TablePanel_MqttClient
            // 
            this.TablePanel_MqttClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablePanel_MqttClient.ColumnCount = 2;
            this.TablePanel_MqttClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.TablePanel_MqttClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablePanel_MqttClient.Controls.Add(this.Panel_MqttClientList, 0, 0);
            this.TablePanel_MqttClient.Controls.Add(this.Panel_ClientInfo, 1, 0);
            this.TablePanel_MqttClient.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TablePanel_MqttClient.Location = new System.Drawing.Point(9, 167);
            this.TablePanel_MqttClient.Name = "TablePanel_MqttClient";
            this.TablePanel_MqttClient.RowCount = 1;
            this.TablePanel_MqttClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablePanel_MqttClient.Size = new System.Drawing.Size(623, 344);
            this.TablePanel_MqttClient.TabIndex = 6;
            // 
            // Panel_MqttClientList
            // 
            this.Panel_MqttClientList.Controls.Add(this.ListBox_ClientList);
            this.Panel_MqttClientList.Controls.Add(this.label1);
            this.Panel_MqttClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_MqttClientList.Location = new System.Drawing.Point(3, 3);
            this.Panel_MqttClientList.Name = "Panel_MqttClientList";
            this.Panel_MqttClientList.Size = new System.Drawing.Size(214, 338);
            this.Panel_MqttClientList.TabIndex = 0;
            // 
            // ListBox_ClientList
            // 
            this.ListBox_ClientList.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ListBox_ClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_ClientList.FormattingEnabled = true;
            this.ListBox_ClientList.ItemHeight = 20;
            this.ListBox_ClientList.Items.AddRange(new object[] {
            "ITRI_particle",
            "Environment",
            "Temperature"});
            this.ListBox_ClientList.Location = new System.Drawing.Point(0, 31);
            this.ListBox_ClientList.Name = "ListBox_ClientList";
            this.ListBox_ClientList.Size = new System.Drawing.Size(214, 307);
            this.ListBox_ClientList.TabIndex = 1;
            this.ListBox_ClientList.SelectedIndexChanged += new System.EventHandler(this.ListBox_ClientList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLIENTS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel_ClientInfo
            // 
            this.Panel_ClientInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ClientInfo.Controls.Add(this.Panel_MqttClientTopics);
            this.Panel_ClientInfo.Controls.Add(this.LAB_MqttClientConnectTime);
            this.Panel_ClientInfo.Controls.Add(this.LAB_MqttClientID);
            this.Panel_ClientInfo.Controls.Add(this.label6);
            this.Panel_ClientInfo.Controls.Add(this.label2);
            this.Panel_ClientInfo.Controls.Add(this.label5);
            this.Panel_ClientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_ClientInfo.Location = new System.Drawing.Point(223, 3);
            this.Panel_ClientInfo.Name = "Panel_ClientInfo";
            this.Panel_ClientInfo.Size = new System.Drawing.Size(397, 338);
            this.Panel_ClientInfo.TabIndex = 1;
            // 
            // Panel_MqttClientTopics
            // 
            this.Panel_MqttClientTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_MqttClientTopics.AutoScroll = true;
            this.Panel_MqttClientTopics.Location = new System.Drawing.Point(30, 189);
            this.Panel_MqttClientTopics.Name = "Panel_MqttClientTopics";
            this.Panel_MqttClientTopics.Size = new System.Drawing.Size(337, 141);
            this.Panel_MqttClientTopics.TabIndex = 7;
            // 
            // LAB_MqttClientConnectTime
            // 
            this.LAB_MqttClientConnectTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LAB_MqttClientConnectTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.LAB_MqttClientConnectTime.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_MqttClientConnectTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LAB_MqttClientConnectTime.Location = new System.Drawing.Point(30, 114);
            this.LAB_MqttClientConnectTime.Name = "LAB_MqttClientConnectTime";
            this.LAB_MqttClientConnectTime.Size = new System.Drawing.Size(337, 36);
            this.LAB_MqttClientConnectTime.TabIndex = 6;
            this.LAB_MqttClientConnectTime.Text = "yyyy/MM/dd HH:mm:ss";
            this.LAB_MqttClientConnectTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LAB_MqttClientID
            // 
            this.LAB_MqttClientID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LAB_MqttClientID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.LAB_MqttClientID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_MqttClientID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LAB_MqttClientID.Location = new System.Drawing.Point(30, 31);
            this.LAB_MqttClientID.Name = "LAB_MqttClientID";
            this.LAB_MqttClientID.Size = new System.Drawing.Size(337, 36);
            this.LAB_MqttClientID.TabIndex = 6;
            this.LAB_MqttClientID.Text = "Client ID";
            this.LAB_MqttClientID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(19, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "TOPIC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(19, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "連線時間";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(19, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "ID";
            // 
            // Panel_MqttSetting
            // 
            this.Panel_MqttSetting.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_MqttSetting.Controls.Add(this.BTN_CancelMqttParam);
            this.Panel_MqttSetting.Controls.Add(this.BTN_SaveMqttParameter);
            this.Panel_MqttSetting.Controls.Add(this.label8);
            this.Panel_MqttSetting.Controls.Add(this.NUM_MqttPort);
            this.Panel_MqttSetting.Controls.Add(this.label4);
            this.Panel_MqttSetting.Controls.Add(this.TXT_MqttServerIP);
            this.Panel_MqttSetting.Controls.Add(this.label3);
            this.Panel_MqttSetting.Location = new System.Drawing.Point(6, 9);
            this.Panel_MqttSetting.Name = "Panel_MqttSetting";
            this.Panel_MqttSetting.Size = new System.Drawing.Size(220, 147);
            this.Panel_MqttSetting.TabIndex = 5;
            // 
            // BTN_CancelMqttParam
            // 
            this.BTN_CancelMqttParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BTN_CancelMqttParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_CancelMqttParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CancelMqttParam.Location = new System.Drawing.Point(149, 97);
            this.BTN_CancelMqttParam.Name = "BTN_CancelMqttParam";
            this.BTN_CancelMqttParam.Size = new System.Drawing.Size(59, 32);
            this.BTN_CancelMqttParam.TabIndex = 5;
            this.BTN_CancelMqttParam.Text = "Cancel";
            this.BTN_CancelMqttParam.UseVisualStyleBackColor = false;
            // 
            // BTN_SaveMqttParameter
            // 
            this.BTN_SaveMqttParameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTN_SaveMqttParameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SaveMqttParameter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SaveMqttParameter.Location = new System.Drawing.Point(81, 97);
            this.BTN_SaveMqttParameter.Name = "BTN_SaveMqttParameter";
            this.BTN_SaveMqttParameter.Size = new System.Drawing.Size(61, 32);
            this.BTN_SaveMqttParameter.TabIndex = 5;
            this.BTN_SaveMqttParameter.Text = "Save";
            this.BTN_SaveMqttParameter.UseVisualStyleBackColor = false;
            this.BTN_SaveMqttParameter.Click += new System.EventHandler(this.BTN_SaveMqttParameter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Server Parameters";
            // 
            // NUM_MqttPort
            // 
            this.NUM_MqttPort.Location = new System.Drawing.Point(81, 66);
            this.NUM_MqttPort.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUM_MqttPort.Name = "NUM_MqttPort";
            this.NUM_MqttPort.Size = new System.Drawing.Size(127, 25);
            this.NUM_MqttPort.TabIndex = 3;
            this.NUM_MqttPort.Value = new decimal(new int[] {
            1883,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port : ";
            // 
            // TXT_MqttServerIP
            // 
            this.TXT_MqttServerIP.Location = new System.Drawing.Point(81, 30);
            this.TXT_MqttServerIP.Name = "TXT_MqttServerIP";
            this.TXT_MqttServerIP.Size = new System.Drawing.Size(127, 25);
            this.TXT_MqttServerIP.TabIndex = 2;
            this.TXT_MqttServerIP.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Server IP : ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.BTN_SelectDataPath);
            this.panel3.Controls.Add(this.TXT_DataSavePath);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.BTN_CancelPathSetting);
            this.panel3.Controls.Add(this.BTN_SavePath);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(8, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 123);
            this.panel3.TabIndex = 6;
            // 
            // BTN_CancelPathSetting
            // 
            this.BTN_CancelPathSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BTN_CancelPathSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_CancelPathSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CancelPathSetting.Location = new System.Drawing.Point(309, 76);
            this.BTN_CancelPathSetting.Name = "BTN_CancelPathSetting";
            this.BTN_CancelPathSetting.Size = new System.Drawing.Size(65, 32);
            this.BTN_CancelPathSetting.TabIndex = 5;
            this.BTN_CancelPathSetting.Text = "Cancel";
            this.BTN_CancelPathSetting.UseVisualStyleBackColor = false;
            this.BTN_CancelPathSetting.Click += new System.EventHandler(this.BTN_CancelPathSetting_Click);
            // 
            // BTN_SavePath
            // 
            this.BTN_SavePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTN_SavePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SavePath.Location = new System.Drawing.Point(241, 76);
            this.BTN_SavePath.Name = "BTN_SavePath";
            this.BTN_SavePath.Size = new System.Drawing.Size(65, 32);
            this.BTN_SavePath.TabIndex = 5;
            this.BTN_SavePath.Text = "Save";
            this.BTN_SavePath.UseVisualStyleBackColor = false;
            this.BTN_SavePath.Click += new System.EventHandler(this.BTN_SavePath_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Parameters";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Path :";
            // 
            // TXT_DataSavePath
            // 
            this.TXT_DataSavePath.Location = new System.Drawing.Point(85, 39);
            this.TXT_DataSavePath.Name = "TXT_DataSavePath";
            this.TXT_DataSavePath.Size = new System.Drawing.Size(255, 25);
            this.TXT_DataSavePath.TabIndex = 7;
            // 
            // BTN_SelectDataPath
            // 
            this.BTN_SelectDataPath.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BTN_SelectDataPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SelectDataPath.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BTN_SelectDataPath.Location = new System.Drawing.Point(346, 41);
            this.BTN_SelectDataPath.Name = "BTN_SelectDataPath";
            this.BTN_SelectDataPath.Size = new System.Drawing.Size(30, 23);
            this.BTN_SelectDataPath.TabIndex = 8;
            this.BTN_SelectDataPath.Text = "...";
            this.BTN_SelectDataPath.UseVisualStyleBackColor = false;
            this.BTN_SelectDataPath.Click += new System.EventHandler(this.BTN_SelectDataPath_Click);
            // 
            // ToggleSwitch_ISO
            // 
            this.ToggleSwitch_ISO.BorderColor = System.Drawing.Color.LightGray;
            this.ToggleSwitch_ISO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleSwitch_ISO.ForeColor = System.Drawing.Color.White;
            this.ToggleSwitch_ISO.IsOn = false;
            this.ToggleSwitch_ISO.Location = new System.Drawing.Point(122, 30);
            this.ToggleSwitch_ISO.Name = "ToggleSwitch_ISO";
            this.ToggleSwitch_ISO.OffColor = System.Drawing.Color.DarkGray;
            this.ToggleSwitch_ISO.OffText = "OFF";
            this.ToggleSwitch_ISO.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ToggleSwitch_ISO.OnText = "ON";
            this.ToggleSwitch_ISO.Size = new System.Drawing.Size(58, 31);
            this.ToggleSwitch_ISO.TabIndex = 7;
            this.ToggleSwitch_ISO.Text = "myToggleSwitch1";
            this.ToggleSwitch_ISO.TextEnabled = true;
            // 
            // Form_SystemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(636, 537);
            this.Controls.Add(this.TabControl_Main);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_SystemSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Forn_SystemSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_SystemSetting_FormClosing);
            this.TabControl_Main.ResumeLayout(false);
            this.TabPage_UISetting.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Chart_RowNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Chart_ColumnNumber)).EndInit();
            this.TabPage_Mqtt.ResumeLayout(false);
            this.TablePanel_MqttClient.ResumeLayout(false);
            this.Panel_MqttClientList.ResumeLayout(false);
            this.Panel_ClientInfo.ResumeLayout(false);
            this.Panel_ClientInfo.PerformLayout();
            this.Panel_MqttSetting.ResumeLayout(false);
            this.Panel_MqttSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_MqttPort)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl_Main;
        private System.Windows.Forms.TabPage TabPage_Mqtt;
        private System.Windows.Forms.TabPage TabPage_UISetting;
        private System.Windows.Forms.TableLayoutPanel TablePanel_MqttClient;
        private System.Windows.Forms.Panel Panel_MqttClientList;
        private System.Windows.Forms.ListBox ListBox_ClientList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Panel_MqttSetting;
        private System.Windows.Forms.Button BTN_CancelMqttParam;
        private System.Windows.Forms.Button BTN_SaveMqttParameter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NUM_MqttPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXT_MqttServerIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Panel_ClientInfo;
        private System.Windows.Forms.Label LAB_MqttClientConnectTime;
        private System.Windows.Forms.Label LAB_MqttClientID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel Panel_MqttClientTopics;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_CancelChartSetting;
        private System.Windows.Forms.Button BTN_SaveChartSetting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NUM_Chart_RowNumber;
        private System.Windows.Forms.NumericUpDown NUM_Chart_ColumnNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTN_CancelFuncionsSetting;
        private System.Windows.Forms.Button BTN_SaveFunctionEnable;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private USC_ModulePart.MyToggleSwitch ToggleSwitch_ISO;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BTN_SelectDataPath;
        private System.Windows.Forms.TextBox TXT_DataSavePath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BTN_CancelPathSetting;
        private System.Windows.Forms.Button BTN_SavePath;
        private System.Windows.Forms.Label label12;
    }
}