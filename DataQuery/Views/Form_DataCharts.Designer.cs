
namespace DataQuery.Views
{
    partial class Form_DataCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TablePanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_Chart = new System.Windows.Forms.Panel();
            this.ChartForShow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Panel_Funcions = new System.Windows.Forms.Panel();
            this.LAB_ShowISO = new System.Windows.Forms.Label();
            this.LAB_ShowRawData = new System.Windows.Forms.Label();
            this.LAB_SensorName = new System.Windows.Forms.Label();
            this.Panel_DataType = new System.Windows.Forms.Panel();
            this.TablePanel_Main.SuspendLayout();
            this.Panel_Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForShow)).BeginInit();
            this.Panel_Funcions.SuspendLayout();
            this.Panel_DataType.SuspendLayout();
            this.SuspendLayout();
            // 
            // TablePanel_Main
            // 
            this.TablePanel_Main.ColumnCount = 1;
            this.TablePanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablePanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TablePanel_Main.Controls.Add(this.Panel_Chart, 0, 1);
            this.TablePanel_Main.Controls.Add(this.Panel_Funcions, 0, 0);
            this.TablePanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablePanel_Main.Location = new System.Drawing.Point(0, 0);
            this.TablePanel_Main.Name = "TablePanel_Main";
            this.TablePanel_Main.RowCount = 2;
            this.TablePanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TablePanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanel_Main.Size = new System.Drawing.Size(541, 466);
            this.TablePanel_Main.TabIndex = 0;
            // 
            // Panel_Chart
            // 
            this.Panel_Chart.Controls.Add(this.ChartForShow);
            this.Panel_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Chart.Location = new System.Drawing.Point(3, 53);
            this.Panel_Chart.Name = "Panel_Chart";
            this.Panel_Chart.Size = new System.Drawing.Size(535, 410);
            this.Panel_Chart.TabIndex = 9;
            // 
            // ChartForShow
            // 
            this.ChartForShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(25)))), ((int)(((byte)(28)))));
            this.ChartForShow.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ChartForShow.BorderlineColor = System.Drawing.Color.Transparent;
            this.ChartForShow.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.ChartForShow.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.ChartForShow.BorderSkin.BorderWidth = 0;
            this.ChartForShow.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LabelStyle.Format = "yyyy/MM/dd HH:mm:ss";
            chartArea2.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.ChartForShow.ChartAreas.Add(chartArea2);
            this.ChartForShow.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.ForeColor = System.Drawing.Color.Silver;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.ChartForShow.Legends.Add(legend2);
            this.ChartForShow.Location = new System.Drawing.Point(0, 0);
            this.ChartForShow.Name = "ChartForShow";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ChartForShow.Series.Add(series2);
            this.ChartForShow.Size = new System.Drawing.Size(535, 410);
            this.ChartForShow.TabIndex = 8;
            this.ChartForShow.Text = "chart1";
            this.ChartForShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartForShow_MouseClick);
            this.ChartForShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_DataCharts_MouseDown);
            // 
            // Panel_Funcions
            // 
            this.Panel_Funcions.Controls.Add(this.Panel_DataType);
            this.Panel_Funcions.Controls.Add(this.LAB_SensorName);
            this.Panel_Funcions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Funcions.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Panel_Funcions.Location = new System.Drawing.Point(3, 3);
            this.Panel_Funcions.Name = "Panel_Funcions";
            this.Panel_Funcions.Size = new System.Drawing.Size(535, 44);
            this.Panel_Funcions.TabIndex = 10;
            this.Panel_Funcions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_DataCharts_MouseDown);
            // 
            // LAB_ShowISO
            // 
            this.LAB_ShowISO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LAB_ShowISO.AutoSize = true;
            this.LAB_ShowISO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_ShowISO.ForeColor = System.Drawing.Color.White;
            this.LAB_ShowISO.Location = new System.Drawing.Point(110, 6);
            this.LAB_ShowISO.Name = "LAB_ShowISO";
            this.LAB_ShowISO.Size = new System.Drawing.Size(36, 20);
            this.LAB_ShowISO.TabIndex = 6;
            this.LAB_ShowISO.Text = "ISO";
            this.LAB_ShowISO.Click += new System.EventHandler(this.LAB_ShowISO_Click);
            // 
            // LAB_ShowRawData
            // 
            this.LAB_ShowRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LAB_ShowRawData.AutoSize = true;
            this.LAB_ShowRawData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LAB_ShowRawData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.LAB_ShowRawData.Location = new System.Drawing.Point(13, 5);
            this.LAB_ShowRawData.Name = "LAB_ShowRawData";
            this.LAB_ShowRawData.Size = new System.Drawing.Size(80, 20);
            this.LAB_ShowRawData.TabIndex = 7;
            this.LAB_ShowRawData.Text = "Raw Data";
            this.LAB_ShowRawData.Click += new System.EventHandler(this.LAB_ShowRawData_Click);
            // 
            // LAB_SensorName
            // 
            this.LAB_SensorName.AutoSize = true;
            this.LAB_SensorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.LAB_SensorName.Location = new System.Drawing.Point(9, 15);
            this.LAB_SensorName.Name = "LAB_SensorName";
            this.LAB_SensorName.Size = new System.Drawing.Size(229, 20);
            this.LAB_SensorName.TabIndex = 0;
            this.LAB_SensorName.Text = "Edge-EQName-UnitName-IP";
            // 
            // Panel_DataType
            // 
            this.Panel_DataType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_DataType.Controls.Add(this.LAB_ShowISO);
            this.Panel_DataType.Controls.Add(this.LAB_ShowRawData);
            this.Panel_DataType.Location = new System.Drawing.Point(370, 9);
            this.Panel_DataType.Name = "Panel_DataType";
            this.Panel_DataType.Size = new System.Drawing.Size(164, 34);
            this.Panel_DataType.TabIndex = 8;
            // 
            // Form_DataCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(46)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(541, 466);
            this.Controls.Add(this.TablePanel_Main);
            this.Name = "Form_DataCharts";
            this.Text = "Form_DataCharts";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_DataCharts_MouseDown);
            this.TablePanel_Main.ResumeLayout(false);
            this.Panel_Chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartForShow)).EndInit();
            this.Panel_Funcions.ResumeLayout(false);
            this.Panel_Funcions.PerformLayout();
            this.Panel_DataType.ResumeLayout(false);
            this.Panel_DataType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TablePanel_Main;
        private System.Windows.Forms.Panel Panel_Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartForShow;
        private System.Windows.Forms.Panel Panel_Funcions;
        private System.Windows.Forms.Label LAB_SensorName;
        private System.Windows.Forms.Label LAB_ShowISO;
        private System.Windows.Forms.Label LAB_ShowRawData;
        private System.Windows.Forms.Panel Panel_DataType;
    }
}