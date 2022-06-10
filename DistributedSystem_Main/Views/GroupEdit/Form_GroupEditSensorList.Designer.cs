
namespace DistributedSystem_Main.Views
{
    partial class Form_GroupEditSensorList
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
            this.label1 = new System.Windows.Forms.Label();
            this.Panel_AllSensorName = new System.Windows.Forms.Panel();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.TXT_GroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Name:";
            // 
            // Panel_AllSensorName
            // 
            this.Panel_AllSensorName.AutoScroll = true;
            this.Panel_AllSensorName.BackColor = System.Drawing.Color.White;
            this.Panel_AllSensorName.Location = new System.Drawing.Point(27, 102);
            this.Panel_AllSensorName.Name = "Panel_AllSensorName";
            this.Panel_AllSensorName.Size = new System.Drawing.Size(337, 268);
            this.Panel_AllSensorName.TabIndex = 1;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(42, 386);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(98, 42);
            this.BTN_Save.TabIndex = 2;
            this.BTN_Save.Text = "Save";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Location = new System.Drawing.Point(245, 386);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(98, 42);
            this.BTN_Cancel.TabIndex = 2;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // TXT_GroupName
            // 
            this.TXT_GroupName.Location = new System.Drawing.Point(146, 23);
            this.TXT_GroupName.Name = "TXT_GroupName";
            this.TXT_GroupName.Size = new System.Drawing.Size(185, 29);
            this.TXT_GroupName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sensor List:";
            // 
            // Form_GroupEditSensorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXT_GroupName);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.Panel_AllSensorName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_GroupEditSensorList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_GroupEditSensorList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Panel_AllSensorName;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.TextBox TXT_GroupName;
        private System.Windows.Forms.Label label2;
    }
}