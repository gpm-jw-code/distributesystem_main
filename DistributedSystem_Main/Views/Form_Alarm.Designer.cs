
namespace DistributedSystem_Main.Views
{
    partial class Form_Alarm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel_Function = new System.Windows.Forms.Panel();
            this.DGV_AlarmEvents = new System.Windows.Forms.DataGridView();
            this.BTN_ResetAll = new System.Windows.Forms.Button();
            this.Column_EQName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SensorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Decription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_reset = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Panel_Function.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AlarmEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Function
            // 
            this.Panel_Function.Controls.Add(this.BTN_ResetAll);
            this.Panel_Function.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Function.Location = new System.Drawing.Point(0, 0);
            this.Panel_Function.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel_Function.Name = "Panel_Function";
            this.Panel_Function.Size = new System.Drawing.Size(870, 71);
            this.Panel_Function.TabIndex = 0;
            // 
            // DGV_AlarmEvents
            // 
            this.DGV_AlarmEvents.AllowUserToAddRows = false;
            this.DGV_AlarmEvents.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_AlarmEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_AlarmEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_AlarmEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_EQName,
            this.Column_Unit,
            this.Column_SensorName,
            this.Column_Event,
            this.Column_Decription,
            this.Column_reset});
            this.DGV_AlarmEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_AlarmEvents.Location = new System.Drawing.Point(0, 71);
            this.DGV_AlarmEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_AlarmEvents.Name = "DGV_AlarmEvents";
            this.DGV_AlarmEvents.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DGV_AlarmEvents.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_AlarmEvents.RowTemplate.Height = 24;
            this.DGV_AlarmEvents.Size = new System.Drawing.Size(870, 413);
            this.DGV_AlarmEvents.TabIndex = 1;
            this.DGV_AlarmEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_AlarmEvents_CellContentClick);
            // 
            // BTN_ResetAll
            // 
            this.BTN_ResetAll.Location = new System.Drawing.Point(731, 12);
            this.BTN_ResetAll.Name = "BTN_ResetAll";
            this.BTN_ResetAll.Size = new System.Drawing.Size(127, 39);
            this.BTN_ResetAll.TabIndex = 0;
            this.BTN_ResetAll.Text = "Reset All";
            this.BTN_ResetAll.UseVisualStyleBackColor = true;
            this.BTN_ResetAll.Click += new System.EventHandler(this.BTN_ResetAll_Click);
            // 
            // Column_EQName
            // 
            this.Column_EQName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_EQName.HeaderText = "EQ Name";
            this.Column_EQName.Name = "Column_EQName";
            this.Column_EQName.ReadOnly = true;
            // 
            // Column_Unit
            // 
            this.Column_Unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Unit.HeaderText = "Unit Name";
            this.Column_Unit.Name = "Column_Unit";
            this.Column_Unit.ReadOnly = true;
            // 
            // Column_SensorName
            // 
            this.Column_SensorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_SensorName.HeaderText = "Sensor Name";
            this.Column_SensorName.Name = "Column_SensorName";
            this.Column_SensorName.ReadOnly = true;
            // 
            // Column_Event
            // 
            this.Column_Event.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Event.HeaderText = "Event";
            this.Column_Event.Name = "Column_Event";
            this.Column_Event.ReadOnly = true;
            // 
            // Column_Decription
            // 
            this.Column_Decription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Decription.HeaderText = "Description";
            this.Column_Decription.Name = "Column_Decription";
            this.Column_Decription.ReadOnly = true;
            // 
            // Column_reset
            // 
            this.Column_reset.HeaderText = "Reset";
            this.Column_reset.Name = "Column_reset";
            this.Column_reset.ReadOnly = true;
            // 
            // Form_Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 484);
            this.Controls.Add(this.DGV_AlarmEvents);
            this.Controls.Add(this.Panel_Function);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_Alarm";
            this.Text = "Event";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Alarm_FormClosing);
            this.Panel_Function.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AlarmEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Function;
        private System.Windows.Forms.DataGridView DGV_AlarmEvents;
        private System.Windows.Forms.Button BTN_ResetAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EQName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SensorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Decription;
        private System.Windows.Forms.DataGridViewButtonColumn Column_reset;
    }
}