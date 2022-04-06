
namespace DistributedSystem_Main.Views
{
    partial class USC_SensorDataChart
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USC_SensorDataChart));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labBatchModeStateShow = new System.Windows.Forms.PictureBox();
            this.labUnitName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labEqName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IPMRunningLabel = new System.Windows.Forms.Label();
            this.LAB_SensorName = new System.Windows.Forms.Label();
            this.picSettingIcon = new System.Windows.Forms.PictureBox();
            this.ChartForShow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LAB_LastUpdateTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labBatchModeStateShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForShow)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Controls.Add(this.labBatchModeStateShow);
            this.panel2.Controls.Add(this.labUnitName);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.labEqName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.IPMRunningLabel);
            this.panel2.Controls.Add(this.LAB_SensorName);
            this.panel2.Controls.Add(this.picSettingIcon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 26);
            this.panel2.TabIndex = 6;
            // 
            // labBatchModeStateShow
            // 
            this.labBatchModeStateShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labBatchModeStateShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.labBatchModeStateShow.Image = ((System.Drawing.Image)(resources.GetObject("labBatchModeStateShow.Image")));
            this.labBatchModeStateShow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labBatchModeStateShow.Location = new System.Drawing.Point(396, 0);
            this.labBatchModeStateShow.Name = "labBatchModeStateShow";
            this.labBatchModeStateShow.Size = new System.Drawing.Size(23, 26);
            this.labBatchModeStateShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.labBatchModeStateShow.TabIndex = 11;
            this.labBatchModeStateShow.TabStop = false;
            this.labBatchModeStateShow.Text = "數據封包獲取中...";
            this.labBatchModeStateShow.Visible = false;
            // 
            // labUnitName
            // 
            this.labUnitName.AutoSize = true;
            this.labUnitName.BackColor = System.Drawing.Color.Transparent;
            this.labUnitName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labUnitName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labUnitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.labUnitName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labUnitName.Location = new System.Drawing.Point(166, 0);
            this.labUnitName.Name = "labUnitName";
            this.labUnitName.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labUnitName.Size = new System.Drawing.Size(36, 24);
            this.labUnitName.TabIndex = 8;
            this.labUnitName.Text = "123";
            this.labUnitName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(110, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "  UNIT ▶";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labEqName
            // 
            this.labEqName.AutoSize = true;
            this.labEqName.BackColor = System.Drawing.Color.Transparent;
            this.labEqName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labEqName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labEqName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.labEqName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labEqName.Location = new System.Drawing.Point(68, 0);
            this.labEqName.Name = "labEqName";
            this.labEqName.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labEqName.Size = new System.Drawing.Size(42, 24);
            this.labEqName.TabIndex = 6;
            this.labEqName.Text = "AAA";
            this.labEqName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(24, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label5.Size = new System.Drawing.Size(44, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "  EQ ▶";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(16, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPMRunningLabel
            // 
            this.IPMRunningLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.IPMRunningLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IPMRunningLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IPMRunningLabel.Location = new System.Drawing.Point(0, 0);
            this.IPMRunningLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IPMRunningLabel.Name = "IPMRunningLabel";
            this.IPMRunningLabel.Size = new System.Drawing.Size(16, 26);
            this.IPMRunningLabel.TabIndex = 10;
            this.IPMRunningLabel.Visible = false;
            // 
            // LAB_SensorName
            // 
            this.LAB_SensorName.AutoSize = true;
            this.LAB_SensorName.BackColor = System.Drawing.Color.Transparent;
            this.LAB_SensorName.Dock = System.Windows.Forms.DockStyle.Right;
            this.LAB_SensorName.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LAB_SensorName.ForeColor = System.Drawing.Color.Silver;
            this.LAB_SensorName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LAB_SensorName.Location = new System.Drawing.Point(419, 0);
            this.LAB_SensorName.Name = "LAB_SensorName";
            this.LAB_SensorName.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.LAB_SensorName.Size = new System.Drawing.Size(59, 23);
            this.LAB_SensorName.TabIndex = 9;
            this.LAB_SensorName.Text = "127.0.0.1";
            this.LAB_SensorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picSettingIcon
            // 
            this.picSettingIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSettingIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.picSettingIcon.Image = ((System.Drawing.Image)(resources.GetObject("picSettingIcon.Image")));
            this.picSettingIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picSettingIcon.Location = new System.Drawing.Point(478, 0);
            this.picSettingIcon.Name = "picSettingIcon";
            this.picSettingIcon.Size = new System.Drawing.Size(24, 26);
            this.picSettingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSettingIcon.TabIndex = 2;
            this.picSettingIcon.TabStop = false;
            this.picSettingIcon.Click += new System.EventHandler(this.picSettingIcon_Click);
            // 
            // ChartForShow
            // 
            this.ChartForShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(25)))), ((int)(((byte)(28)))));
            this.ChartForShow.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ChartForShow.BorderlineColor = System.Drawing.Color.Transparent;
            this.ChartForShow.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.ChartForShow.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.ChartForShow.BorderSkin.BorderWidth = 0;
            this.ChartForShow.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.IsInterlaced = true;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LabelStyle.Format = "hh:mm:ss";
            chartArea2.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.ChartForShow.ChartAreas.Add(chartArea2);
            this.ChartForShow.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.ForeColor = System.Drawing.Color.Silver;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.ChartForShow.Legends.Add(legend2);
            this.ChartForShow.Location = new System.Drawing.Point(0, 26);
            this.ChartForShow.Name = "ChartForShow";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ChartForShow.Series.Add(series2);
            this.ChartForShow.Size = new System.Drawing.Size(502, 286);
            this.ChartForShow.TabIndex = 7;
            this.ChartForShow.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Controls.Add(this.LAB_LastUpdateTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 25);
            this.panel1.TabIndex = 8;
            // 
            // LAB_LastUpdateTime
            // 
            this.LAB_LastUpdateTime.AutoSize = true;
            this.LAB_LastUpdateTime.BackColor = System.Drawing.Color.Transparent;
            this.LAB_LastUpdateTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.LAB_LastUpdateTime.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LAB_LastUpdateTime.ForeColor = System.Drawing.Color.Silver;
            this.LAB_LastUpdateTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LAB_LastUpdateTime.Location = new System.Drawing.Point(91, 0);
            this.LAB_LastUpdateTime.Name = "LAB_LastUpdateTime";
            this.LAB_LastUpdateTime.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.LAB_LastUpdateTime.Size = new System.Drawing.Size(141, 23);
            this.LAB_LastUpdateTime.TabIndex = 10;
            this.LAB_LastUpdateTime.Text = "yyyy/MM/dd HH:mm:ss";
            this.LAB_LastUpdateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Update Time : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // USC_SensorDataChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChartForShow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "USC_SensorDataChart";
            this.Size = new System.Drawing.Size(502, 337);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labBatchModeStateShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForShow)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.PictureBox labBatchModeStateShow;
        private System.Windows.Forms.Label labUnitName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labEqName;
        protected System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IPMRunningLabel;
        private System.Windows.Forms.Label LAB_SensorName;
        private System.Windows.Forms.PictureBox picSettingIcon;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartForShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LAB_LastUpdateTime;
        private System.Windows.Forms.Label label3;
    }
}
