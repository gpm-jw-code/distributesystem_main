
namespace DistributedSystem_Main.User_Control
{
    partial class USC_GroupSwitch
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
            this.button1 = new System.Windows.Forms.Button();
            this.FlowPanel_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.FlowPanel_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(12, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Test Button";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FlowPanel_Buttons
            // 
            this.FlowPanel_Buttons.AutoScroll = true;
            this.FlowPanel_Buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(240)))));
            this.FlowPanel_Buttons.Controls.Add(this.button1);
            this.FlowPanel_Buttons.Controls.Add(this.button2);
            this.FlowPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowPanel_Buttons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowPanel_Buttons.Location = new System.Drawing.Point(0, 0);
            this.FlowPanel_Buttons.Name = "FlowPanel_Buttons";
            this.FlowPanel_Buttons.Size = new System.Drawing.Size(933, 90);
            this.FlowPanel_Buttons.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(197, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(12, 11, 12, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 55);
            this.button2.TabIndex = 2;
            this.button2.Text = "Test Button";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // USC_GroupSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.FlowPanel_Buttons);
            this.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.Name = "USC_GroupSwitch";
            this.Size = new System.Drawing.Size(933, 90);
            this.FlowPanel_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Buttons;
        private System.Windows.Forms.Button button2;
    }
}
