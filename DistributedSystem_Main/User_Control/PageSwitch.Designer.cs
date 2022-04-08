
namespace DistributedSystem_Main.User_Control
{
    partial class PageSwitch
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
            this.FlowPanel_PageNum = new System.Windows.Forms.FlowLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.BTN_Next = new System.Windows.Forms.Button();
            this.BTN_Preview = new System.Windows.Forms.Button();
            this.FlowPanel_PageNum.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowPanel_PageNum
            // 
            this.FlowPanel_PageNum.AutoSize = true;
            this.FlowPanel_PageNum.BackColor = System.Drawing.Color.Transparent;
            this.FlowPanel_PageNum.Controls.Add(this.button4);
            this.FlowPanel_PageNum.Dock = System.Windows.Forms.DockStyle.Left;
            this.FlowPanel_PageNum.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowPanel_PageNum.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FlowPanel_PageNum.Location = new System.Drawing.Point(46, 0);
            this.FlowPanel_PageNum.Margin = new System.Windows.Forms.Padding(4);
            this.FlowPanel_PageNum.Name = "FlowPanel_PageNum";
            this.FlowPanel_PageNum.Size = new System.Drawing.Size(44, 27);
            this.FlowPanel_PageNum.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 27);
            this.button4.TabIndex = 3;
            this.button4.Text = "11";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // BTN_Next
            // 
            this.BTN_Next.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Next.Dock = System.Windows.Forms.DockStyle.Left;
            this.BTN_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Next.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BTN_Next.Location = new System.Drawing.Point(90, 0);
            this.BTN_Next.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_Next.Name = "BTN_Next";
            this.BTN_Next.Size = new System.Drawing.Size(46, 27);
            this.BTN_Next.TabIndex = 5;
            this.BTN_Next.Text = "Next";
            this.BTN_Next.UseVisualStyleBackColor = false;
            this.BTN_Next.Click += new System.EventHandler(this.BTN_Next_Click);
            // 
            // BTN_Preview
            // 
            this.BTN_Preview.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Preview.Dock = System.Windows.Forms.DockStyle.Left;
            this.BTN_Preview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Preview.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BTN_Preview.Location = new System.Drawing.Point(0, 0);
            this.BTN_Preview.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_Preview.Name = "BTN_Preview";
            this.BTN_Preview.Size = new System.Drawing.Size(46, 27);
            this.BTN_Preview.TabIndex = 6;
            this.BTN_Preview.Text = "Prev";
            this.BTN_Preview.UseVisualStyleBackColor = false;
            this.BTN_Preview.Click += new System.EventHandler(this.BTN_Preview_Click);
            // 
            // PageSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.BTN_Next);
            this.Controls.Add(this.FlowPanel_PageNum);
            this.Controls.Add(this.BTN_Preview);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(0, 27);
            this.Name = "PageSwitch";
            this.Size = new System.Drawing.Size(1003, 27);
            this.FlowPanel_PageNum.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowPanel_PageNum;
        private System.Windows.Forms.Button BTN_Next;
        private System.Windows.Forms.Button BTN_Preview;
        private System.Windows.Forms.Button button4;
    }
}
