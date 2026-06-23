namespace HemoScan
{
    partial class FormManajer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlStat1 = new System.Windows.Forms.Panel();
            this.lblStatTitle1 = new System.Windows.Forms.Label();
            this.lblPermintaan = new System.Windows.Forms.Label();
            this.pnlStat2 = new System.Windows.Forms.Panel();
            this.lblStatTitle2 = new System.Windows.Forms.Label();
            this.lblTotalStok = new System.Windows.Forms.Label();
            this.pnlLaporan = new System.Windows.Forms.Panel();
            this.lblPanelLap = new System.Windows.Forms.Label();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.btnBukaLaporan = new System.Windows.Forms.Button();
            this.pnlStrip1 = new System.Windows.Forms.Panel();
            this.pnlStrip2 = new System.Windows.Forms.Panel();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.chartStok = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRequest = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlHeader.SuspendLayout();
            this.pnlStat1.SuspendLayout();
            this.pnlStat2.SuspendLayout();
            this.pnlLaporan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.lblAppName);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1250, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(15, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(200, 60);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "🩸 HemoScan";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblPageTitle.Location = new System.Drawing.Point(220, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(550, 60);
            this.lblPageTitle.TabIndex = 1;
            this.lblPageTitle.Text = "Dashboard Manajer — Laporan & Monitoring";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1148, 14);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 32);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "⏻  Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlStat1
            // 
            this.pnlStat1.BackColor = System.Drawing.Color.White;
            this.pnlStat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStat1.Controls.Add(this.pnlStrip1);
            this.pnlStat1.Controls.Add(this.lblStatTitle1);
            this.pnlStat1.Controls.Add(this.lblPermintaan);
            this.pnlStat1.Location = new System.Drawing.Point(12, 72);
            this.pnlStat1.Name = "pnlStat1";
            this.pnlStat1.Size = new System.Drawing.Size(210, 80);
            this.pnlStat1.TabIndex = 1;
            // 
            // pnlStrip1
            // 
            this.pnlStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.pnlStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStrip1.Location = new System.Drawing.Point(0, 0);
            this.pnlStrip1.Name = "pnlStrip1";
            this.pnlStrip1.Size = new System.Drawing.Size(5, 78);
            this.pnlStrip1.TabIndex = 2;
            // 
            // lblStatTitle1
            // 
            this.lblStatTitle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatTitle1.ForeColor = System.Drawing.Color.Gray;
            this.lblStatTitle1.Location = new System.Drawing.Point(15, 10);
            this.lblStatTitle1.Name = "lblStatTitle1";
            this.lblStatTitle1.Size = new System.Drawing.Size(185, 20);
            this.lblStatTitle1.TabIndex = 0;
            this.lblStatTitle1.Text = "⏳ Permintaan Pending";
            this.lblStatTitle1.Click += new System.EventHandler(this.lblStatTitle1_Click);
            // 
            // lblPermintaan
            // 
            this.lblPermintaan.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPermintaan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.lblPermintaan.Location = new System.Drawing.Point(15, 30);
            this.lblPermintaan.Name = "lblPermintaan";
            this.lblPermintaan.Size = new System.Drawing.Size(185, 42);
            this.lblPermintaan.TabIndex = 1;
            this.lblPermintaan.Text = "0";
            this.lblPermintaan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 
            // pnlStat2
            // 
            this.pnlStat2.BackColor = System.Drawing.Color.White;
            this.pnlStat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStat2.Controls.Add(this.pnlStrip2);
            this.pnlStat2.Controls.Add(this.lblStatTitle2);
            this.pnlStat2.Controls.Add(this.lblTotalStok);
            this.pnlStat2.Location = new System.Drawing.Point(235, 72);
            this.pnlStat2.Name = "pnlStat2";
            this.pnlStat2.Size = new System.Drawing.Size(210, 80);
            this.pnlStat2.TabIndex = 2;
            // 
            // pnlStrip2
            // 
            this.pnlStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.pnlStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStrip2.Location = new System.Drawing.Point(0, 0);
            this.pnlStrip2.Name = "pnlStrip2";
            this.pnlStrip2.Size = new System.Drawing.Size(5, 78);
            this.pnlStrip2.TabIndex = 2;
            // 
            // lblStatTitle2
            // 
            this.lblStatTitle2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatTitle2.ForeColor = System.Drawing.Color.Gray;
            this.lblStatTitle2.Location = new System.Drawing.Point(15, 10);
            this.lblStatTitle2.Name = "lblStatTitle2";
            this.lblStatTitle2.Size = new System.Drawing.Size(185, 20);
            this.lblStatTitle2.TabIndex = 0;
            this.lblStatTitle2.Text = "🩸 Total Stok Darah";
            // 
            // lblTotalStok
            // 
            this.lblTotalStok.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalStok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.lblTotalStok.Location = new System.Drawing.Point(15, 32);
            this.lblTotalStok.Name = "lblTotalStok";
            this.lblTotalStok.Size = new System.Drawing.Size(185, 40);
            this.lblTotalStok.TabIndex = 1;
            this.lblTotalStok.Text = "0 kantong";
            this.lblTotalStok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLaporan
            // 
            this.pnlLaporan.BackColor = System.Drawing.Color.White;
            this.pnlLaporan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLaporan.Controls.Add(this.lblPanelLap);
            this.pnlLaporan.Controls.Add(this.dgvLaporan);
            this.pnlLaporan.Controls.Add(this.btnRefresh);
            this.pnlLaporan.Controls.Add(this.btnBukaLaporan);
            this.pnlLaporan.Location = new System.Drawing.Point(12, 165);
            this.pnlLaporan.Name = "pnlLaporan";
            this.pnlLaporan.Size = new System.Drawing.Size(876, 380);
            this.pnlLaporan.TabIndex = 3;
            // 
            // lblPanelLap
            // 
            this.lblPanelLap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPanelLap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPanelLap.ForeColor = System.Drawing.Color.White;
            this.lblPanelLap.Location = new System.Drawing.Point(0, 0);
            this.lblPanelLap.Name = "lblPanelLap";
            this.lblPanelLap.Size = new System.Drawing.Size(876, 30);
            this.lblPanelLap.TabIndex = 0;
            this.lblPanelLap.Text = "📊  Laporan Riwayat Permintaan Darah";
            this.lblPanelLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.AllowUserToAddRows = false;
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLaporan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.EnableHeadersVisualStyles = false;
            this.dgvLaporan.Location = new System.Drawing.Point(8, 40);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.ReadOnly = true;
            this.dgvLaporan.RowHeadersWidth = 62;
            this.dgvLaporan.RowTemplate.Height = 28;
            this.dgvLaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaporan.Size = new System.Drawing.Size(860, 290);
            this.dgvLaporan.TabIndex = 0;
            // 
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(684, 340);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 36);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄  Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBukaLaporan
            // 
            this.btnBukaLaporan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(188)))));
            this.btnBukaLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBukaLaporan.FlatAppearance.BorderSize = 0;
            this.btnBukaLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBukaLaporan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBukaLaporan.ForeColor = System.Drawing.Color.White;
            this.btnBukaLaporan.Location = new System.Drawing.Point(490, 340);
            this.btnBukaLaporan.Name = "btnBukaLaporan";
            this.btnBukaLaporan.Size = new System.Drawing.Size(180, 36);
            this.btnBukaLaporan.TabIndex = 2;
            this.btnBukaLaporan.Text = "🖨️  Cetak Laporan";
            this.btnBukaLaporan.UseVisualStyleBackColor = false;
            this.btnBukaLaporan.Click += new System.EventHandler(this.btnBukaLaporan_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Visible = false;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.White;
            this.pnlDashboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDashboard.Controls.Add(this.lblDashboardTitle);
            this.pnlDashboard.Controls.Add(this.chartStok);
            this.pnlDashboard.Controls.Add(this.chartRequest);
            this.pnlDashboard.Location = new System.Drawing.Point(905, 72);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(330, 533);
            this.pnlDashboard.TabIndex = 5;
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.White;
            this.lblDashboardTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(330, 30);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "📊  Visualisasi Dashboard";
            this.lblDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartStok
            // 
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartArea1.Name = "ChartAreaStok";
            this.chartStok.ChartAreas.Add(chartArea1);
            legend1.Name = "LegendStok";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            this.chartStok.Legends.Add(legend1);
            this.chartStok.Location = new System.Drawing.Point(10, 40);
            this.chartStok.Name = "chartStok";
            series1.ChartArea = "ChartAreaStok";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "LegendStok";
            series1.Name = "Stok";
            this.chartStok.Series.Add(series1);
            this.chartStok.Size = new System.Drawing.Size(310, 230);
            this.chartStok.TabIndex = 1;
            this.chartStok.Text = "Stok Golongan Darah";
            // 
            // chartRequest
            // 
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartArea2.Name = "ChartAreaReq";
            this.chartRequest.ChartAreas.Add(chartArea2);
            legend2.Name = "LegendReq";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            this.chartRequest.Legends.Add(legend2);
            this.chartRequest.Location = new System.Drawing.Point(10, 280);
            this.chartRequest.Name = "chartRequest";
            series2.ChartArea = "ChartAreaReq";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series2.Legend = "LegendReq";
            series2.Name = "Permintaan";
            this.chartRequest.Series.Add(series2);
            this.chartRequest.Size = new System.Drawing.Size(310, 240);
            this.chartRequest.TabIndex = 2;
            this.chartRequest.Text = "Permintaan Golongan Darah";
            // 
            // FormManajer
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1250, 620);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlStat1);
            this.Controls.Add(this.pnlStat2);
            this.Controls.Add(this.pnlLaporan);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1250, 620);
            this.Name = "FormManajer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HemoScan - Dashboard Manajer";
            this.Load += new System.EventHandler(this.FormManajer_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlStat1.ResumeLayout(false);
            this.pnlStat2.ResumeLayout(false);
            this.pnlLaporan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.pnlDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRequest)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel        pnlHeader;
        private System.Windows.Forms.Label        lblAppName;
        private System.Windows.Forms.Label        lblPageTitle;
        private System.Windows.Forms.Button       btnLogout;
        private System.Windows.Forms.Panel        pnlStat1;
        private System.Windows.Forms.Label        lblStatTitle1;
        private System.Windows.Forms.Label        lblPermintaan;
        private System.Windows.Forms.Panel        pnlStat2;
        private System.Windows.Forms.Label        lblStatTitle2;
        private System.Windows.Forms.Label        lblTotalStok;
        private System.Windows.Forms.Panel        pnlLaporan;
        private System.Windows.Forms.Label        lblPanelLap;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Button       btnRefresh;
        private System.Windows.Forms.Label        label1;
        private System.Windows.Forms.Panel        pnlDashboard;
        private System.Windows.Forms.Label        lblDashboardTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStok;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRequest;
        private System.Windows.Forms.Button       btnBukaLaporan;
        private System.Windows.Forms.Panel        pnlStrip1;
        private System.Windows.Forms.Panel        pnlStrip2;
    }
}