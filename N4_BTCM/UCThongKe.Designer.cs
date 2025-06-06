﻿using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Thêm using này cho Chart

namespace N4_BTCM
{
    partial class UCThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.btnXemThongKe = new System.Windows.Forms.Button();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblThongKeTheo = new System.Windows.Forms.Label();
            this.cboThongKeTheo = new System.Windows.Forms.ComboBox();
            this.panelChart = new System.Windows.Forms.Panel();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTitle.SuspendLayout();
            this.panelSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1920, 64);
            this.panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1920, 63);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THỐNG KÊ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSelection
            // 
            this.panelSelection.BackColor = System.Drawing.Color.MintCream;
            this.panelSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelection.Controls.Add(this.btnXemThongKe);
            this.panelSelection.Controls.Add(this.lblDenNgay);
            this.panelSelection.Controls.Add(this.dtpDenNgay);
            this.panelSelection.Controls.Add(this.lblTuNgay);
            this.panelSelection.Controls.Add(this.dtpTuNgay);
            this.panelSelection.Controls.Add(this.lblThongKeTheo);
            this.panelSelection.Controls.Add(this.cboThongKeTheo);
            this.panelSelection.Location = new System.Drawing.Point(3, 69);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(637, 266);
            this.panelSelection.TabIndex = 0;
            // 
            // btnXemThongKe
            // 
            this.btnXemThongKe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXemThongKe.BackColor = System.Drawing.Color.Teal;
            this.btnXemThongKe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemThongKe.ForeColor = System.Drawing.Color.White;
            this.btnXemThongKe.Location = new System.Drawing.Point(30, 194);
            this.btnXemThongKe.Name = "btnXemThongKe";
            this.btnXemThongKe.Size = new System.Drawing.Size(150, 40);
            this.btnXemThongKe.TabIndex = 6;
            this.btnXemThongKe.Text = "Xem Thống Kê";
            this.btnXemThongKe.UseVisualStyleBackColor = false;
            this.btnXemThongKe.Click += new System.EventHandler(this.btnXemThongKe_Click);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(200, 50);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(56, 13);
            this.lblDenNgay.TabIndex = 5;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(260, 47);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(100, 20);
            this.dtpDenNgay.TabIndex = 4;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(200, 23);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(49, 13);
            this.lblTuNgay.TabIndex = 3;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(260, 20);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(100, 20);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // lblThongKeTheo
            // 
            this.lblThongKeTheo.AutoSize = true;
            this.lblThongKeTheo.Location = new System.Drawing.Point(15, 23);
            this.lblThongKeTheo.Name = "lblThongKeTheo";
            this.lblThongKeTheo.Size = new System.Drawing.Size(80, 13);
            this.lblThongKeTheo.TabIndex = 1;
            this.lblThongKeTheo.Text = "Thống kê theo:";
            // 
            // cboThongKeTheo
            // 
            this.cboThongKeTheo.FormattingEnabled = true;
            this.cboThongKeTheo.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.cboThongKeTheo.Location = new System.Drawing.Point(100, 20);
            this.cboThongKeTheo.Name = "cboThongKeTheo";
            this.cboThongKeTheo.Size = new System.Drawing.Size(80, 21);
            this.cboThongKeTheo.TabIndex = 0;
            this.cboThongKeTheo.Text = "Ngày";
            // 
            // panelChart
            // 
            this.panelChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChart.Location = new System.Drawing.Point(646, 69);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(1271, 928);
            this.panelChart.TabIndex = 1;
            // 
            // chartThongKe
            // 
            this.chartThongKe.BackColor = System.Drawing.Color.MintCream;
            chartArea1.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend1);
            this.chartThongKe.Location = new System.Drawing.Point(646, 73);
            this.chartThongKe.Name = "chartThongKe";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            this.chartThongKe.Series.Add(series1);
            this.chartThongKe.Size = new System.Drawing.Size(1271, 924);
            this.chartThongKe.TabIndex = 0;
            this.chartThongKe.Text = "Biểu đồ thống kê";
            // 
            // UCThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.chartThongKe);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelSelection);
            this.Controls.Add(this.panelTitle);
            this.Name = "UCThongKe";
            this.Size = new System.Drawing.Size(1920, 1000);
            this.panelTitle.ResumeLayout(false);
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelTitle;
        private Label lblTitle;
        private Panel panelSelection;
        private Label lblThongKeTheo;
        private ComboBox cboThongKeTheo;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Panel panelChart;
        private Chart chartThongKe;
        private Button btnXemThongKe;
    }
}