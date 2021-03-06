
namespace DistributedSystem_Main.Views
{
    partial class Form_HomeGroupSetting
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
            this.Combo_GroupName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_AddNewGroup = new System.Windows.Forms.Button();
            this.Panel_CustomSensorList = new System.Windows.Forms.Panel();
            this.TabControl_CustomSetting = new System.Windows.Forms.TabControl();
            this.TabPage_EditSensorList = new System.Windows.Forms.TabPage();
            this.SplitContainer_SensorList = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_EditSensorList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Panel_ColumnNames = new System.Windows.Forms.Panel();
            this.BTN_EditColumnNames = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BTN_EditRowSensor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_AddNewRow = new System.Windows.Forms.Button();
            this.BTN_DeleteRow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Combo_Rows = new System.Windows.Forms.ComboBox();
            this.Panel_RowSensor = new System.Windows.Forms.Panel();
            this.BTN_DeleteGroup = new System.Windows.Forms.Button();
            this.BTN_AutoSetByType = new System.Windows.Forms.Button();
            this.Panel_Functions = new System.Windows.Forms.Panel();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_SaveGroupParameters = new System.Windows.Forms.Button();
            this.TabControl_CustomSetting.SuspendLayout();
            this.TabPage_EditSensorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_SensorList)).BeginInit();
            this.SplitContainer_SensorList.Panel1.SuspendLayout();
            this.SplitContainer_SensorList.Panel2.SuspendLayout();
            this.SplitContainer_SensorList.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.Panel_Functions.SuspendLayout();
            this.SuspendLayout();
            // 
            // Combo_GroupName
            // 
            this.Combo_GroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_GroupName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Combo_GroupName.FormattingEnabled = true;
            this.Combo_GroupName.Location = new System.Drawing.Point(127, 26);
            this.Combo_GroupName.Margin = new System.Windows.Forms.Padding(5);
            this.Combo_GroupName.Name = "Combo_GroupName";
            this.Combo_GroupName.Size = new System.Drawing.Size(159, 28);
            this.Combo_GroupName.TabIndex = 0;
            this.Combo_GroupName.SelectedIndexChanged += new System.EventHandler(this.Combo_GroupName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group Name";
            // 
            // BTN_AddNewGroup
            // 
            this.BTN_AddNewGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.BTN_AddNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_AddNewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_AddNewGroup.Location = new System.Drawing.Point(314, 23);
            this.BTN_AddNewGroup.Name = "BTN_AddNewGroup";
            this.BTN_AddNewGroup.Size = new System.Drawing.Size(89, 28);
            this.BTN_AddNewGroup.TabIndex = 2;
            this.BTN_AddNewGroup.Text = "Add";
            this.BTN_AddNewGroup.UseVisualStyleBackColor = false;
            this.BTN_AddNewGroup.Click += new System.EventHandler(this.BTN_AddNewGroup_Click);
            // 
            // Panel_CustomSensorList
            // 
            this.Panel_CustomSensorList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_CustomSensorList.AutoScroll = true;
            this.Panel_CustomSensorList.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_CustomSensorList.Location = new System.Drawing.Point(12, 37);
            this.Panel_CustomSensorList.Name = "Panel_CustomSensorList";
            this.Panel_CustomSensorList.Size = new System.Drawing.Size(217, 322);
            this.Panel_CustomSensorList.TabIndex = 3;
            // 
            // TabControl_CustomSetting
            // 
            this.TabControl_CustomSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_CustomSetting.Controls.Add(this.TabPage_EditSensorList);
            this.TabControl_CustomSetting.Controls.Add(this.tabPage3);
            this.TabControl_CustomSetting.Location = new System.Drawing.Point(0, 106);
            this.TabControl_CustomSetting.Name = "TabControl_CustomSetting";
            this.TabControl_CustomSetting.SelectedIndex = 0;
            this.TabControl_CustomSetting.Size = new System.Drawing.Size(509, 403);
            this.TabControl_CustomSetting.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl_CustomSetting.TabIndex = 7;
            // 
            // TabPage_EditSensorList
            // 
            this.TabPage_EditSensorList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TabPage_EditSensorList.Controls.Add(this.SplitContainer_SensorList);
            this.TabPage_EditSensorList.Location = new System.Drawing.Point(4, 29);
            this.TabPage_EditSensorList.Name = "TabPage_EditSensorList";
            this.TabPage_EditSensorList.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_EditSensorList.Size = new System.Drawing.Size(501, 370);
            this.TabPage_EditSensorList.TabIndex = 0;
            this.TabPage_EditSensorList.Text = "Sensor List";
            // 
            // SplitContainer_SensorList
            // 
            this.SplitContainer_SensorList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainer_SensorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_SensorList.Location = new System.Drawing.Point(3, 3);
            this.SplitContainer_SensorList.Name = "SplitContainer_SensorList";
            // 
            // SplitContainer_SensorList.Panel1
            // 
            this.SplitContainer_SensorList.Panel1.Controls.Add(this.label3);
            this.SplitContainer_SensorList.Panel1.Controls.Add(this.Panel_CustomSensorList);
            this.SplitContainer_SensorList.Panel1.Controls.Add(this.BTN_EditSensorList);
            // 
            // SplitContainer_SensorList.Panel2
            // 
            this.SplitContainer_SensorList.Panel2.Controls.Add(this.label2);
            this.SplitContainer_SensorList.Panel2.Controls.Add(this.Panel_ColumnNames);
            this.SplitContainer_SensorList.Panel2.Controls.Add(this.BTN_EditColumnNames);
            this.SplitContainer_SensorList.Size = new System.Drawing.Size(495, 364);
            this.SplitContainer_SensorList.SplitterDistance = 234;
            this.SplitContainer_SensorList.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sensor List";
            // 
            // BTN_EditSensorList
            // 
            this.BTN_EditSensorList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_EditSensorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.BTN_EditSensorList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_EditSensorList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_EditSensorList.Location = new System.Drawing.Point(176, 6);
            this.BTN_EditSensorList.Name = "BTN_EditSensorList";
            this.BTN_EditSensorList.Size = new System.Drawing.Size(53, 27);
            this.BTN_EditSensorList.TabIndex = 6;
            this.BTN_EditSensorList.Text = "Edit";
            this.BTN_EditSensorList.UseVisualStyleBackColor = false;
            this.BTN_EditSensorList.Click += new System.EventHandler(this.BTN_EditSensorList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(16, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Columns";
            // 
            // Panel_ColumnNames
            // 
            this.Panel_ColumnNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ColumnNames.AutoScroll = true;
            this.Panel_ColumnNames.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_ColumnNames.Location = new System.Drawing.Point(13, 37);
            this.Panel_ColumnNames.Name = "Panel_ColumnNames";
            this.Panel_ColumnNames.Size = new System.Drawing.Size(236, 322);
            this.Panel_ColumnNames.TabIndex = 3;
            // 
            // BTN_EditColumnNames
            // 
            this.BTN_EditColumnNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_EditColumnNames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.BTN_EditColumnNames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_EditColumnNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_EditColumnNames.Location = new System.Drawing.Point(196, 5);
            this.BTN_EditColumnNames.Name = "BTN_EditColumnNames";
            this.BTN_EditColumnNames.Size = new System.Drawing.Size(53, 27);
            this.BTN_EditColumnNames.TabIndex = 6;
            this.BTN_EditColumnNames.Text = "Edit";
            this.BTN_EditColumnNames.UseVisualStyleBackColor = false;
            this.BTN_EditColumnNames.Click += new System.EventHandler(this.BTN_EditColumnNames_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage3.Controls.Add(this.BTN_EditRowSensor);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.BTN_AddNewRow);
            this.tabPage3.Controls.Add(this.BTN_DeleteRow);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.Combo_Rows);
            this.tabPage3.Controls.Add(this.Panel_RowSensor);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(501, 370);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Row Names";
            // 
            // BTN_EditRowSensor
            // 
            this.BTN_EditRowSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_EditRowSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.BTN_EditRowSensor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_EditRowSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_EditRowSensor.Location = new System.Drawing.Point(380, 70);
            this.BTN_EditRowSensor.Name = "BTN_EditRowSensor";
            this.BTN_EditRowSensor.Size = new System.Drawing.Size(57, 28);
            this.BTN_EditRowSensor.TabIndex = 7;
            this.BTN_EditRowSensor.Text = "Edit";
            this.BTN_EditRowSensor.UseVisualStyleBackColor = false;
            this.BTN_EditRowSensor.Click += new System.EventHandler(this.BTN_EditRowSensor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(39, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sensor List";
            // 
            // BTN_AddNewRow
            // 
            this.BTN_AddNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.BTN_AddNewRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_AddNewRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_AddNewRow.Location = new System.Drawing.Point(310, 24);
            this.BTN_AddNewRow.Name = "BTN_AddNewRow";
            this.BTN_AddNewRow.Size = new System.Drawing.Size(69, 28);
            this.BTN_AddNewRow.TabIndex = 2;
            this.BTN_AddNewRow.Text = "Add";
            this.BTN_AddNewRow.UseVisualStyleBackColor = false;
            this.BTN_AddNewRow.Click += new System.EventHandler(this.BTN_AddNewRow_Click);
            // 
            // BTN_DeleteRow
            // 
            this.BTN_DeleteRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.BTN_DeleteRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_DeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DeleteRow.Location = new System.Drawing.Point(385, 24);
            this.BTN_DeleteRow.Name = "BTN_DeleteRow";
            this.BTN_DeleteRow.Size = new System.Drawing.Size(69, 28);
            this.BTN_DeleteRow.TabIndex = 2;
            this.BTN_DeleteRow.Text = "Delete";
            this.BTN_DeleteRow.UseVisualStyleBackColor = false;
            this.BTN_DeleteRow.Click += new System.EventHandler(this.BTN_DeleteRow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(24, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Row Name";
            // 
            // Combo_Rows
            // 
            this.Combo_Rows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Rows.FormattingEnabled = true;
            this.Combo_Rows.Location = new System.Drawing.Point(123, 24);
            this.Combo_Rows.Margin = new System.Windows.Forms.Padding(5);
            this.Combo_Rows.Name = "Combo_Rows";
            this.Combo_Rows.Size = new System.Drawing.Size(159, 28);
            this.Combo_Rows.TabIndex = 0;
            this.Combo_Rows.SelectedIndexChanged += new System.EventHandler(this.Combo_Rows_SelectedIndexChanged);
            // 
            // Panel_RowSensor
            // 
            this.Panel_RowSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_RowSensor.AutoScroll = true;
            this.Panel_RowSensor.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_RowSensor.Location = new System.Drawing.Point(50, 102);
            this.Panel_RowSensor.Name = "Panel_RowSensor";
            this.Panel_RowSensor.Size = new System.Drawing.Size(387, 262);
            this.Panel_RowSensor.TabIndex = 4;
            // 
            // BTN_DeleteGroup
            // 
            this.BTN_DeleteGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.BTN_DeleteGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_DeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DeleteGroup.Location = new System.Drawing.Point(409, 23);
            this.BTN_DeleteGroup.Name = "BTN_DeleteGroup";
            this.BTN_DeleteGroup.Size = new System.Drawing.Size(89, 28);
            this.BTN_DeleteGroup.TabIndex = 2;
            this.BTN_DeleteGroup.Text = "Delete";
            this.BTN_DeleteGroup.UseVisualStyleBackColor = false;
            this.BTN_DeleteGroup.Click += new System.EventHandler(this.BTN_DeleteGroup_Click);
            // 
            // BTN_AutoSetByType
            // 
            this.BTN_AutoSetByType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.BTN_AutoSetByType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_AutoSetByType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_AutoSetByType.Location = new System.Drawing.Point(314, 60);
            this.BTN_AutoSetByType.Name = "BTN_AutoSetByType";
            this.BTN_AutoSetByType.Size = new System.Drawing.Size(89, 40);
            this.BTN_AutoSetByType.TabIndex = 2;
            this.BTN_AutoSetByType.Text = "自動分組";
            this.BTN_AutoSetByType.UseVisualStyleBackColor = false;
            this.BTN_AutoSetByType.Click += new System.EventHandler(this.BTN_AutoSetByType_Click);
            // 
            // Panel_Functions
            // 
            this.Panel_Functions.Controls.Add(this.BTN_Cancel);
            this.Panel_Functions.Controls.Add(this.BTN_SaveGroupParameters);
            this.Panel_Functions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Functions.Location = new System.Drawing.Point(0, 515);
            this.Panel_Functions.Name = "Panel_Functions";
            this.Panel_Functions.Size = new System.Drawing.Size(508, 55);
            this.Panel_Functions.TabIndex = 5;
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BTN_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Cancel.Location = new System.Drawing.Point(298, 5);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(143, 45);
            this.BTN_Cancel.TabIndex = 0;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = false;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // BTN_SaveGroupParameters
            // 
            this.BTN_SaveGroupParameters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTN_SaveGroupParameters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SaveGroupParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SaveGroupParameters.Location = new System.Drawing.Point(54, 5);
            this.BTN_SaveGroupParameters.Name = "BTN_SaveGroupParameters";
            this.BTN_SaveGroupParameters.Size = new System.Drawing.Size(143, 45);
            this.BTN_SaveGroupParameters.TabIndex = 0;
            this.BTN_SaveGroupParameters.Text = "Save";
            this.BTN_SaveGroupParameters.UseVisualStyleBackColor = false;
            this.BTN_SaveGroupParameters.Click += new System.EventHandler(this.BTN_SaveGroupParameters_Click);
            // 
            // Form_HomeGroupSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(508, 570);
            this.ControlBox = false;
            this.Controls.Add(this.TabControl_CustomSetting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Combo_GroupName);
            this.Controls.Add(this.Panel_Functions);
            this.Controls.Add(this.BTN_DeleteGroup);
            this.Controls.Add(this.BTN_AddNewGroup);
            this.Controls.Add(this.BTN_AutoSetByType);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_HomeGroupSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_HomeGroupSetting";
            this.TabControl_CustomSetting.ResumeLayout(false);
            this.TabPage_EditSensorList.ResumeLayout(false);
            this.SplitContainer_SensorList.Panel1.ResumeLayout(false);
            this.SplitContainer_SensorList.Panel1.PerformLayout();
            this.SplitContainer_SensorList.Panel2.ResumeLayout(false);
            this.SplitContainer_SensorList.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_SensorList)).EndInit();
            this.SplitContainer_SensorList.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.Panel_Functions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Combo_GroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_AddNewGroup;
        private System.Windows.Forms.Panel Panel_CustomSensorList;
        private System.Windows.Forms.Panel Panel_Functions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_EditSensorList;
        private System.Windows.Forms.Panel Panel_ColumnNames;
        private System.Windows.Forms.Button BTN_AddNewRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Combo_Rows;
        private System.Windows.Forms.TabControl TabControl_CustomSetting;
        private System.Windows.Forms.TabPage TabPage_EditSensorList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel Panel_RowSensor;
        private System.Windows.Forms.Button BTN_EditRowSensor;
        private System.Windows.Forms.Button BTN_SaveGroupParameters;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Button BTN_DeleteGroup;
        private System.Windows.Forms.Button BTN_DeleteRow;
        private System.Windows.Forms.Button BTN_EditColumnNames;
        private System.Windows.Forms.Button BTN_AutoSetByType;
        private System.Windows.Forms.SplitContainer SplitContainer_SensorList;
    }
}