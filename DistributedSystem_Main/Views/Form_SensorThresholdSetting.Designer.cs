
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
            this.CheckBox_ApplyToAll = new System.Windows.Forms.CheckBox();
            this.LAB_SensorIP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LAB_UnitName = new System.Windows.Forms.Label();
            this.LAB_EQName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BTN_SaveToFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LAB_SensorType = new System.Windows.Forms.Label();
            this.Panel_MqttSetting = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.NUM_OOC = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NUM_OOS = new System.Windows.Forms.NumericUpDown();
            this.Combo_DataName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Panel_MqttSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_OOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_OOS)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckBox_ApplyToAll
            // 
            this.CheckBox_ApplyToAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBox_ApplyToAll.AutoSize = true;
            this.CheckBox_ApplyToAll.Location = new System.Drawing.Point(115, 390);
            this.CheckBox_ApplyToAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckBox_ApplyToAll.Name = "CheckBox_ApplyToAll";
            this.CheckBox_ApplyToAll.Size = new System.Drawing.Size(172, 21);
            this.CheckBox_ApplyToAll.TabIndex = 22;
            this.CheckBox_ApplyToAll.Text = "套用至所有同類型Sensor";
            this.CheckBox_ApplyToAll.UseVisualStyleBackColor = true;
            // 
            // LAB_SensorIP
            // 
            this.LAB_SensorIP.AutoSize = true;
            this.LAB_SensorIP.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_SensorIP.Location = new System.Drawing.Point(130, 117);
            this.LAB_SensorIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_SensorIP.Name = "LAB_SensorIP";
            this.LAB_SensorIP.Size = new System.Drawing.Size(129, 20);
            this.LAB_SensorIP.TabIndex = 21;
            this.LAB_SensorIP.Text = "192.168.123.456";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(34, 113);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 28);
            this.label8.TabIndex = 20;
            this.label8.Text = "IP : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LAB_UnitName
            // 
            this.LAB_UnitName.AutoSize = true;
            this.LAB_UnitName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_UnitName.Location = new System.Drawing.Point(130, 77);
            this.LAB_UnitName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_UnitName.Name = "LAB_UnitName";
            this.LAB_UnitName.Size = new System.Drawing.Size(68, 20);
            this.LAB_UnitName.TabIndex = 19;
            this.LAB_UnitName.Text = "Unit123";
            // 
            // LAB_EQName
            // 
            this.LAB_EQName.AutoSize = true;
            this.LAB_EQName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_EQName.Location = new System.Drawing.Point(130, 37);
            this.LAB_EQName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_EQName.Name = "LAB_EQName";
            this.LAB_EQName.Size = new System.Drawing.Size(58, 20);
            this.LAB_EQName.TabIndex = 18;
            this.LAB_EQName.Text = "EQ123";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(34, 73);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "Unit : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(34, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 28);
            this.label6.TabIndex = 16;
            this.label6.Text = "EQ : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_SaveToFile
            // 
            this.BTN_SaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_SaveToFile.Location = new System.Drawing.Point(90, 419);
            this.BTN_SaveToFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_SaveToFile.Name = "BTN_SaveToFile";
            this.BTN_SaveToFile.Size = new System.Drawing.Size(108, 57);
            this.BTN_SaveToFile.TabIndex = 15;
            this.BTN_SaveToFile.Text = "Save";
            this.BTN_SaveToFile.UseVisualStyleBackColor = true;
            this.BTN_SaveToFile.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(34, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 20;
            this.label1.Text = "Type : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LAB_SensorType
            // 
            this.LAB_SensorType.AutoSize = true;
            this.LAB_SensorType.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_SensorType.Location = new System.Drawing.Point(130, 157);
            this.LAB_SensorType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_SensorType.Name = "LAB_SensorType";
            this.LAB_SensorType.Size = new System.Drawing.Size(100, 20);
            this.LAB_SensorType.TabIndex = 21;
            this.LAB_SensorType.Text = "Sensor Type";
            // 
            // Panel_MqttSetting
            // 
            this.Panel_MqttSetting.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_MqttSetting.Controls.Add(this.Combo_DataName);
            this.Panel_MqttSetting.Controls.Add(this.label2);
            this.Panel_MqttSetting.Controls.Add(this.NUM_OOS);
            this.Panel_MqttSetting.Controls.Add(this.label3);
            this.Panel_MqttSetting.Controls.Add(this.NUM_OOC);
            this.Panel_MqttSetting.Controls.Add(this.label5);
            this.Panel_MqttSetting.Controls.Add(this.label4);
            this.Panel_MqttSetting.Location = new System.Drawing.Point(37, 211);
            this.Panel_MqttSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel_MqttSetting.Name = "Panel_MqttSetting";
            this.Panel_MqttSetting.Size = new System.Drawing.Size(248, 171);
            this.Panel_MqttSetting.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Threshold Setting";
            // 
            // NUM_OOC
            // 
            this.NUM_OOC.Location = new System.Drawing.Point(108, 67);
            this.NUM_OOC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NUM_OOC.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUM_OOC.Name = "NUM_OOC";
            this.NUM_OOC.Size = new System.Drawing.Size(114, 25);
            this.NUM_OOC.TabIndex = 3;
            this.NUM_OOC.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.NUM_OOC.ValueChanged += new System.EventHandler(this.NUM_OOC_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(19, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "OOC : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(19, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "OOS : ";
            // 
            // NUM_OOS
            // 
            this.NUM_OOS.Location = new System.Drawing.Point(108, 100);
            this.NUM_OOS.Margin = new System.Windows.Forms.Padding(4);
            this.NUM_OOS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUM_OOS.Name = "NUM_OOS";
            this.NUM_OOS.Size = new System.Drawing.Size(114, 25);
            this.NUM_OOS.TabIndex = 3;
            this.NUM_OOS.Value = new decimal(new int[] {
            1999,
            0,
            0,
            0});
            this.NUM_OOS.ValueChanged += new System.EventHandler(this.NUM_OOS_ValueChanged);
            // 
            // Combo_DataName
            // 
            this.Combo_DataName.FormattingEnabled = true;
            this.Combo_DataName.Location = new System.Drawing.Point(108, 35);
            this.Combo_DataName.Name = "Combo_DataName";
            this.Combo_DataName.Size = new System.Drawing.Size(121, 25);
            this.Combo_DataName.TabIndex = 5;
            this.Combo_DataName.SelectedIndexChanged += new System.EventHandler(this.Combo_DataName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(16, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data Name : ";
            // 
            // Form_SensorThresholdSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(311, 489);
            this.Controls.Add(this.Panel_MqttSetting);
            this.Controls.Add(this.CheckBox_ApplyToAll);
            this.Controls.Add(this.LAB_SensorType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LAB_SensorIP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LAB_UnitName);
            this.Controls.Add(this.LAB_EQName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTN_SaveToFile);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_SensorThresholdSetting";
            this.Text = "Threshold Setting";
            this.Panel_MqttSetting.ResumeLayout(false);
            this.Panel_MqttSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_OOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_OOS)).EndInit();
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
        private System.Windows.Forms.Button BTN_SaveToFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LAB_SensorType;
        private System.Windows.Forms.Panel Panel_MqttSetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NUM_OOC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Combo_DataName;
        private System.Windows.Forms.NumericUpDown NUM_OOS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}