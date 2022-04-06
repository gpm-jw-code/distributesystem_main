
namespace DistributedSystem_Main.Views
{
    partial class Form_SensorThresholdSetting
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
            this.CheckBox_ApplyToAll = new System.Windows.Forms.CheckBox();
            this.LAB_SensorIP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LAB_UnitName = new System.Windows.Forms.Label();
            this.LAB_EQName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.DGV_ThresholdSetting = new System.Windows.Forms.DataGridView();
            this.DataName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Threshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.LAB_SensorType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ThresholdSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckBox_ApplyToAll
            // 
            this.CheckBox_ApplyToAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBox_ApplyToAll.AutoSize = true;
            this.CheckBox_ApplyToAll.Location = new System.Drawing.Point(116, 343);
            this.CheckBox_ApplyToAll.Name = "CheckBox_ApplyToAll";
            this.CheckBox_ApplyToAll.Size = new System.Drawing.Size(151, 16);
            this.CheckBox_ApplyToAll.TabIndex = 22;
            this.CheckBox_ApplyToAll.Text = "套用至所有同類型Sensor";
            this.CheckBox_ApplyToAll.UseVisualStyleBackColor = true;
            // 
            // LAB_SensorIP
            // 
            this.LAB_SensorIP.AutoSize = true;
            this.LAB_SensorIP.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_SensorIP.Location = new System.Drawing.Point(112, 82);
            this.LAB_SensorIP.Name = "LAB_SensorIP";
            this.LAB_SensorIP.Size = new System.Drawing.Size(129, 20);
            this.LAB_SensorIP.TabIndex = 21;
            this.LAB_SensorIP.Text = "192.168.123.456";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(25, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "IP : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LAB_UnitName
            // 
            this.LAB_UnitName.AutoSize = true;
            this.LAB_UnitName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_UnitName.Location = new System.Drawing.Point(112, 50);
            this.LAB_UnitName.Name = "LAB_UnitName";
            this.LAB_UnitName.Size = new System.Drawing.Size(68, 20);
            this.LAB_UnitName.TabIndex = 19;
            this.LAB_UnitName.Text = "Unit123";
            // 
            // LAB_EQName
            // 
            this.LAB_EQName.AutoSize = true;
            this.LAB_EQName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_EQName.Location = new System.Drawing.Point(112, 18);
            this.LAB_EQName.Name = "LAB_EQName";
            this.LAB_EQName.Size = new System.Drawing.Size(58, 20);
            this.LAB_EQName.TabIndex = 18;
            this.LAB_EQName.Text = "EQ123";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(25, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Unit : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(25, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "EQ : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_Save.Location = new System.Drawing.Point(75, 376);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(105, 40);
            this.BTN_Save.TabIndex = 15;
            this.BTN_Save.Text = "OK";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // DGV_ThresholdSetting
            // 
            this.DGV_ThresholdSetting.AllowUserToAddRows = false;
            this.DGV_ThresholdSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_ThresholdSetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_ThresholdSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ThresholdSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataName,
            this.Threshold});
            this.DGV_ThresholdSetting.Location = new System.Drawing.Point(27, 151);
            this.DGV_ThresholdSetting.Name = "DGV_ThresholdSetting";
            this.DGV_ThresholdSetting.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DGV_ThresholdSetting.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_ThresholdSetting.RowTemplate.Height = 24;
            this.DGV_ThresholdSetting.Size = new System.Drawing.Size(240, 186);
            this.DGV_ThresholdSetting.TabIndex = 23;
            // 
            // DataName
            // 
            this.DataName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataName.HeaderText = "Data Name";
            this.DataName.Name = "DataName";
            this.DataName.ReadOnly = true;
            // 
            // Threshold
            // 
            this.Threshold.HeaderText = "Threshold";
            this.Threshold.Name = "Threshold";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(25, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Type : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LAB_SensorType
            // 
            this.LAB_SensorType.AutoSize = true;
            this.LAB_SensorType.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_SensorType.Location = new System.Drawing.Point(112, 114);
            this.LAB_SensorType.Name = "LAB_SensorType";
            this.LAB_SensorType.Size = new System.Drawing.Size(100, 20);
            this.LAB_SensorType.TabIndex = 21;
            this.LAB_SensorType.Text = "Sensor Type";
            // 
            // Form_SensorThresholdSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 426);
            this.Controls.Add(this.DGV_ThresholdSetting);
            this.Controls.Add(this.CheckBox_ApplyToAll);
            this.Controls.Add(this.LAB_SensorType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LAB_SensorIP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LAB_UnitName);
            this.Controls.Add(this.LAB_EQName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTN_Save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_SensorThresholdSetting";
            this.Text = "Threshold Setting";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ThresholdSetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBox_ApplyToAll;
        private System.Windows.Forms.Label LAB_SensorIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LAB_UnitName;
        private System.Windows.Forms.Label LAB_EQName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.DataGridView DGV_ThresholdSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Threshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LAB_SensorType;
    }
}