
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
            this.TableLayout_WholeView = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout_SideBar = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panMenu = new System.Windows.Forms.Panel();
            this.panStatus = new System.Windows.Forms.Panel();
            this.btnStatus = new System.Windows.Forms.Button();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.panLog = new System.Windows.Forms.Panel();
            this.btnLog = new System.Windows.Forms.Button();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.Panel_Environment = new System.Windows.Forms.Panel();
            this.BTN_RawData = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.picbOFF = new System.Windows.Forms.PictureBox();
            this.picbRestart = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picbExpand = new System.Windows.Forms.PictureBox();
            this.picbMinimun = new System.Windows.Forms.PictureBox();
            this.picbCaptureScreen = new System.Windows.Forms.PictureBox();
            this.picbSizableTool = new System.Windows.Forms.PictureBox();
            this.TabControl_Main = new System.Windows.Forms.TabControl();
            this.TabPage_Signal = new System.Windows.Forms.TabPage();
            this.TablePanel_SignalChart = new System.Windows.Forms.TableLayoutPanel();
            this.TabPage_Log = new System.Windows.Forms.TabPage();
            this.TabPage_SensorInfo = new System.Windows.Forms.TabPage();
            this.DGV_SensorInfo = new System.Windows.Forms.DataGridView();
            this.Column_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SensorType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel_EditSensorInfo = new System.Windows.Forms.Panel();
            this.TableLayout_WholeView.SuspendLayout();
            this.TableLayout_SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panMenu.SuspendLayout();
            this.panStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.panLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            this.Panel_Environment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbRestart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbExpand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbMinimun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbCaptureScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbSizableTool)).BeginInit();
            this.TabControl_Main.SuspendLayout();
            this.TabPage_Signal.SuspendLayout();
            this.TabPage_SensorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SensorInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayout_WholeView
            // 
            this.TableLayout_WholeView.ColumnCount = 2;
            this.TableLayout_WholeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.3125F));
            this.TableLayout_WholeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.6875F));
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
            this.TableLayout_SideBar.Controls.Add(this.pictureBox1, 0, 0);
            this.TableLayout_SideBar.Controls.Add(this.panMenu, 0, 1);
            this.TableLayout_SideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout_SideBar.Location = new System.Drawing.Point(3, 3);
            this.TableLayout_SideBar.Name = "TableLayout_SideBar";
            this.TableLayout_SideBar.RowCount = 2;
            this.TableLayout_SideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.62745F));
            this.TableLayout_SideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.37255F));
            this.TableLayout_SideBar.Size = new System.Drawing.Size(201, 704);
            this.TableLayout_SideBar.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panMenu
            // 
            this.panMenu.AutoSize = true;
            this.panMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.panMenu.Controls.Add(this.panStatus);
            this.panMenu.Controls.Add(this.panLog);
            this.panMenu.Controls.Add(this.Panel_Environment);
            this.panMenu.Controls.Add(this.tableLayoutPanel2);
            this.panMenu.Controls.Add(this.tableLayoutPanel1);
            this.panMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMenu.Location = new System.Drawing.Point(4, 135);
            this.panMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(193, 565);
            this.panMenu.TabIndex = 6;
            // 
            // panStatus
            // 
            this.panStatus.Controls.Add(this.btnStatus);
            this.panStatus.Controls.Add(this.pictureBox20);
            this.panStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panStatus.Location = new System.Drawing.Point(0, 113);
            this.panStatus.Margin = new System.Windows.Forms.Padding(4);
            this.panStatus.Name = "panStatus";
            this.panStatus.Size = new System.Drawing.Size(193, 41);
            this.panStatus.TabIndex = 2;
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.btnStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnStatus.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(135)))));
            this.btnStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.btnStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(108)))));
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatus.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStatus.ForeColor = System.Drawing.Color.White;
            this.btnStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStatus.Location = new System.Drawing.Point(40, 0);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(153, 41);
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
            this.pictureBox20.Size = new System.Drawing.Size(40, 41);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox20.TabIndex = 25;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Tag = "TabPageModuleManager";
            // 
            // panLog
            // 
            this.panLog.Controls.Add(this.btnLog);
            this.panLog.Controls.Add(this.pictureBox19);
            this.panLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panLog.Location = new System.Drawing.Point(0, 72);
            this.panLog.Margin = new System.Windows.Forms.Padding(4);
            this.panLog.Name = "panLog";
            this.panLog.Size = new System.Drawing.Size(193, 41);
            this.panLog.TabIndex = 4;
            // 
            // btnLog
            // 
            this.btnLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnLog.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(135)))));
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(108)))));
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLog.Location = new System.Drawing.Point(40, 0);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(153, 41);
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
            this.pictureBox19.Size = new System.Drawing.Size(40, 41);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox19.TabIndex = 18;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Tag = "TabPageLOG";
            // 
            // Panel_Environment
            // 
            this.Panel_Environment.Controls.Add(this.BTN_RawData);
            this.Panel_Environment.Controls.Add(this.pictureBox2);
            this.Panel_Environment.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Environment.Location = new System.Drawing.Point(0, 31);
            this.Panel_Environment.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Environment.Name = "Panel_Environment";
            this.Panel_Environment.Size = new System.Drawing.Size(193, 41);
            this.Panel_Environment.TabIndex = 6;
            // 
            // BTN_RawData
            // 
            this.BTN_RawData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_RawData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.BTN_RawData.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(135)))));
            this.BTN_RawData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.BTN_RawData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(108)))));
            this.BTN_RawData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RawData.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.BTN_RawData.ForeColor = System.Drawing.Color.White;
            this.BTN_RawData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BTN_RawData.Location = new System.Drawing.Point(40, 0);
            this.BTN_RawData.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_RawData.Name = "BTN_RawData";
            this.BTN_RawData.Size = new System.Drawing.Size(153, 41);
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
            this.pictureBox2.Size = new System.Drawing.Size(40, 41);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 491);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(193, 74);
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
            this.picbOFF.Size = new System.Drawing.Size(56, 66);
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
            this.picbRestart.Location = new System.Drawing.Point(132, 4);
            this.picbRestart.Margin = new System.Windows.Forms.Padding(4);
            this.picbRestart.Name = "picbRestart";
            this.picbRestart.Size = new System.Drawing.Size(54, 65);
            this.picbRestart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbRestart.TabIndex = 1;
            this.picbRestart.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.picbExpand, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picbMinimun, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picbCaptureScreen, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.picbSizableTool, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 31);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // picbExpand
            // 
            this.picbExpand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbExpand.Image = ((System.Drawing.Image)(resources.GetObject("picbExpand.Image")));
            this.picbExpand.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbExpand.Location = new System.Drawing.Point(4, 4);
            this.picbExpand.Margin = new System.Windows.Forms.Padding(4);
            this.picbExpand.Name = "picbExpand";
            this.picbExpand.Size = new System.Drawing.Size(30, 23);
            this.picbExpand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbExpand.TabIndex = 0;
            this.picbExpand.TabStop = false;
            // 
            // picbMinimun
            // 
            this.picbMinimun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbMinimun.Image = ((System.Drawing.Image)(resources.GetObject("picbMinimun.Image")));
            this.picbMinimun.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbMinimun.Location = new System.Drawing.Point(42, 4);
            this.picbMinimun.Margin = new System.Windows.Forms.Padding(4);
            this.picbMinimun.Name = "picbMinimun";
            this.picbMinimun.Size = new System.Drawing.Size(30, 23);
            this.picbMinimun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbMinimun.TabIndex = 1;
            this.picbMinimun.TabStop = false;
            // 
            // picbCaptureScreen
            // 
            this.picbCaptureScreen.Image = ((System.Drawing.Image)(resources.GetObject("picbCaptureScreen.Image")));
            this.picbCaptureScreen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbCaptureScreen.Location = new System.Drawing.Point(118, 4);
            this.picbCaptureScreen.Margin = new System.Windows.Forms.Padding(4);
            this.picbCaptureScreen.Name = "picbCaptureScreen";
            this.picbCaptureScreen.Size = new System.Drawing.Size(30, 23);
            this.picbCaptureScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbCaptureScreen.TabIndex = 2;
            this.picbCaptureScreen.TabStop = false;
            // 
            // picbSizableTool
            // 
            this.picbSizableTool.Image = ((System.Drawing.Image)(resources.GetObject("picbSizableTool.Image")));
            this.picbSizableTool.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbSizableTool.Location = new System.Drawing.Point(80, 4);
            this.picbSizableTool.Margin = new System.Windows.Forms.Padding(4);
            this.picbSizableTool.Name = "picbSizableTool";
            this.picbSizableTool.Size = new System.Drawing.Size(30, 23);
            this.picbSizableTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbSizableTool.TabIndex = 3;
            this.picbSizableTool.TabStop = false;
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_Main.Controls.Add(this.TabPage_Signal);
            this.TabControl_Main.Controls.Add(this.TabPage_Log);
            this.TabControl_Main.Controls.Add(this.TabPage_SensorInfo);
            this.TabControl_Main.ItemSize = new System.Drawing.Size(50, 0);
            this.TabControl_Main.Location = new System.Drawing.Point(211, 4);
            this.TabControl_Main.Margin = new System.Windows.Forms.Padding(4);
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.Padding = new System.Drawing.Point(6, 0);
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(1139, 702);
            this.TabControl_Main.TabIndex = 5;
            // 
            // TabPage_Signal
            // 
            this.TabPage_Signal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(72)))), ((int)(((byte)(93)))));
            this.TabPage_Signal.Controls.Add(this.TablePanel_SignalChart);
            this.TabPage_Signal.Location = new System.Drawing.Point(4, 24);
            this.TabPage_Signal.Margin = new System.Windows.Forms.Padding(4);
            this.TabPage_Signal.Name = "TabPage_Signal";
            this.TabPage_Signal.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage_Signal.Size = new System.Drawing.Size(1131, 674);
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
            this.TablePanel_SignalChart.Location = new System.Drawing.Point(4, 4);
            this.TablePanel_SignalChart.Margin = new System.Windows.Forms.Padding(4);
            this.TablePanel_SignalChart.Name = "TablePanel_SignalChart";
            this.TablePanel_SignalChart.RowCount = 3;
            this.TablePanel_SignalChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_SignalChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_SignalChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_SignalChart.Size = new System.Drawing.Size(1123, 666);
            this.TablePanel_SignalChart.TabIndex = 0;
            // 
            // TabPage_Log
            // 
            this.TabPage_Log.Location = new System.Drawing.Point(4, 24);
            this.TabPage_Log.Margin = new System.Windows.Forms.Padding(4);
            this.TabPage_Log.Name = "TabPage_Log";
            this.TabPage_Log.Size = new System.Drawing.Size(1131, 674);
            this.TabPage_Log.TabIndex = 2;
            this.TabPage_Log.Text = "Log";
            this.TabPage_Log.UseVisualStyleBackColor = true;
            // 
            // TabPage_SensorInfo
            // 
            this.TabPage_SensorInfo.Controls.Add(this.DGV_SensorInfo);
            this.TabPage_SensorInfo.Controls.Add(this.Panel_EditSensorInfo);
            this.TabPage_SensorInfo.Location = new System.Drawing.Point(4, 24);
            this.TabPage_SensorInfo.Name = "TabPage_SensorInfo";
            this.TabPage_SensorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_SensorInfo.Size = new System.Drawing.Size(1131, 674);
            this.TabPage_SensorInfo.TabIndex = 4;
            this.TabPage_SensorInfo.Text = "SensorInfo";
            this.TabPage_SensorInfo.UseVisualStyleBackColor = true;
            // 
            // DGV_SensorInfo
            // 
            this.DGV_SensorInfo.AllowUserToAddRows = false;
            this.DGV_SensorInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.DGV_SensorInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SensorInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Status,
            this.EQName,
            this.UnitName,
            this.SensorIP,
            this.Column_SensorType});
            this.DGV_SensorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_SensorInfo.Location = new System.Drawing.Point(3, 59);
            this.DGV_SensorInfo.Name = "DGV_SensorInfo";
            this.DGV_SensorInfo.ReadOnly = true;
            this.DGV_SensorInfo.RowHeadersVisible = false;
            this.DGV_SensorInfo.RowTemplate.Height = 24;
            this.DGV_SensorInfo.ShowCellErrors = false;
            this.DGV_SensorInfo.Size = new System.Drawing.Size(1125, 612);
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
            this.Panel_EditSensorInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_EditSensorInfo.Location = new System.Drawing.Point(3, 3);
            this.Panel_EditSensorInfo.Name = "Panel_EditSensorInfo";
            this.Panel_EditSensorInfo.Size = new System.Drawing.Size(1125, 56);
            this.Panel_EditSensorInfo.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 710);
            this.Controls.Add(this.TableLayout_WholeView);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TableLayout_WholeView.ResumeLayout(false);
            this.TableLayout_SideBar.ResumeLayout(false);
            this.TableLayout_SideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panMenu.ResumeLayout(false);
            this.panStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.panLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            this.Panel_Environment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbRestart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbExpand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbMinimun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbCaptureScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbSizableTool)).EndInit();
            this.TabControl_Main.ResumeLayout(false);
            this.TabPage_Signal.ResumeLayout(false);
            this.TabPage_Signal.PerformLayout();
            this.TabPage_SensorInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SensorInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout_WholeView;
        private System.Windows.Forms.TableLayoutPanel TableLayout_SideBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panMenu;
        private System.Windows.Forms.Panel panStatus;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.Panel panLog;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.Panel Panel_Environment;
        private System.Windows.Forms.Button BTN_RawData;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox picbOFF;
        private System.Windows.Forms.PictureBox picbRestart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picbExpand;
        private System.Windows.Forms.PictureBox picbMinimun;
        private System.Windows.Forms.PictureBox picbCaptureScreen;
        private System.Windows.Forms.PictureBox picbSizableTool;
        private System.Windows.Forms.TabControl TabControl_Main;
        private System.Windows.Forms.TabPage TabPage_Signal;
        private System.Windows.Forms.TableLayoutPanel TablePanel_SignalChart;
        private System.Windows.Forms.TabPage TabPage_Log;
        private System.Windows.Forms.TabPage TabPage_SensorInfo;
        private System.Windows.Forms.DataGridView DGV_SensorInfo;
        private System.Windows.Forms.Panel Panel_EditSensorInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SensorType;
    }
}

