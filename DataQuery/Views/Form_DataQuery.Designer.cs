
namespace DataQuery
{
    partial class Form_DataQuery
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
            this.Panel_Data = new System.Windows.Forms.Panel();
            this.SplitContainer_Sensor_Chart = new System.Windows.Forms.SplitContainer();
            this.TreeView_SensorList = new System.Windows.Forms.TreeView();
            this.Panel_Functions = new System.Windows.Forms.Panel();
            this.LAB_ShowMulti = new System.Windows.Forms.Label();
            this.LAB_ShowSingle = new System.Windows.Forms.Label();
            this.Panel_CustomQueryTime = new System.Windows.Forms.Panel();
            this.BTN_QueryCustomTime = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimePicker_EndTime = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker_StartTime = new System.Windows.Forms.DateTimePicker();
            this.LAB_QueryCustom = new System.Windows.Forms.Label();
            this.LAB_QueryAYear = new System.Windows.Forms.Label();
            this.LAB_QuerySixMonth = new System.Windows.Forms.Label();
            this.LAB_QueryAMonth = new System.Windows.Forms.Label();
            this.LAB_QueryAWeek = new System.Windows.Forms.Label();
            this.LAB_QueryADay = new System.Windows.Forms.Label();
            this.Panel_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Sensor_Chart)).BeginInit();
            this.SplitContainer_Sensor_Chart.Panel1.SuspendLayout();
            this.SplitContainer_Sensor_Chart.SuspendLayout();
            this.Panel_Functions.SuspendLayout();
            this.Panel_CustomQueryTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Data
            // 
            this.Panel_Data.Controls.Add(this.SplitContainer_Sensor_Chart);
            this.Panel_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Data.Location = new System.Drawing.Point(0, 78);
            this.Panel_Data.Name = "Panel_Data";
            this.Panel_Data.Size = new System.Drawing.Size(1242, 513);
            this.Panel_Data.TabIndex = 4;
            // 
            // SplitContainer_Sensor_Chart
            // 
            this.SplitContainer_Sensor_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Sensor_Chart.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Sensor_Chart.Name = "SplitContainer_Sensor_Chart";
            // 
            // SplitContainer_Sensor_Chart.Panel1
            // 
            this.SplitContainer_Sensor_Chart.Panel1.Controls.Add(this.TreeView_SensorList);
            // 
            // SplitContainer_Sensor_Chart.Panel2
            // 
            this.SplitContainer_Sensor_Chart.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.SplitContainer_Sensor_Chart.Size = new System.Drawing.Size(1242, 513);
            this.SplitContainer_Sensor_Chart.SplitterDistance = 187;
            this.SplitContainer_Sensor_Chart.TabIndex = 0;
            // 
            // TreeView_SensorList
            // 
            this.TreeView_SensorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.TreeView_SensorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView_SensorList.ForeColor = System.Drawing.Color.White;
            this.TreeView_SensorList.Location = new System.Drawing.Point(0, 0);
            this.TreeView_SensorList.Name = "TreeView_SensorList";
            this.TreeView_SensorList.Size = new System.Drawing.Size(187, 513);
            this.TreeView_SensorList.TabIndex = 0;
            this.TreeView_SensorList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_SensorList_NodeMouseDoubleClick);
            // 
            // Panel_Functions
            // 
            this.Panel_Functions.Controls.Add(this.LAB_ShowMulti);
            this.Panel_Functions.Controls.Add(this.LAB_ShowSingle);
            this.Panel_Functions.Controls.Add(this.Panel_CustomQueryTime);
            this.Panel_Functions.Controls.Add(this.LAB_QueryCustom);
            this.Panel_Functions.Controls.Add(this.LAB_QueryAYear);
            this.Panel_Functions.Controls.Add(this.LAB_QuerySixMonth);
            this.Panel_Functions.Controls.Add(this.LAB_QueryAMonth);
            this.Panel_Functions.Controls.Add(this.LAB_QueryAWeek);
            this.Panel_Functions.Controls.Add(this.LAB_QueryADay);
            this.Panel_Functions.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Functions.Location = new System.Drawing.Point(0, 0);
            this.Panel_Functions.Name = "Panel_Functions";
            this.Panel_Functions.Size = new System.Drawing.Size(1242, 78);
            this.Panel_Functions.TabIndex = 5;
            // 
            // LAB_ShowMulti
            // 
            this.LAB_ShowMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LAB_ShowMulti.AutoSize = true;
            this.LAB_ShowMulti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_ShowMulti.Location = new System.Drawing.Point(1149, 32);
            this.LAB_ShowMulti.Name = "LAB_ShowMulti";
            this.LAB_ShowMulti.Size = new System.Drawing.Size(57, 20);
            this.LAB_ShowMulti.TabIndex = 5;
            this.LAB_ShowMulti.Text = "多視窗";
            // 
            // LAB_ShowSingle
            // 
            this.LAB_ShowSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LAB_ShowSingle.AutoSize = true;
            this.LAB_ShowSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_ShowSingle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.LAB_ShowSingle.Location = new System.Drawing.Point(1067, 32);
            this.LAB_ShowSingle.Name = "LAB_ShowSingle";
            this.LAB_ShowSingle.Size = new System.Drawing.Size(57, 20);
            this.LAB_ShowSingle.TabIndex = 5;
            this.LAB_ShowSingle.Text = "單視窗";
            // 
            // Panel_CustomQueryTime
            // 
            this.Panel_CustomQueryTime.Controls.Add(this.BTN_QueryCustomTime);
            this.Panel_CustomQueryTime.Controls.Add(this.label7);
            this.Panel_CustomQueryTime.Controls.Add(this.label1);
            this.Panel_CustomQueryTime.Controls.Add(this.DateTimePicker_EndTime);
            this.Panel_CustomQueryTime.Controls.Add(this.DateTimePicker_StartTime);
            this.Panel_CustomQueryTime.Location = new System.Drawing.Point(428, 19);
            this.Panel_CustomQueryTime.Name = "Panel_CustomQueryTime";
            this.Panel_CustomQueryTime.Size = new System.Drawing.Size(622, 41);
            this.Panel_CustomQueryTime.TabIndex = 4;
            this.Panel_CustomQueryTime.Visible = false;
            // 
            // BTN_QueryCustomTime
            // 
            this.BTN_QueryCustomTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_QueryCustomTime.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BTN_QueryCustomTime.Location = new System.Drawing.Point(523, 6);
            this.BTN_QueryCustomTime.Name = "BTN_QueryCustomTime";
            this.BTN_QueryCustomTime.Size = new System.Drawing.Size(80, 29);
            this.BTN_QueryCustomTime.TabIndex = 3;
            this.BTN_QueryCustomTime.Text = "Query";
            this.BTN_QueryCustomTime.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(273, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "End Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Time";
            // 
            // DateTimePicker_EndTime
            // 
            this.DateTimePicker_EndTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.DateTimePicker_EndTime.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DateTimePicker_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_EndTime.Location = new System.Drawing.Point(346, 6);
            this.DateTimePicker_EndTime.Margin = new System.Windows.Forms.Padding(5);
            this.DateTimePicker_EndTime.Name = "DateTimePicker_EndTime";
            this.DateTimePicker_EndTime.Size = new System.Drawing.Size(169, 27);
            this.DateTimePicker_EndTime.TabIndex = 0;
            this.DateTimePicker_EndTime.Value = new System.DateTime(2021, 11, 1, 0, 0, 0, 0);
            // 
            // DateTimePicker_StartTime
            // 
            this.DateTimePicker_StartTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.DateTimePicker_StartTime.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DateTimePicker_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_StartTime.Location = new System.Drawing.Point(90, 6);
            this.DateTimePicker_StartTime.Margin = new System.Windows.Forms.Padding(5);
            this.DateTimePicker_StartTime.Name = "DateTimePicker_StartTime";
            this.DateTimePicker_StartTime.Size = new System.Drawing.Size(169, 27);
            this.DateTimePicker_StartTime.TabIndex = 0;
            this.DateTimePicker_StartTime.Value = new System.DateTime(2021, 11, 1, 0, 0, 0, 0);
            // 
            // LAB_QueryCustom
            // 
            this.LAB_QueryCustom.AutoSize = true;
            this.LAB_QueryCustom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_QueryCustom.Location = new System.Drawing.Point(369, 29);
            this.LAB_QueryCustom.Name = "LAB_QueryCustom";
            this.LAB_QueryCustom.Size = new System.Drawing.Size(41, 20);
            this.LAB_QueryCustom.TabIndex = 2;
            this.LAB_QueryCustom.Text = "自訂";
            // 
            // LAB_QueryAYear
            // 
            this.LAB_QueryAYear.AutoSize = true;
            this.LAB_QueryAYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_QueryAYear.Location = new System.Drawing.Point(304, 29);
            this.LAB_QueryAYear.Name = "LAB_QueryAYear";
            this.LAB_QueryAYear.Size = new System.Drawing.Size(34, 20);
            this.LAB_QueryAYear.TabIndex = 2;
            this.LAB_QueryAYear.Tag = "365";
            this.LAB_QueryAYear.Text = "1年";
            // 
            // LAB_QuerySixMonth
            // 
            this.LAB_QuerySixMonth.AutoSize = true;
            this.LAB_QuerySixMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_QuerySixMonth.Location = new System.Drawing.Point(223, 29);
            this.LAB_QuerySixMonth.Name = "LAB_QuerySixMonth";
            this.LAB_QuerySixMonth.Size = new System.Drawing.Size(50, 20);
            this.LAB_QuerySixMonth.TabIndex = 2;
            this.LAB_QuerySixMonth.Tag = "180";
            this.LAB_QuerySixMonth.Text = "6個月";
            // 
            // LAB_QueryAMonth
            // 
            this.LAB_QueryAMonth.AutoSize = true;
            this.LAB_QueryAMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_QueryAMonth.Location = new System.Drawing.Point(142, 29);
            this.LAB_QueryAMonth.Name = "LAB_QueryAMonth";
            this.LAB_QueryAMonth.Size = new System.Drawing.Size(50, 20);
            this.LAB_QueryAMonth.TabIndex = 2;
            this.LAB_QueryAMonth.Tag = "30";
            this.LAB_QueryAMonth.Text = "1個月";
            // 
            // LAB_QueryAWeek
            // 
            this.LAB_QueryAWeek.AutoSize = true;
            this.LAB_QueryAWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_QueryAWeek.Location = new System.Drawing.Point(77, 29);
            this.LAB_QueryAWeek.Name = "LAB_QueryAWeek";
            this.LAB_QueryAWeek.Size = new System.Drawing.Size(34, 20);
            this.LAB_QueryAWeek.TabIndex = 2;
            this.LAB_QueryAWeek.Tag = "7";
            this.LAB_QueryAWeek.Text = "1周";
            // 
            // LAB_QueryADay
            // 
            this.LAB_QueryADay.AutoSize = true;
            this.LAB_QueryADay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_QueryADay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.LAB_QueryADay.Location = new System.Drawing.Point(12, 29);
            this.LAB_QueryADay.Name = "LAB_QueryADay";
            this.LAB_QueryADay.Size = new System.Drawing.Size(34, 20);
            this.LAB_QueryADay.TabIndex = 2;
            this.LAB_QueryADay.Tag = "1";
            this.LAB_QueryADay.Text = "1天";
            // 
            // Form_DataQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1242, 591);
            this.Controls.Add(this.Panel_Data);
            this.Controls.Add(this.Panel_Functions);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.Color.White;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_DataQuery";
            this.Text = "Data Query";
            this.Panel_Data.ResumeLayout(false);
            this.SplitContainer_Sensor_Chart.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Sensor_Chart)).EndInit();
            this.SplitContainer_Sensor_Chart.ResumeLayout(false);
            this.Panel_Functions.ResumeLayout(false);
            this.Panel_Functions.PerformLayout();
            this.Panel_CustomQueryTime.ResumeLayout(false);
            this.Panel_CustomQueryTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Data;
        private System.Windows.Forms.SplitContainer SplitContainer_Sensor_Chart;
        private System.Windows.Forms.TreeView TreeView_SensorList;
        private System.Windows.Forms.Panel Panel_Functions;
        private System.Windows.Forms.Label LAB_ShowMulti;
        private System.Windows.Forms.Label LAB_ShowSingle;
        private System.Windows.Forms.Panel Panel_CustomQueryTime;
        private System.Windows.Forms.Button BTN_QueryCustomTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimePicker_EndTime;
        private System.Windows.Forms.DateTimePicker DateTimePicker_StartTime;
        private System.Windows.Forms.Label LAB_QueryCustom;
        private System.Windows.Forms.Label LAB_QueryAYear;
        private System.Windows.Forms.Label LAB_QuerySixMonth;
        private System.Windows.Forms.Label LAB_QueryAMonth;
        private System.Windows.Forms.Label LAB_QueryAWeek;
        private System.Windows.Forms.Label LAB_QueryADay;
    }
}

