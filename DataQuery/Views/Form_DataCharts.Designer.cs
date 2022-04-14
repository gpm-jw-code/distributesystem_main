
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TablePanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.ChartForShow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Panel_Chart = new System.Windows.Forms.Panel();
            this.Panel_Funcions = new System.Windows.Forms.Panel();
            this.TablePanel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForShow)).BeginInit();
            this.Panel_Chart.SuspendLayout();
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
            this.TablePanel_Main.Size = new System.Drawing.Size(899, 585);
            this.TablePanel_Main.TabIndex = 0;
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
            chartArea1.AxisX.IsInterlaced = true;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.Format = "hh:mm:ss";
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.ChartForShow.ChartAreas.Add(chartArea1);
            this.ChartForShow.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.Silver;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.ChartForShow.Legends.Add(legend1);
            this.ChartForShow.Location = new System.Drawing.Point(0, 0);
            this.ChartForShow.Name = "ChartForShow";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ChartForShow.Series.Add(series1);
            this.ChartForShow.Size = new System.Drawing.Size(893, 529);
            this.ChartForShow.TabIndex = 8;
            this.ChartForShow.Text = "chart1";
            // 
            // Panel_Chart
            // 
            this.Panel_Chart.Controls.Add(this.ChartForShow);
            this.Panel_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Chart.Location = new System.Drawing.Point(3, 53);
            this.Panel_Chart.Name = "Panel_Chart";
            this.Panel_Chart.Size = new System.Drawing.Size(893, 529);
            this.Panel_Chart.TabIndex = 9;
            // 
            // Panel_Funcions
            // 
            this.Panel_Funcions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Funcions.Location = new System.Drawing.Point(3, 3);
            this.Panel_Funcions.Name = "Panel_Funcions";
            this.Panel_Funcions.Size = new System.Drawing.Size(893, 44);
            this.Panel_Funcions.TabIndex = 10;
            // 
            // Form_DataCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 585);
            this.Controls.Add(this.TablePanel_Main);
            this.Name = "Form_DataCharts";
            this.Text = "Form_DataCharts";
            this.TablePanel_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartForShow)).EndInit();
            this.Panel_Chart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TablePanel_Main;
        private System.Windows.Forms.Panel Panel_Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartForShow;
        private System.Windows.Forms.Panel Panel_Funcions;
    }
}