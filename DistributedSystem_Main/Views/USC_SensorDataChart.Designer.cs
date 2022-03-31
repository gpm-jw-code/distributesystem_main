﻿
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labBatchModeStateShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForShow)).BeginInit();
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
            // labIP
            // 
            this.LAB_SensorName.AutoSize = true;
            this.LAB_SensorName.BackColor = System.Drawing.Color.Transparent;
            this.LAB_SensorName.Dock = System.Windows.Forms.DockStyle.Right;
            this.LAB_SensorName.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LAB_SensorName.ForeColor = System.Drawing.Color.Silver;
            this.LAB_SensorName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LAB_SensorName.Location = new System.Drawing.Point(419, 0);
            this.LAB_SensorName.Name = "labIP";
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
            chartArea1.AxisX.IsInterlaced = true;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.Format = "hh:mm:ss";
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.ChartForShow.ChartAreas.Add(chartArea1);
            this.ChartForShow.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.Silver;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.ChartForShow.Legends.Add(legend1);
            this.ChartForShow.Location = new System.Drawing.Point(0, 26);
            this.ChartForShow.Name = "ChartForShow";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ChartForShow.Series.Add(series1);
            this.ChartForShow.Size = new System.Drawing.Size(502, 311);
            this.ChartForShow.TabIndex = 7;
            this.ChartForShow.Text = "chart1";
            // 
            // USC_SensorDataChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChartForShow);
            this.Controls.Add(this.panel2);
            this.Name = "USC_SensorDataChart";
            this.Size = new System.Drawing.Size(502, 337);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labBatchModeStateShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.PictureBox labBatchModeStateShow;
        public System.Windows.Forms.Label labUnitName;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label labEqName;
        protected System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IPMRunningLabel;
        public System.Windows.Forms.Label LAB_SensorName;
        private System.Windows.Forms.PictureBox picSettingIcon;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartForShow;
    }
}
