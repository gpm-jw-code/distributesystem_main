
namespace DistributedSystem_Main
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayout_WholeView = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout_SideBar = new System.Windows.Forms.TableLayoutPanel();
            this.PictureBox_Icon = new System.Windows.Forms.PictureBox();
            this.panMenu = new System.Windows.Forms.Panel();
            this.Panel_MainArea = new System.Windows.Forms.Panel();
            this.TabControl_Main = new DistributedSystem_Main.User_Control.TabControlEx();
            this.TabPage_Signal = new System.Windows.Forms.TabPage();
            this.TablePanel_SignalChart = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_Signals_Function = new System.Windows.Forms.Panel();
            this.Label_Signals_Filter = new System.Windows.Forms.Label();
            this.TXT_RawDataChartFilter = new System.Windows.Forms.TextBox();
            this.PageSwitch_Signals = new DistributedSystem_Main.User_Control.PageSwitch();
            this.TabPage_Log = new System.Windows.Forms.TabPage();
            this.TabPage_SensorInfo = new System.Windows.Forms.TabPage();
            this.DGV_SensorInfo = new System.Windows.Forms.DataGridView();
            this.Column_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SensorType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ISOSetting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Panel_EditSensorInfo = new System.Windows.Forms.Panel();
            this.BTN_CancelEditSensorInfo = new System.Windows.Forms.Button();
            this.BTN_SaveSensorInfo = new System.Windows.Forms.Button();
            this.BTN_EditSensorInfo = new System.Windows.Forms.Button();
            this.TabPage_ISO = new System.Windows.Forms.TabPage();
            this.TablePanel_ISOChart = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PageSwitch_ISOChart = new DistributedSystem_Main.User_Control.PageSwitch();
            this.Panel_Query = new System.Windows.Forms.Panel();
            this.BTN_Query = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel_ISO = new System.Windows.Forms.Panel();
            this.BTN_ISO = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
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
            this.TablePanel_SideBarFunctions = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_OpenSystemSetting = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TableLayout_WholeView.SuspendLayout();
            this.TableLayout_SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Icon)).BeginInit();
            this.panMenu.SuspendLayout();
            this.Panel_MainArea.SuspendLayout();
            this.TabControl_Main.SuspendLayout();
            this.TabPage_Signal.SuspendLayout();
            this.Panel_Signals_Function.SuspendLayout();
            this.TabPage_SensorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SensorInfo)).BeginInit();
            this.Panel_EditSensorInfo.SuspendLayout();
            this.TabPage_ISO.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel_Query.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panel_ISO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.panLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            this.Panel_RawData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbRestart)).BeginInit();
            this.TablePanel_SideBarFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout_WholeView
            // 
            this.TableLayout_WholeView.ColumnCount = 2;
            this.TableLayout_WholeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.TableLayout_WholeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout_WholeView.Controls.Add(this.TableLayout_SideBar, 0, 0);
            this.TableLayout_WholeView.Controls.Add(this.Panel_MainArea, 1, 0);
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
            this.panMenu.Controls.Add(this.Panel_Query);
            this.panMenu.Controls.Add(this.Panel_ISO);
            this.panMenu.Controls.Add(this.panStatus);
            this.panMenu.Controls.Add(this.panLog);
            this.panMenu.Controls.Add(this.Panel_RawData);
            this.panMenu.Controls.Add(this.tableLayoutPanel2);
            this.panMenu.Controls.Add(this.TablePanel_SideBarFunctions);
            this.panMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMenu.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panMenu.Location = new System.Drawing.Point(0, 130);
            this.panMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(170, 580);
            this.panMenu.TabIndex = 6;
            // 
            // Panel_MainArea
            // 
            this.Panel_MainArea.Controls.Add(this.TabControl_Main);
            this.Panel_MainArea.Controls.Add(this.panel2);
            this.Panel_MainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_MainArea.Location = new System.Drawing.Point(173, 3);
            this.Panel_MainArea.Name = "Panel_MainArea";
            this.Panel_MainArea.Size = new System.Drawing.Size(1178, 704);
            this.Panel_MainArea.TabIndex = 9;
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControl_Main.Controls.Add(this.TabPage_Signal);
            this.TabControl_Main.Controls.Add(this.TabPage_Log);
            this.TabControl_Main.Controls.Add(this.TabPage_SensorInfo);
            this.TabControl_Main.Controls.Add(this.TabPage_ISO);
            this.TabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Main.ItemSize = new System.Drawing.Size(50, 0);
            this.TabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Main.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.Padding = new System.Drawing.Point(6, 0);
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(1178, 669);
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
            this.TabPage_Signal.Size = new System.Drawing.Size(1180, 648);
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
            this.TablePanel_SignalChart.Size = new System.Drawing.Size(1172, 597);
            this.TablePanel_SignalChart.TabIndex = 0;
            // 
            // Panel_Signals_Function
            // 
            this.Panel_Signals_Function.Controls.Add(this.Label_Signals_Filter);
            this.Panel_Signals_Function.Controls.Add(this.TXT_RawDataChartFilter);
            this.Panel_Signals_Function.Controls.Add(this.PageSwitch_Signals);
            this.Panel_Signals_Function.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Signals_Function.Location = new System.Drawing.Point(4, 4);
            this.Panel_Signals_Function.Name = "Panel_Signals_Function";
            this.Panel_Signals_Function.Size = new System.Drawing.Size(1172, 43);
            this.Panel_Signals_Function.TabIndex = 1;
            // 
            // Label_Signals_Filter
            // 
            this.Label_Signals_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Signals_Filter.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.Label_Signals_Filter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(184)))), ((int)(((byte)(192)))));
            this.Label_Signals_Filter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Signals_Filter.Location = new System.Drawing.Point(940, 1);
            this.Label_Signals_Filter.Name = "Label_Signals_Filter";
            this.Label_Signals_Filter.Size = new System.Drawing.Size(67, 37);
            this.Label_Signals_Filter.TabIndex = 18;
            this.Label_Signals_Filter.Text = "篩選：";
            this.Label_Signals_Filter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TXT_RawDataChartFilter
            // 
            this.TXT_RawDataChartFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_RawDataChartFilter.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TXT_RawDataChartFilter.Location = new System.Drawing.Point(1013, 7);
            this.TXT_RawDataChartFilter.Name = "TXT_RawDataChartFilter";
            this.TXT_RawDataChartFilter.Size = new System.Drawing.Size(150, 29);
            this.TXT_RawDataChartFilter.TabIndex = 1;
            this.TXT_RawDataChartFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_RawDataChartFilter_KeyDown);
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
            this.TabPage_Log.Size = new System.Drawing.Size(152, 41);
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
            this.TabPage_SensorInfo.Size = new System.Drawing.Size(152, 41);
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
            this.SensorName,
            this.Column_SensorType,
            this.Column_ISOSetting});
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
            this.DGV_SensorInfo.Size = new System.Drawing.Size(146, 0);
            this.DGV_SensorInfo.TabIndex = 1;
            this.DGV_SensorInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SensorInfo_CellMouseClick);
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
            // SensorName
            // 
            this.SensorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SensorName.HeaderText = "Sensor Name";
            this.SensorName.Name = "SensorName";
            this.SensorName.ReadOnly = true;
            // 
            // Column_SensorType
            // 
            this.Column_SensorType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_SensorType.HeaderText = "Sensor Type";
            this.Column_SensorType.Name = "Column_SensorType";
            this.Column_SensorType.ReadOnly = true;
            // 
            // Column_ISOSetting
            // 
            this.Column_ISOSetting.HeaderText = "ISO Setting";
            this.Column_ISOSetting.Name = "Column_ISOSetting";
            this.Column_ISOSetting.Text = "Setting";
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
            this.Panel_EditSensorInfo.Size = new System.Drawing.Size(146, 43);
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
            // TabPage_ISO
            // 
            this.TabPage_ISO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.TabPage_ISO.Controls.Add(this.TablePanel_ISOChart);
            this.TabPage_ISO.Controls.Add(this.panel1);
            this.TabPage_ISO.Location = new System.Drawing.Point(-1, 22);
            this.TabPage_ISO.Name = "TabPage_ISO";
            this.TabPage_ISO.Size = new System.Drawing.Size(152, 41);
            this.TabPage_ISO.TabIndex = 5;
            this.TabPage_ISO.Text = "ISO 10816";
            // 
            // TablePanel_ISOChart
            // 
            this.TablePanel_ISOChart.AutoScroll = true;
            this.TablePanel_ISOChart.AutoSize = true;
            this.TablePanel_ISOChart.ColumnCount = 2;
            this.TablePanel_ISOChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanel_ISOChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanel_ISOChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablePanel_ISOChart.Location = new System.Drawing.Point(0, 43);
            this.TablePanel_ISOChart.Margin = new System.Windows.Forms.Padding(4);
            this.TablePanel_ISOChart.Name = "TablePanel_ISOChart";
            this.TablePanel_ISOChart.RowCount = 3;
            this.TablePanel_ISOChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_ISOChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_ISOChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TablePanel_ISOChart.Size = new System.Drawing.Size(152, 0);
            this.TablePanel_ISOChart.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.PageSwitch_ISOChart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 43);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(184)))), ((int)(((byte)(192)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(-80, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "篩選：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(-7, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 29);
            this.textBox1.TabIndex = 1;
            // 
            // PageSwitch_ISOChart
            // 
            this.PageSwitch_ISOChart.AutoSize = true;
            this.PageSwitch_ISOChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(131)))), ((int)(((byte)(169)))));
            this.PageSwitch_ISOChart.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PageSwitch_ISOChart.Location = new System.Drawing.Point(4, 8);
            this.PageSwitch_ISOChart.Margin = new System.Windows.Forms.Padding(4);
            this.PageSwitch_ISOChart.MinimumSize = new System.Drawing.Size(0, 27);
            this.PageSwitch_ISOChart.Name = "PageSwitch_ISOChart";
            this.PageSwitch_ISOChart.NowPageNumber = 1;
            this.PageSwitch_ISOChart.Size = new System.Drawing.Size(92, 27);
            this.PageSwitch_ISOChart.TabIndex = 0;
            // 
            // Panel_Query
            // 
            this.Panel_Query.Controls.Add(this.BTN_Query);
            this.Panel_Query.Controls.Add(this.pictureBox1);
            this.Panel_Query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Panel_Query.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Query.Location = new System.Drawing.Point(0, 195);
            this.Panel_Query.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Query.Name = "Panel_Query";
            this.Panel_Query.Size = new System.Drawing.Size(170, 41);
            this.Panel_Query.TabIndex = 7;
            // 
            // BTN_Query
            // 
            this.BTN_Query.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_Query.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.BTN_Query.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(135)))));
            this.BTN_Query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.BTN_Query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.BTN_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Query.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.BTN_Query.ForeColor = System.Drawing.Color.White;
            this.BTN_Query.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BTN_Query.Location = new System.Drawing.Point(43, 0);
            this.BTN_Query.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_Query.Name = "BTN_Query";
            this.BTN_Query.Size = new System.Drawing.Size(127, 41);
            this.BTN_Query.TabIndex = 1;
            this.BTN_Query.Text = "Data Query";
            this.BTN_Query.UseVisualStyleBackColor = false;
            this.BTN_Query.Click += new System.EventHandler(this.BTN_Query_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "TabPageModuleManager";
            // 
            // Panel_ISO
            // 
            this.Panel_ISO.Controls.Add(this.BTN_ISO);
            this.Panel_ISO.Controls.Add(this.pictureBox3);
            this.Panel_ISO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Panel_ISO.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_ISO.Location = new System.Drawing.Point(0, 154);
            this.Panel_ISO.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_ISO.Name = "Panel_ISO";
            this.Panel_ISO.Size = new System.Drawing.Size(170, 41);
            this.Panel_ISO.TabIndex = 8;
            // 
            // BTN_ISO
            // 
            this.BTN_ISO.BackColor = System.Drawing.Color.Transparent;
            this.BTN_ISO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_ISO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.BTN_ISO.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(135)))));
            this.BTN_ISO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.BTN_ISO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.BTN_ISO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ISO.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.BTN_ISO.ForeColor = System.Drawing.Color.White;
            this.BTN_ISO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BTN_ISO.Location = new System.Drawing.Point(43, 0);
            this.BTN_ISO.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_ISO.Name = "BTN_ISO";
            this.BTN_ISO.Size = new System.Drawing.Size(127, 41);
            this.BTN_ISO.TabIndex = 1;
            this.BTN_ISO.Text = "ISO 10816";
            this.BTN_ISO.UseVisualStyleBackColor = false;
            this.BTN_ISO.Click += new System.EventHandler(this.BTN_ISO_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "TabPageModuleManager";
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
            this.btnStatus.Location = new System.Drawing.Point(43, 0);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(127, 41);
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
            this.pictureBox20.Size = new System.Drawing.Size(43, 41);
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
            this.btnLog.Location = new System.Drawing.Point(43, 0);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(127, 41);
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
            this.pictureBox19.Size = new System.Drawing.Size(43, 41);
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
            this.BTN_RawData.Location = new System.Drawing.Point(43, 0);
            this.BTN_RawData.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_RawData.Name = "BTN_RawData";
            this.BTN_RawData.Size = new System.Drawing.Size(127, 41);
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
            this.pictureBox2.Size = new System.Drawing.Size(43, 41);
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
            this.picbRestart.Click += new System.EventHandler(this.picbRestart_Click);
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
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 669);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 35);
            this.panel2.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1354, 710);
            this.Controls.Add(this.TableLayout_WholeView);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Control Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.TableLayout_WholeView.ResumeLayout(false);
            this.TableLayout_SideBar.ResumeLayout(false);
            this.TableLayout_SideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Icon)).EndInit();
            this.panMenu.ResumeLayout(false);
            this.Panel_MainArea.ResumeLayout(false);
            this.TabControl_Main.ResumeLayout(false);
            this.TabPage_Signal.ResumeLayout(false);
            this.TabPage_Signal.PerformLayout();
            this.Panel_Signals_Function.ResumeLayout(false);
            this.Panel_Signals_Function.PerformLayout();
            this.TabPage_SensorInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SensorInfo)).EndInit();
            this.Panel_EditSensorInfo.ResumeLayout(false);
            this.TabPage_ISO.ResumeLayout(false);
            this.TabPage_ISO.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Panel_Query.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panel_ISO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.panLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            this.Panel_RawData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbRestart)).EndInit();
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
        private System.Windows.Forms.Panel Panel_Signals_Function;
        private User_Control.PageSwitch PageSwitch_Signals;
        private System.Windows.Forms.TableLayoutPanel TablePanel_SideBarFunctions;
        private System.Windows.Forms.Button BTN_OpenSystemSetting;
        private System.Windows.Forms.Panel Panel_Query;
        private System.Windows.Forms.Button BTN_Query;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Label_Signals_Filter;
        private System.Windows.Forms.TextBox TXT_RawDataChartFilter;
        private System.Windows.Forms.Panel Panel_ISO;
        private System.Windows.Forms.Button BTN_ISO;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TabPage TabPage_ISO;
        private System.Windows.Forms.TableLayoutPanel TablePanel_ISOChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private User_Control.PageSwitch PageSwitch_ISOChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SensorType;
        private System.Windows.Forms.DataGridViewButtonColumn Column_ISOSetting;
        private System.Windows.Forms.Panel Panel_MainArea;
        private System.Windows.Forms.Panel panel2;
    }
}

