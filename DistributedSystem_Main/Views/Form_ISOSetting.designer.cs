
namespace DistributedSystem_Main.Views
{
    partial class Form_ISOSetting
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
            this.COMBO_ISONumber = new System.Windows.Forms.ComboBox();
            this.LAB_DataType = new System.Windows.Forms.Label();
            this.BTN_SaveISOParameters = new System.Windows.Forms.Button();
            this.COMBO_Condition1 = new System.Windows.Forms.ComboBox();
            this.LAB_Condition1 = new System.Windows.Forms.Label();
            this.COMBO_Condition2 = new System.Windows.Forms.ComboBox();
            this.LAB_Condition2 = new System.Windows.Forms.Label();
            this.CheckBox_SaveThresholdToAllSensor = new System.Windows.Forms.CheckBox();
            this.LAB_SensorType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LAB_SensorIP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LAB_UnitName = new System.Windows.Forms.Label();
            this.LAB_EQName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Combo_DataName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // COMBO_ISONumber
            // 
            this.COMBO_ISONumber.FormattingEnabled = true;
            this.COMBO_ISONumber.Location = new System.Drawing.Point(194, 214);
            this.COMBO_ISONumber.Margin = new System.Windows.Forms.Padding(4);
            this.COMBO_ISONumber.Name = "COMBO_ISONumber";
            this.COMBO_ISONumber.Size = new System.Drawing.Size(141, 25);
            this.COMBO_ISONumber.TabIndex = 0;
            this.COMBO_ISONumber.SelectedIndexChanged += new System.EventHandler(this.COMBO_ISONumber_SelectedIndexChanged);
            // 
            // LAB_DataType
            // 
            this.LAB_DataType.AutoSize = true;
            this.LAB_DataType.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.LAB_DataType.ForeColor = System.Drawing.Color.Black;
            this.LAB_DataType.Location = new System.Drawing.Point(39, 214);
            this.LAB_DataType.Name = "LAB_DataType";
            this.LAB_DataType.Size = new System.Drawing.Size(94, 21);
            this.LAB_DataType.TabIndex = 2;
            this.LAB_DataType.Text = "ISO Type：";
            // 
            // BTN_SaveISOParameters
            // 
            this.BTN_SaveISOParameters.BackColor = System.Drawing.Color.Green;
            this.BTN_SaveISOParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SaveISOParameters.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BTN_SaveISOParameters.Location = new System.Drawing.Point(205, 432);
            this.BTN_SaveISOParameters.Name = "BTN_SaveISOParameters";
            this.BTN_SaveISOParameters.Size = new System.Drawing.Size(106, 49);
            this.BTN_SaveISOParameters.TabIndex = 3;
            this.BTN_SaveISOParameters.Text = "SAVE";
            this.BTN_SaveISOParameters.UseVisualStyleBackColor = false;
            this.BTN_SaveISOParameters.Click += new System.EventHandler(this.BTN_SaveISOParameters_Click);
            // 
            // COMBO_Condition1
            // 
            this.COMBO_Condition1.FormattingEnabled = true;
            this.COMBO_Condition1.Location = new System.Drawing.Point(194, 258);
            this.COMBO_Condition1.Margin = new System.Windows.Forms.Padding(4);
            this.COMBO_Condition1.Name = "COMBO_Condition1";
            this.COMBO_Condition1.Size = new System.Drawing.Size(141, 25);
            this.COMBO_Condition1.TabIndex = 0;
            // 
            // LAB_Condition1
            // 
            this.LAB_Condition1.AutoSize = true;
            this.LAB_Condition1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.LAB_Condition1.ForeColor = System.Drawing.Color.Black;
            this.LAB_Condition1.Location = new System.Drawing.Point(39, 258);
            this.LAB_Condition1.Name = "LAB_Condition1";
            this.LAB_Condition1.Size = new System.Drawing.Size(107, 21);
            this.LAB_Condition1.TabIndex = 2;
            this.LAB_Condition1.Text = "Condition 1 :";
            // 
            // COMBO_Condition2
            // 
            this.COMBO_Condition2.FormattingEnabled = true;
            this.COMBO_Condition2.Location = new System.Drawing.Point(194, 302);
            this.COMBO_Condition2.Margin = new System.Windows.Forms.Padding(4);
            this.COMBO_Condition2.Name = "COMBO_Condition2";
            this.COMBO_Condition2.Size = new System.Drawing.Size(141, 25);
            this.COMBO_Condition2.TabIndex = 0;
            // 
            // LAB_Condition2
            // 
            this.LAB_Condition2.AutoSize = true;
            this.LAB_Condition2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.LAB_Condition2.ForeColor = System.Drawing.Color.Black;
            this.LAB_Condition2.Location = new System.Drawing.Point(39, 302);
            this.LAB_Condition2.Name = "LAB_Condition2";
            this.LAB_Condition2.Size = new System.Drawing.Size(107, 21);
            this.LAB_Condition2.TabIndex = 2;
            this.LAB_Condition2.Text = "Condition 2 :";
            // 
            // CheckBox_SaveThresholdToAllSensor
            // 
            this.CheckBox_SaveThresholdToAllSensor.AutoSize = true;
            this.CheckBox_SaveThresholdToAllSensor.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CheckBox_SaveThresholdToAllSensor.ForeColor = System.Drawing.Color.Black;
            this.CheckBox_SaveThresholdToAllSensor.Location = new System.Drawing.Point(160, 394);
            this.CheckBox_SaveThresholdToAllSensor.Name = "CheckBox_SaveThresholdToAllSensor";
            this.CheckBox_SaveThresholdToAllSensor.Size = new System.Drawing.Size(134, 21);
            this.CheckBox_SaveThresholdToAllSensor.TabIndex = 26;
            this.CheckBox_SaveThresholdToAllSensor.Text = "套用至所有Sensor";
            this.CheckBox_SaveThresholdToAllSensor.UseVisualStyleBackColor = true;
            // 
            // LAB_SensorType
            // 
            this.LAB_SensorType.AutoSize = true;
            this.LAB_SensorType.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_SensorType.Location = new System.Drawing.Point(143, 152);
            this.LAB_SensorType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_SensorType.Name = "LAB_SensorType";
            this.LAB_SensorType.Size = new System.Drawing.Size(100, 20);
            this.LAB_SensorType.TabIndex = 33;
            this.LAB_SensorType.Text = "Sensor Type";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(36, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 31;
            this.label1.Text = "Type : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LAB_SensorIP
            // 
            this.LAB_SensorIP.AutoSize = true;
            this.LAB_SensorIP.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_SensorIP.Location = new System.Drawing.Point(143, 112);
            this.LAB_SensorIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_SensorIP.Name = "LAB_SensorIP";
            this.LAB_SensorIP.Size = new System.Drawing.Size(129, 20);
            this.LAB_SensorIP.TabIndex = 34;
            this.LAB_SensorIP.Text = "192.168.123.456";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(36, 108);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 28);
            this.label8.TabIndex = 32;
            this.label8.Text = "IP : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LAB_UnitName
            // 
            this.LAB_UnitName.AutoSize = true;
            this.LAB_UnitName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_UnitName.Location = new System.Drawing.Point(143, 72);
            this.LAB_UnitName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_UnitName.Name = "LAB_UnitName";
            this.LAB_UnitName.Size = new System.Drawing.Size(68, 20);
            this.LAB_UnitName.TabIndex = 30;
            this.LAB_UnitName.Text = "Unit123";
            // 
            // LAB_EQName
            // 
            this.LAB_EQName.AutoSize = true;
            this.LAB_EQName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LAB_EQName.Location = new System.Drawing.Point(143, 32);
            this.LAB_EQName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_EQName.Name = "LAB_EQName";
            this.LAB_EQName.Size = new System.Drawing.Size(58, 20);
            this.LAB_EQName.TabIndex = 29;
            this.LAB_EQName.Text = "EQ123";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(36, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 28);
            this.label7.TabIndex = 28;
            this.label7.Text = "Unit : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(36, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 28);
            this.label6.TabIndex = 27;
            this.label6.Text = "EQ : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Combo_DataName
            // 
            this.Combo_DataName.FormattingEnabled = true;
            this.Combo_DataName.Location = new System.Drawing.Point(194, 345);
            this.Combo_DataName.Margin = new System.Windows.Forms.Padding(4);
            this.Combo_DataName.Name = "Combo_DataName";
            this.Combo_DataName.Size = new System.Drawing.Size(141, 25);
            this.Combo_DataName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Name :";
            // 
            // Form_ISOSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(348, 491);
            this.Controls.Add(this.LAB_SensorType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LAB_SensorIP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LAB_UnitName);
            this.Controls.Add(this.LAB_EQName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CheckBox_SaveThresholdToAllSensor);
            this.Controls.Add(this.BTN_SaveISOParameters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LAB_Condition2);
            this.Controls.Add(this.LAB_Condition1);
            this.Controls.Add(this.LAB_DataType);
            this.Controls.Add(this.Combo_DataName);
            this.Controls.Add(this.COMBO_Condition2);
            this.Controls.Add(this.COMBO_Condition1);
            this.Controls.Add(this.COMBO_ISONumber);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_ISOSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ISO Setting";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_ISOSetting_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox COMBO_ISONumber;
        private System.Windows.Forms.Label LAB_DataType;
        private System.Windows.Forms.Button BTN_SaveISOParameters;
        private System.Windows.Forms.ComboBox COMBO_Condition1;
        private System.Windows.Forms.Label LAB_Condition1;
        private System.Windows.Forms.ComboBox COMBO_Condition2;
        private System.Windows.Forms.Label LAB_Condition2;
        private System.Windows.Forms.CheckBox CheckBox_SaveThresholdToAllSensor;
        private System.Windows.Forms.Label LAB_SensorType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LAB_SensorIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LAB_UnitName;
        private System.Windows.Forms.Label LAB_EQName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Combo_DataName;
        private System.Windows.Forms.Label label2;
    }
}