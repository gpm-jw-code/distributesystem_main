﻿
namespace DistributedSystem_Main
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayout_WholeView = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout_SideBar = new System.Windows.Forms.TableLayoutPanel();
            this.PictureBox_Icon = new System.Windows.Forms.PictureBox();
            this.panMenu = new System.Windows.Forms.Panel();
            this.panStatus = new System.Windows.Forms.Panel();
            this.btnStatus = new System.Windows.Forms.Button();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.panLog = new System.Windows.Forms.Panel();
            this.btnLog = new System.Windows.Forms.Button();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.Panel_RawData = new System.Windows.Forms.Panel();
            this.BTN_RawData = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.picbOFF = new System.Windows.Forms.PictureBox();
            this.picbRestart = new System.Windows.Forms.PictureBox();
            this.TabControl_Main = new DistributedSystem_Main.User_Control.TabControlEx();
            this.TabPage_Signal = new System.Windows.Forms.TabPage();
            this.TablePanel_SignalChart = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_Signals_Function = new System.Windows.Forms.Panel();
            this.PageSwitch_Signals = new DistributedSystem_Main.User_Control.PageSwitch();
            this.TabPage_Log = new System.Windows.Forms.TabPage();
            this.TabPage_SensorInfo = new System.Windows.Forms.TabPage();
            this.DGV_SensorInfo = new System.Windows.Forms.DataGridView();
            this.Column_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SensorType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel_EditSensorInfo = new System.Windows.Forms.Panel();
            this.BTN_CancelEditSensorInfo = new System.Windows.Forms.Button();
            this.BTN_SaveSensorInfo = new System.Windows.Forms.Button();
            this.BTN_EditSensorInfo = new System.Windows.Forms.Button();
            this.TablePanel_SideBarFunctions = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_OpenSystemSetting = new System.Windows.Forms.Button();
            this.TableLayout_WholeView.SuspendLayout();
            this.TableLayout_SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Icon)).BeginInit();
            this.panMenu.SuspendLayout();
            this.panStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.panLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            this.Panel_RawData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbRestart)).BeginInit();
            this.TabControl_Main.SuspendLayout();
            this.TabPage_Signal.SuspendLayout();
            this.Panel_Signals_Function.SuspendLayout();
            this.TabPage_SensorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SensorInfo)).BeginInit();
            this.Panel_EditSensorInfo.SuspendLayout();
            this.TablePanel_SideBarFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout_WholeView
            // 
            this.TableLayout_WholeView.ColumnCount = 2;
            this.TableLayout_WholeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.TableLayout_WholeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout_WholeView.Controls.Add(this.TableLayout_SideBar, 0, 0);
            this.TableLayout_WholeView.Controls.Add(this.TabControl_Main, 1, 0);
            this.TableLayout_WholeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout_WholeView.Location = new System.Drawing.Point(0, 0);
            this.TableLayout_WholeView.Name = "TableLayout_WholeView";
            this.TableLayout_WholeView.RowCount = 1;
            this.TableLayout_WholeView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout_WholeView.Size = new System.Drawing.Size(1354, 710);
            this.TableLayout_WholeView.TabIndex = 9;
            // 
            // TableLayout_SideBar
            // 
            this.TableLayout_SideBar.ColumnCount = 1;
            this.TableLayout_SideBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout_SideBar.Controls.Add(this.PictureBox_Icon, 0, 0);
            this.TableLayout_SideBar.Controls.Add(this.panMenu, 0, 1);
            this.TableLayout_SideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout_SideBar.Location = new System.Drawing.Point(0, 0);
            this.TableLayout_SideBar.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayout_SideBar.Name = "TableLayout_SideBar";
            this.TableLayout_SideBar.RowCount = 2;
            this.TableLayout_SideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.TableLayout_SideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout_SideBar.Size = new System.Drawing.Size(170, 710);
            this.TableLayout_SideBar.TabIndex = 7;
            // 
            // PictureBox_Icon
            // 
            this.PictureBox_Icon.BackColor = System.Drawing.Color.White;
            this.PictureBox_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox_Icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox_Icon.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Icon.Image")));
            this.PictureBox_Icon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox_Icon.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_Icon.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBox_Icon.Name = "PictureBox_Icon";
            this.PictureBox_Icon.Size = new System.Drawing.Size(170, 130);
            this.PictureBox_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_Icon.TabIndex = 4;
            this.PictureBox_Icon.TabStop = false;
            // 
            // panMenu
            // 
            this.panMenu.AutoSize = true;
            this.panMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.panMenu.Controls.Add(this.panStatus);
            this.panMenu.Controls.Add(this.panLog);
            this.panMenu.Controls.Add(this.Panel_RawData);
            this.panMenu.Controls.Add(this.tableLayoutPanel2);
            this.panMenu.Controls.Add(this.TablePanel_SideBarFunctions);
            this.panMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMenu.Location = new System.Drawing.Point(0, 130);
            this.panMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(170, 580);
            this.panMenu.TabIndex = 6;
            // 
            // panStatus
            // 
            this.panStatus.Controls.Add(this.btnStatus);
            this.panStatus.Controls.Add(this.pictureBox20);
            this.panStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panStatus.Location = new System.Drawing.Point(0, 113);
            this.panStatus.Margin = new System.Windows.Forms.Padding(4);
            this.panStatus.Name = "panStatus";
            this.panStatus.Size = new System.Drawing.Size(170, 41);
            this.panStatus.TabIndex = 2;
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.Transparent;
            this.btnStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnStatus.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(135)))));
            this.btnStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.btnStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatus.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStatus.ForeColor = System.Drawing.Color.White;
            this.btnStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStatus.Location = new System.Drawing.Point(30, 0);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(140, 41);
            this.btnStatus.TabIndex = 1;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // pictureBox20
            // 
            this.pictureBox20.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox20.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox20.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox20.Image")));
            this.pictureBox20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox20.Location = new System.Drawing.Point(0, 0);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(30, 41);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox20.TabIndex = 25;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Tag = "TabPageModuleManager";
            // 
            // panLog
            // 
            this.panLog.Controls.Add(this.btnLog);
            this.panLog.Controls.Add(this.pictureBox19);
            this.panLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panLog.Location = new System.Drawing.Point(0, 72);
            this.panLog.Margin = new System.Windows.Forms.Padding(4);
            this.panLog.Name = "panLog";
            this.panLog.Size = new System.Drawing.Size(170, 41);
            this.panLog.TabIndex = 4;
            // 
            // btnLog
            // 
            this.btnLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnLog.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(135)))));
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLog.Location = new System.Drawing.Point(30, 0);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(140, 41);
            this.btnLog.TabIndex = 1;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // pictureBox19
            // 
            this.pictureBox19.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox19.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox19.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox19.Image")));
            this.pictureBox19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox19.Location = new System.Drawing.Point(0, 0);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(30, 41);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox19.TabIndex = 18;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Tag = "TabPageLOG";
            // 
            // Panel_RawData
            // 
            this.Panel_RawData.Controls.Add(this.BTN_RawData);
            this.Panel_RawData.Controls.Add(this.pictureBox2);
            this.Panel_RawData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Panel_RawData.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_RawData.Location = new System.Drawing.Point(0, 31);
            this.Panel_RawData.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_RawData.Name = "Panel_RawData";
            this.Panel_RawData.Size = new System.Drawing.Size(170, 41);
            this.Panel_RawData.TabIndex = 6;
            // 
            // BTN_RawData
            // 
            this.BTN_RawData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_RawData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.BTN_RawData.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(135)))));
            this.BTN_RawData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.BTN_RawData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.BTN_RawData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RawData.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.BTN_RawData.ForeColor = System.Drawing.Color.White;
            this.BTN_RawData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BTN_RawData.Location = new System.Drawing.Point(30, 0);
            this.BTN_RawData.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_RawData.Name = "BTN_RawData";
            this.BTN_RawData.Size = new System.Drawing.Size(140, 41);
            this.BTN_RawData.TabIndex = 1;
            this.BTN_RawData.Text = "Raw Data";
            this.BTN_RawData.UseVisualStyleBackColor = true;
            this.BTN_RawData.Click += new System.EventHandler(this.BTN_RawData_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "TabPageHOME";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33533F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33233F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33233F));
            this.tableLayoutPanel2.Controls.Add(this.picbOFF, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.picbRestart, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 506);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(170, 74);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // picbOFF
            // 
            this.picbOFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbOFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbOFF.Image = ((System.Drawing.Image)(resources.GetObject("picbOFF.Image")));
            this.picbOFF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbOFF.Location = new System.Drawing.Point(4, 4);
            this.picbOFF.Margin = new System.Windows.Forms.Padding(4);
            this.picbOFF.Name = "picbOFF";
            this.picbOFF.Size = new System.Drawing.Size(48, 66);
            this.picbOFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbOFF.TabIndex = 0;
            this.picbOFF.TabStop = false;
            this.picbOFF.Click += new System.EventHandler(this.picbOFF_Click);
            // 
            // picbRestart
            // 
            this.picbRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbRestart.Image = ((System.Drawing.Image)(resources.GetObject("picbRestart.Image")));
            this.picbRestart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbRestart.Location = new System.Drawing.Point(116, 4);
            this.picbRestart.Margin = new System.Windows.Forms.Padding(4);
            this.picbRestart.Name = "picbRestart";
            this.picbRestart.Size = new System.Drawing.Size(47, 65);
            this.picbRestart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbRestart.TabIndex = 1;
            this.picbRestart.TabStop = false;
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControl_Main.Controls.Add(this.TabPage_Signal);
            this.TabControl_Main.Controls.Add(this.TabPage_Log);
            this.TabControl_Main.Controls.Add(this.TabPage_SensorInfo);
            this.TabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Main.ItemSize = new System.Drawing.Size(50, 0);
            this.TabControl_Main.Location = new System.Drawing.Point(170, 0);
            this.TabControl_Main.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.Padding = new System.Drawing.Point(6, 0);
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(1184, 710);
            this.TabControl_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl_Main.TabIndex = 5;
            // 
            // TabPage_Signal
            // 
            this.TabPage_Signal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.TabPage_Signal.Controls.Add(this.TablePanel_SignalChart);
            this.TabPage_Signal.Controls.Add(this.Panel_Signals_Function);
            this.TabPage_Signal.Location = new System.Drawing.Point(-1, 22);
            this.TabPage_Signal.Margin = new System.Windows.Forms.Padding(4);
            this.TabPage_Signal.Name = "TabPage_Signal";
            this.TabPage_Signal.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage_Signal.Size = new System.Drawing.Size(1186, 689);
            this.TabPage_Signal.TabIndex = 1;
            this.TabPage_Signal.Text = "Signal";
            // 
            // TablePanel_SignalChart
            // 
            this.TablePanel_SignalChart.AutoScroll = true;
            this.TablePanel_SignalChart.AutoSize = true;
            this.TablePanel_SignalChart.ColumnCount = 2;
            this.TablePanel_SignalChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanel_SignalChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanel_SignalChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablePanel_SignalChart.Location = new System.Drawing.Point(4, 47);
            this.TablePanel_SignalChart.Margin = new System.Windows.Forms.Padding(4);
            this.TablePanel_SignalChart.Name = "TablePanel_SignalChart";
            this.TablePanel_SignalChart.RowCount = 3;
            this.TablePanel_SignalChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_SignalChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_SignalChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_SignalChart.Size = new System.Drawing.Size(1178, 638);
            this.TablePanel_SignalChart.TabIndex = 0;
            // 
            // Panel_Signals_Function
            // 
            this.Panel_Signals_Function.Controls.Add(this.PageSwitch_Signals);
            this.Panel_Signals_Function.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Signals_Function.Location = new System.Drawing.Point(4, 4);
            this.Panel_Signals_Function.Name = "Panel_Signals_Function";
            this.Panel_Signals_Function.Size = new System.Drawing.Size(1178, 43);
            this.Panel_Signals_Function.TabIndex = 1;
            // 
            // PageSwitch_Signals
            // 
            this.PageSwitch_Signals.AutoSize = true;
            this.PageSwitch_Signals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(131)))), ((int)(((byte)(169)))));
            this.PageSwitch_Signals.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PageSwitch_Signals.Location = new System.Drawing.Point(4, 8);
            this.PageSwitch_Signals.Margin = new System.Windows.Forms.Padding(4);
            this.PageSwitch_Signals.MinimumSize = new System.Drawing.Size(0, 27);
            this.PageSwitch_Signals.Name = "PageSwitch_Signals";
            this.PageSwitch_Signals.NowPageNumber = 1;
            this.PageSwitch_Signals.Size = new System.Drawing.Size(92, 27);
            this.PageSwitch_Signals.TabIndex = 0;
            // 
            // TabPage_Log
            // 
            this.TabPage_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.TabPage_Log.Location = new System.Drawing.Point(-1, 22);
            this.TabPage_Log.Margin = new System.Windows.Forms.Padding(4);
            this.TabPage_Log.Name = "TabPage_Log";
            this.TabPage_Log.Size = new System.Drawing.Size(1186, 689);
            this.TabPage_Log.TabIndex = 2;
            this.TabPage_Log.Text = "Log";
            // 
            // TabPage_SensorInfo
            // 
            this.TabPage_SensorInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.TabPage_SensorInfo.Controls.Add(this.DGV_SensorInfo);
            this.TabPage_SensorInfo.Controls.Add(this.Panel_EditSensorInfo);
            this.TabPage_SensorInfo.Location = new System.Drawing.Point(-1, 22);
            this.TabPage_SensorInfo.Name = "TabPage_SensorInfo";
            this.TabPage_SensorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_SensorInfo.Size = new System.Drawing.Size(1186, 689);
            this.TabPage_SensorInfo.TabIndex = 4;
            this.TabPage_SensorInfo.Text = "SensorInfo";
            // 
            // DGV_SensorInfo
            // 
            this.DGV_SensorInfo.AllowUserToAddRows = false;
            this.DGV_SensorInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.DGV_SensorInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SensorInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Status,
            this.EQName,
            this.UnitName,
            this.SensorIP,
            this.Column_SensorType});
            this.DGV_SensorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_SensorInfo.Location = new System.Drawing.Point(3, 46);
            this.DGV_SensorInfo.Name = "DGV_SensorInfo";
            this.DGV_SensorInfo.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.DGV_SensorInfo.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_SensorInfo.RowTemplate.Height = 24;
            this.DGV_SensorInfo.ShowCellErrors = false;
            this.DGV_SensorInfo.Size = new System.Drawing.Size(1180, 640);
            this.DGV_SensorInfo.TabIndex = 1;
            // 
            // Column_Status
            // 
            this.Column_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Status.HeaderText = "Status";
            this.Column_Status.Name = "Column_Status";
            this.Column_Status.ReadOnly = true;
            this.Column_Status.Width = 71;
            // 
            // EQName
            // 
            this.EQName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EQName.HeaderText = "EQ Name";
            this.EQName.Name = "EQName";
            this.EQName.ReadOnly = true;
            // 
            // UnitName
            // 
            this.UnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnitName.HeaderText = "Unit Name";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            // 
            // SensorIP
            // 
            this.SensorIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SensorIP.HeaderText = "Sensor IP";
            this.SensorIP.Name = "SensorIP";
            this.SensorIP.ReadOnly = true;
            // 
            // Column_SensorType
            // 
            this.Column_SensorType.HeaderText = "SensorType";
            this.Column_SensorType.Name = "Column_SensorType";
            this.Column_SensorType.ReadOnly = true;
            // 
            // Panel_EditSensorInfo
            // 
            this.Panel_EditSensorInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.Panel_EditSensorInfo.Controls.Add(this.BTN_CancelEditSensorInfo);
            this.Panel_EditSensorInfo.Controls.Add(this.BTN_SaveSensorInfo);
            this.Panel_EditSensorInfo.Controls.Add(this.BTN_EditSensorInfo);
            this.Panel_EditSensorInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_EditSensorInfo.Location = new System.Drawing.Point(3, 3);
            this.Panel_EditSensorInfo.Name = "Panel_EditSensorInfo";
            this.Panel_EditSensorInfo.Size = new System.Drawing.Size(1180, 43);
            this.Panel_EditSensorInfo.TabIndex = 2;
            // 
            // BTN_CancelEditSensorInfo
            // 
            this.BTN_CancelEditSensorInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_CancelEditSensorInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_CancelEditSensorInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CancelEditSensorInfo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.BTN_CancelEditSensorInfo.Location = new System.Drawing.Point(139, 7);
            this.BTN_CancelEditSensorInfo.Name = "BTN_CancelEditSensorInfo";
            this.BTN_CancelEditSensorInfo.Size = new System.Drawing.Size(60, 30);
            this.BTN_CancelEditSensorInfo.TabIndex = 0;
            this.BTN_CancelEditSensorInfo.Text = "Cancel";
            this.BTN_CancelEditSensorInfo.UseVisualStyleBackColor = false;
            this.BTN_CancelEditSensorInfo.Visible = false;
            // 
            // BTN_SaveSensorInfo
            // 
            this.BTN_SaveSensorInfo.BackColor = System.Drawing.Color.PaleGreen;
            this.BTN_SaveSensorInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SaveSensorInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SaveSensorInfo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.BTN_SaveSensorInfo.Location = new System.Drawing.Point(73, 7);
            this.BTN_SaveSensorInfo.Name = "BTN_SaveSensorInfo";
            this.BTN_SaveSensorInfo.Size = new System.Drawing.Size(60, 30);
            this.BTN_SaveSensorInfo.TabIndex = 0;
            this.BTN_SaveSensorInfo.Text = "Save";
            this.BTN_SaveSensorInfo.UseVisualStyleBackColor = false;
            this.BTN_SaveSensorInfo.Visible = false;
            this.BTN_SaveSensorInfo.Click += new System.EventHandler(this.BTN_SaveSensorInfo_Click);
            // 
            // BTN_EditSensorInfo
            // 
            this.BTN_EditSensorInfo.BackColor = System.Drawing.Color.Honeydew;
            this.BTN_EditSensorInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_EditSensorInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_EditSensorInfo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.BTN_EditSensorInfo.Location = new System.Drawing.Point(7, 7);
            this.BTN_EditSensorInfo.Name = "BTN_EditSensorInfo";
            this.BTN_EditSensorInfo.Size = new System.Drawing.Size(60, 30);
            this.BTN_EditSensorInfo.TabIndex = 0;
            this.BTN_EditSensorInfo.Text = "Edit";
            this.BTN_EditSensorInfo.UseVisualStyleBackColor = false;
            this.BTN_EditSensorInfo.Click += new System.EventHandler(this.BTN_EditSensorInfo_Click);
            // 
            // TablePanel_SideBarFunctions
            // 
            this.TablePanel_SideBarFunctions.ColumnCount = 5;
            this.TablePanel_SideBarFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TablePanel_SideBarFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TablePanel_SideBarFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TablePanel_SideBarFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TablePanel_SideBarFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TablePanel_SideBarFunctions.Controls.Add(this.BTN_OpenSystemSetting, 0, 0);
            this.TablePanel_SideBarFunctions.Dock = System.Windows.Forms.DockStyle.Top;
            this.TablePanel_SideBarFunctions.Location = new System.Drawing.Point(0, 0);
            this.TablePanel_SideBarFunctions.Margin = new System.Windows.Forms.Padding(4);
            this.TablePanel_SideBarFunctions.Name = "TablePanel_SideBarFunctions";
            this.TablePanel_SideBarFunctions.RowCount = 1;
            this.TablePanel_SideBarFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablePanel_SideBarFunctions.Size = new System.Drawing.Size(170, 31);
            this.TablePanel_SideBarFunctions.TabIndex = 1;
            // 
            // BTN_OpenSystemSetting
            // 
            this.BTN_OpenSystemSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_OpenSystemSetting.BackgroundImage")));
            this.BTN_OpenSystemSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_OpenSystemSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_OpenSystemSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_OpenSystemSetting.FlatAppearance.BorderSize = 0;
            this.BTN_OpenSystemSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OpenSystemSetting.Location = new System.Drawing.Point(3, 3);
            this.BTN_OpenSystemSetting.Name = "BTN_OpenSystemSetting";
            this.BTN_OpenSystemSetting.Size = new System.Drawing.Size(28, 25);
            this.BTN_OpenSystemSetting.TabIndex = 0;
            this.BTN_OpenSystemSetting.UseVisualStyleBackColor = true;
            this.BTN_OpenSystemSetting.Click += new System.EventHandler(this.BTN_OpenSystemSetting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1354, 710);
            this.Controls.Add(this.TableLayout_WholeView);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Control Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.TableLayout_WholeView.ResumeLayout(false);
            this.TableLayout_SideBar.ResumeLayout(false);
            this.TableLayout_SideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Icon)).EndInit();
            this.panMenu.ResumeLayout(false);
            this.panStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.panLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            this.Panel_RawData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbRestart)).EndInit();
            this.TabControl_Main.ResumeLayout(false);
            this.TabPage_Signal.ResumeLayout(false);
            this.TabPage_Signal.PerformLayout();
            this.Panel_Signals_Function.ResumeLayout(false);
            this.Panel_Signals_Function.PerformLayout();
            this.TabPage_SensorInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SensorInfo)).EndInit();
            this.Panel_EditSensorInfo.ResumeLayout(false);
            this.TablePanel_SideBarFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout_WholeView;
        private System.Windows.Forms.TableLayoutPanel TableLayout_SideBar;
        private System.Windows.Forms.PictureBox PictureBox_Icon;
        private System.Windows.Forms.Panel panMenu;
        private System.Windows.Forms.Panel panStatus;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.Panel panLog;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.Panel Panel_RawData;
        private System.Windows.Forms.Button BTN_RawData;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox picbOFF;
        private System.Windows.Forms.PictureBox picbRestart;
        private User_Control.TabControlEx TabControl_Main;
        private System.Windows.Forms.TabPage TabPage_Signal;
        private System.Windows.Forms.TableLayoutPanel TablePanel_SignalChart;
        private System.Windows.Forms.TabPage TabPage_Log;
        private System.Windows.Forms.TabPage TabPage_SensorInfo;
        private System.Windows.Forms.DataGridView DGV_SensorInfo;
        private System.Windows.Forms.Panel Panel_EditSensorInfo;
        private System.Windows.Forms.Button BTN_CancelEditSensorInfo;
        private System.Windows.Forms.Button BTN_SaveSensorInfo;
        private System.Windows.Forms.Button BTN_EditSensorInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SensorType;
        private System.Windows.Forms.Panel Panel_Signals_Function;
        private User_Control.PageSwitch PageSwitch_Signals;
        private System.Windows.Forms.TableLayoutPanel TablePanel_SideBarFunctions;
        private System.Windows.Forms.Button BTN_OpenSystemSetting;
    }
}

