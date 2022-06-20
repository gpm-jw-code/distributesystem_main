
namespace DistributedSystem_Main.Views
{
    partial class Form_EditGroupColumns
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
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BTN_MoveUp = new System.Windows.Forms.Button();
            this.BTN_MoveDown = new System.Windows.Forms.Button();
            this.CheckListBox_ColumnNames = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(157, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Group1";
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Cancel.Location = new System.Drawing.Point(198, 378);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(98, 42);
            this.BTN_Cancel.TabIndex = 8;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Save.Location = new System.Drawing.Point(43, 378);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(98, 42);
            this.BTN_Save.TabIndex = 9;
            this.BTN_Save.Text = "Save";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Column Names: ";
            // 
            // BTN_MoveUp
            // 
            this.BTN_MoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_MoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_MoveUp.Location = new System.Drawing.Point(321, 152);
            this.BTN_MoveUp.Name = "BTN_MoveUp";
            this.BTN_MoveUp.Size = new System.Drawing.Size(63, 50);
            this.BTN_MoveUp.TabIndex = 13;
            this.BTN_MoveUp.Text = "Up";
            this.BTN_MoveUp.UseVisualStyleBackColor = true;
            this.BTN_MoveUp.Click += new System.EventHandler(this.BTN_MoveUp_Click);
            // 
            // BTN_MoveDown
            // 
            this.BTN_MoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_MoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_MoveDown.Location = new System.Drawing.Point(321, 242);
            this.BTN_MoveDown.Name = "BTN_MoveDown";
            this.BTN_MoveDown.Size = new System.Drawing.Size(63, 50);
            this.BTN_MoveDown.TabIndex = 13;
            this.BTN_MoveDown.Text = "Down";
            this.BTN_MoveDown.UseVisualStyleBackColor = true;
            this.BTN_MoveDown.Click += new System.EventHandler(this.BTN_MoveDown_Click);
            // 
            // CheckListBox_ColumnNames
            // 
            this.CheckListBox_ColumnNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckListBox_ColumnNames.FormattingEnabled = true;
            this.CheckListBox_ColumnNames.Items.AddRange(new object[] {
            "Column1",
            "Column2"});
            this.CheckListBox_ColumnNames.Location = new System.Drawing.Point(43, 101);
            this.CheckListBox_ColumnNames.Name = "CheckListBox_ColumnNames";
            this.CheckListBox_ColumnNames.Size = new System.Drawing.Size(253, 268);
            this.CheckListBox_ColumnNames.TabIndex = 14;
            this.CheckListBox_ColumnNames.SelectedIndexChanged += new System.EventHandler(this.CheckListBox_ColumnNames_SelectedIndexChanged);
            // 
            // Form_EditGroupColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 432);
            this.Controls.Add(this.CheckListBox_ColumnNames);
            this.Controls.Add(this.BTN_MoveDown);
            this.Controls.Add(this.BTN_MoveUp);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_EditGroupColumns";
            this.Text = "Form_EditGroupColumns";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTN_MoveUp;
        private System.Windows.Forms.Button BTN_MoveDown;
        private System.Windows.Forms.CheckedListBox CheckListBox_ColumnNames;
    }
}