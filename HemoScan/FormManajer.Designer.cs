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
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblAppName   = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.btnLogout    = new System.Windows.Forms.Button();

            this.pnlStat1     = new System.Windows.Forms.Panel();
            this.lblStatTitle1 = new System.Windows.Forms.Label();
            this.lblPermintaan = new System.Windows.Forms.Label();

            this.pnlStat2     = new System.Windows.Forms.Panel();
            this.lblStatTitle2 = new System.Windows.Forms.Label();
            this.lblTotalStok = new System.Windows.Forms.Label();

            this.pnlLaporan   = new System.Windows.Forms.Panel();
            this.lblPanelLap  = new System.Windows.Forms.Label();
            this.dgvLaporan   = new System.Windows.Forms.DataGridView();
            this.btnRefresh   = new System.Windows.Forms.Button();
            this.label1       = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlStat1.SuspendLayout();
            this.pnlStat2.SuspendLayout();
            this.pnlLaporan.SuspendLayout();
            this.SuspendLayout();

            // ── FORM ──────────────────────────────────────────────────
            this.Text          = "HemoScan - Dashboard Manajer";
            this.ClientSize    = new System.Drawing.Size(900, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor     = System.Drawing.Color.FromArgb(245, 245, 248);
            this.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize   = new System.Drawing.Size(900, 560);
            this.Name          = "FormManajer";
            this.Load         += new System.EventHandler(this.FormManajer_Load);

            // ── PANEL HEADER ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 60;
            this.pnlHeader.Name      = "pnlHeader";

            this.lblAppName.Text      = "🩸 HemoScan";
            this.lblAppName.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location  = new System.Drawing.Point(15, 0);
            this.lblAppName.Size      = new System.Drawing.Size(200, 60);
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAppName.Name      = "lblAppName";

            this.lblPageTitle.Text      = "Dashboard Manajer — Laporan & Monitoring";
            this.lblPageTitle.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.lblPageTitle.Location  = new System.Drawing.Point(220, 0);
            this.lblPageTitle.Size      = new System.Drawing.Size(550, 60);
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPageTitle.Name      = "lblPageTitle";

            this.btnLogout.Text      = "⏻  Logout";
            this.btnLogout.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(140, 0, 0);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Location  = new System.Drawing.Point(798, 14);
            this.btnLogout.Size      = new System.Drawing.Size(88, 32);
            this.btnLogout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Name      = "btnLogout";
            this.btnLogout.Click    += new System.EventHandler(this.btnLogout_Click);

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAppName, this.lblPageTitle, this.btnLogout
            });

            // ── STAT CARD 1 — Permintaan Pending ─────────────────────
            this.pnlStat1.BackColor   = System.Drawing.Color.White;
            this.pnlStat1.Location    = new System.Drawing.Point(12, 72);
            this.pnlStat1.Size        = new System.Drawing.Size(210, 80);
            this.pnlStat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStat1.Name        = "pnlStat1";

            this.lblStatTitle1.Text      = "⏳ Permintaan Pending";
            this.lblStatTitle1.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatTitle1.ForeColor = System.Drawing.Color.Gray;
            this.lblStatTitle1.Location  = new System.Drawing.Point(8, 10);
            this.lblStatTitle1.Size      = new System.Drawing.Size(196, 20);
            this.lblStatTitle1.Name      = "lblStatTitle1";

            this.lblPermintaan.Text      = "0";
            this.lblPermintaan.Font      = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPermintaan.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.lblPermintaan.Location  = new System.Drawing.Point(8, 30);
            this.lblPermintaan.Size      = new System.Drawing.Size(196, 42);
            this.lblPermintaan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPermintaan.Name      = "lblPermintaan";

            this.pnlStat1.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStatTitle1, this.lblPermintaan
            });

            // ── STAT CARD 2 — Total Stok ──────────────────────────────
            this.pnlStat2.BackColor   = System.Drawing.Color.White;
            this.pnlStat2.Location    = new System.Drawing.Point(235, 72);
            this.pnlStat2.Size        = new System.Drawing.Size(210, 80);
            this.pnlStat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStat2.Name        = "pnlStat2";

            this.lblStatTitle2.Text      = "🩸 Total Stok Darah";
            this.lblStatTitle2.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatTitle2.ForeColor = System.Drawing.Color.Gray;
            this.lblStatTitle2.Location  = new System.Drawing.Point(8, 10);
            this.lblStatTitle2.Size      = new System.Drawing.Size(196, 20);
            this.lblStatTitle2.Name      = "lblStatTitle2";

            this.lblTotalStok.Text      = "0 kantong";
            this.lblTotalStok.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalStok.ForeColor = System.Drawing.Color.FromArgb(0, 120, 60);
            this.lblTotalStok.Location  = new System.Drawing.Point(8, 32);
            this.lblTotalStok.Size      = new System.Drawing.Size(196, 40);
            this.lblTotalStok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalStok.Name      = "lblTotalStok";

            this.pnlStat2.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStatTitle2, this.lblTotalStok
            });

            // ── PANEL LAPORAN (Grid) ──────────────────────────────────
            this.pnlLaporan.BackColor   = System.Drawing.Color.White;
            this.pnlLaporan.Location    = new System.Drawing.Point(12, 165);
            this.pnlLaporan.Size        = new System.Drawing.Size(876, 380);
            this.pnlLaporan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLaporan.Name        = "pnlLaporan";

            this.lblPanelLap.Text      = "📊  Laporan Riwayat Permintaan Darah";
            this.lblPanelLap.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPanelLap.ForeColor = System.Drawing.Color.White;
            this.lblPanelLap.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPanelLap.Location  = new System.Drawing.Point(0, 0);
            this.lblPanelLap.Size      = new System.Drawing.Size(876, 30);
            this.lblPanelLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPanelLap.Name      = "lblPanelLap";

            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location           = new System.Drawing.Point(8, 40);
            this.dgvLaporan.Size               = new System.Drawing.Size(860, 290);
            this.dgvLaporan.RowTemplate.Height  = 28;
            this.dgvLaporan.AllowUserToAddRows  = false;
            this.dgvLaporan.ReadOnly            = true;
            this.dgvLaporan.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaporan.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.dgvLaporan.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLaporan.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvLaporan.EnableHeadersVisualStyles = false;
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this.dgvLaporan.Name            = "dgvLaporan";
            this.dgvLaporan.TabIndex        = 0;

            this.btnRefresh.Text      = "🔄  Refresh Data";
            this.btnRefresh.Location  = new System.Drawing.Point(684, 340);
            this.btnRefresh.Size      = new System.Drawing.Size(180, 36);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(0, 120, 60);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Name      = "btnRefresh";
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            this.pnlLaporan.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPanelLap, this.dgvLaporan, this.btnRefresh
            });

            // label1 — legacy placeholder (unused in this redesign, kept to avoid CS error)
            this.label1.Name = "label1"; this.label1.Visible = false;

            // ── Tambahkan ke Form ─────────────────────────────────────
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlHeader, this.pnlStat1, this.pnlStat2, this.pnlLaporan, this.label1
            });

            this.pnlHeader.ResumeLayout(false);
            this.pnlStat1.ResumeLayout(false);
            this.pnlStat2.ResumeLayout(false);
            this.pnlLaporan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
}