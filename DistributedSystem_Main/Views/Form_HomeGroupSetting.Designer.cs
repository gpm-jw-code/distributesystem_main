
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
            this.TabControlEX_Main = new DistributedSystem_Main.User_Control.TabControlEx();
            this.TabPage_Custom = new System.Windows.Forms.TabPage();
            this.TabControl_CustomSetting = new System.Windows.Forms.TabControl();
            this.TabPage_EditSensorList = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_EditSensorList = new System.Windows.Forms.Button();
            this.Panel_ColumnNames = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BTN_EditRowSensor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_AddNewRow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Combo_Rows = new System.Windows.Forms.ComboBox();
            this.Panel_RowSensor = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Panel_Functions = new System.Windows.Forms.Panel();
            this.TabControlEX_Main.SuspendLayout();
            this.TabPage_Custom.SuspendLayout();
            this.TabControl_CustomSetting.SuspendLayout();
            this.TabPage_EditSensorList.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Combo_GroupName
            // 
            this.Combo_GroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_GroupName.FormattingEnabled = true;
            this.Combo_GroupName.Location = new System.Drawing.Point(133, 20);
            this.Combo_GroupName.Margin = new System.Windows.Forms.Padding(5);
            this.Combo_GroupName.Name = "Combo_GroupName";
            this.Combo_GroupName.Size = new System.Drawing.Size(149, 25);
            this.Combo_GroupName.TabIndex = 0;
            this.Combo_GroupName.SelectedIndexChanged += new System.EventHandler(this.Combo_GroupName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group Name";
            // 
            // BTN_AddNewGroup
            // 
            this.BTN_AddNewGroup.Location = new System.Drawing.Point(315, 20);
            this.BTN_AddNewGroup.Name = "BTN_AddNewGroup";
            this.BTN_AddNewGroup.Size = new System.Drawing.Size(89, 28);
            this.BTN_AddNewGroup.TabIndex = 2;
            this.BTN_AddNewGroup.Text = "Add";
            this.BTN_AddNewGroup.UseVisualStyleBackColor = true;
            this.BTN_AddNewGroup.Click += new System.EventHandler(this.BTN_AddNewGroup_Click);
            // 
            // Panel_CustomSensorList
            // 
            this.Panel_CustomSensorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_CustomSensorList.AutoScroll = true;
            this.Panel_CustomSensorList.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_CustomSensorList.Location = new System.Drawing.Point(15, 48);
            this.Panel_CustomSensorList.Name = "Panel_CustomSensorList";
            this.Panel_CustomSensorList.Size = new System.Drawing.Size(218, 331);
            this.Panel_CustomSensorList.TabIndex = 3;
            // 
            // TabControlEX_Main
            // 
            this.TabControlEX_Main.Controls.Add(this.TabPage_Custom);
            this.TabControlEX_Main.Controls.Add(this.tabPage2);
            this.TabControlEX_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlEX_Main.Location = new System.Drawing.Point(0, 55);
            this.TabControlEX_Main.Name = "TabControlEX_Main";
            this.TabControlEX_Main.SelectedIndex = 0;
            this.TabControlEX_Main.Size = new System.Drawing.Size(453, 515);
            this.TabControlEX_Main.TabIndex = 4;
            // 
            // TabPage_Custom
            // 
            this.TabPage_Custom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TabPage_Custom.Controls.Add(this.TabControl_CustomSetting);
            this.TabPage_Custom.Controls.Add(this.label1);
            this.TabPage_Custom.Controls.Add(this.Combo_GroupName);
            this.TabPage_Custom.Controls.Add(this.BTN_AddNewGroup);
            this.TabPage_Custom.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.TabPage_Custom.Location = new System.Drawing.Point(-1, 24);
            this.TabPage_Custom.Name = "TabPage_Custom";
            this.TabPage_Custom.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Custom.Size = new System.Drawing.Size(455, 492);
            this.TabPage_Custom.TabIndex = 0;
            this.TabPage_Custom.Text = "Custom";
            // 
            // TabControl_CustomSetting
            // 
            this.TabControl_CustomSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_CustomSetting.Controls.Add(this.TabPage_EditSensorList);
            this.TabControl_CustomSetting.Controls.Add(this.tabPage3);
            this.TabControl_CustomSetting.Location = new System.Drawing.Point(0, 74);
            this.TabControl_CustomSetting.Name = "TabControl_CustomSetting";
            this.TabControl_CustomSetting.SelectedIndex = 0;
            this.TabControl_CustomSetting.Size = new System.Drawing.Size(454, 418);
            this.TabControl_CustomSetting.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl_CustomSetting.TabIndex = 7;
            // 
            // TabPage_EditSensorList
            // 
            this.TabPage_EditSensorList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TabPage_EditSensorList.Controls.Add(this.label2);
            this.TabPage_EditSensorList.Controls.Add(this.label3);
            this.TabPage_EditSensorList.Controls.Add(this.BTN_EditSensorList);
            this.TabPage_EditSensorList.Controls.Add(this.Panel_ColumnNames);
            this.TabPage_EditSensorList.Controls.Add(this.Panel_CustomSensorList);
            this.TabPage_EditSensorList.Location = new System.Drawing.Point(4, 26);
            this.TabPage_EditSensorList.Name = "TabPage_EditSensorList";
            this.TabPage_EditSensorList.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_EditSensorList.Size = new System.Drawing.Size(446, 388);
            this.TabPage_EditSensorList.TabIndex = 0;
            this.TabPage_EditSensorList.Text = "Sensor List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Names";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sensor List";
            // 
            // BTN_EditSensorList
            // 
            this.BTN_EditSensorList.Location = new System.Drawing.Point(187, 17);
            this.BTN_EditSensorList.Name = "BTN_EditSensorList";
            this.BTN_EditSensorList.Size = new System.Drawing.Size(46, 25);
            this.BTN_EditSensorList.TabIndex = 6;
            this.BTN_EditSensorList.Text = "Edit";
            this.BTN_EditSensorList.UseVisualStyleBackColor = true;
            this.BTN_EditSensorList.Click += new System.EventHandler(this.BTN_EditSensorList_Click);
            // 
            // Panel_ColumnNames
            // 
            this.Panel_ColumnNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_ColumnNames.AutoScroll = true;
            this.Panel_ColumnNames.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_ColumnNames.Location = new System.Drawing.Point(256, 48);
            this.Panel_ColumnNames.Name = "Panel_ColumnNames";
            this.Panel_ColumnNames.Size = new System.Drawing.Size(182, 331);
            this.Panel_ColumnNames.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage3.Controls.Add(this.BTN_EditRowSensor);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.BTN_AddNewRow);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.Combo_Rows);
            this.tabPage3.Controls.Add(this.Panel_RowSensor);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(446, 388);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Row Names";
            // 
            // BTN_EditRowSensor
            // 
            this.BTN_EditRowSensor.Location = new System.Drawing.Point(317, 77);
            this.BTN_EditRowSensor.Name = "BTN_EditRowSensor";
            this.BTN_EditRowSensor.Size = new System.Drawing.Size(46, 25);
            this.BTN_EditRowSensor.TabIndex = 7;
            this.BTN_EditRowSensor.Text = "Edit";
            this.BTN_EditRowSensor.UseVisualStyleBackColor = true;
            this.BTN_EditRowSensor.Click += new System.EventHandler(this.BTN_EditRowSensor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sensor List";
            // 
            // BTN_AddNewRow
            // 
            this.BTN_AddNewRow.Location = new System.Drawing.Point(274, 24);
            this.BTN_AddNewRow.Name = "BTN_AddNewRow";
            this.BTN_AddNewRow.Size = new System.Drawing.Size(89, 28);
            this.BTN_AddNewRow.TabIndex = 2;
            this.BTN_AddNewRow.Text = "Add";
            this.BTN_AddNewRow.UseVisualStyleBackColor = true;
            this.BTN_AddNewRow.Click += new System.EventHandler(this.BTN_AddNewRow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Row Name";
            // 
            // Combo_Rows
            // 
            this.Combo_Rows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Rows.FormattingEnabled = true;
            this.Combo_Rows.Location = new System.Drawing.Point(117, 24);
            this.Combo_Rows.Margin = new System.Windows.Forms.Padding(5);
            this.Combo_Rows.Name = "Combo_Rows";
            this.Combo_Rows.Size = new System.Drawing.Size(149, 25);
            this.Combo_Rows.TabIndex = 0;
            this.Combo_Rows.SelectedIndexChanged += new System.EventHandler(this.Combo_Rows_SelectedIndexChanged);
            // 
            // Panel_RowSensor
            // 
            this.Panel_RowSensor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_RowSensor.AutoScroll = true;
            this.Panel_RowSensor.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_RowSensor.Location = new System.Drawing.Point(43, 102);
            this.Panel_RowSensor.Name = "Panel_RowSensor";
            this.Panel_RowSensor.Size = new System.Drawing.Size(320, 277);
            this.Panel_RowSensor.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(-1, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Panel_Functions
            // 
            this.Panel_Functions.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Functions.Location = new System.Drawing.Point(0, 0);
            this.Panel_Functions.Name = "Panel_Functions";
            this.Panel_Functions.Size = new System.Drawing.Size(453, 55);
            this.Panel_Functions.TabIndex = 5;
            // 
            // Form_HomeGroupSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(453, 570);
            this.Controls.Add(this.TabControlEX_Main);
            this.Controls.Add(this.Panel_Functions);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_HomeGroupSetting";
            this.Text = "Form_HomeGroupSetting";
            this.TabControlEX_Main.ResumeLayout(false);
            this.TabPage_Custom.ResumeLayout(false);
            this.TabPage_Custom.PerformLayout();
            this.TabControl_CustomSetting.ResumeLayout(false);
            this.TabPage_EditSensorList.ResumeLayout(false);
            this.TabPage_EditSensorList.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Combo_GroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_AddNewGroup;
        private System.Windows.Forms.Panel Panel_CustomSensorList;
        private User_Control.TabControlEx TabControlEX_Main;
        private System.Windows.Forms.TabPage TabPage_Custom;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}