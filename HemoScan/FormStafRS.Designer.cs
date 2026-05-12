namespace HemoScan
{
    partial class FormStafRS
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
            this.pnlHeader     = new System.Windows.Forms.Panel();
            this.lblAppName    = new System.Windows.Forms.Label();
            this.lblPageTitle  = new System.Windows.Forms.Label();
            this.btnLogout     = new System.Windows.Forms.Button();

            this.pnlSearch     = new System.Windows.Forms.Panel();
            this.label1        = new System.Windows.Forms.Label();
            this.cmbCariGol    = new System.Windows.Forms.ComboBox();
            this.cmbCariRhesus = new System.Windows.Forms.ComboBox();
            this.btnCari       = new System.Windows.Forms.Button();

            this.pnlStok       = new System.Windows.Forms.Panel();
            this.lblPanelStok  = new System.Windows.Forms.Label();
            this.lblStatus     = new System.Windows.Forms.Label();
            this.dgvDarah      = new System.Windows.Forms.DataGridView();
            this.btnRequest    = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDarah)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlStok.SuspendLayout();
            this.SuspendLayout();

            // ── FORM ──────────────────────────────────────────────────
            this.Text          = "HemoScan - Dashboard Staf RS";
            this.ClientSize    = new System.Drawing.Size(900, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor     = System.Drawing.Color.FromArgb(245, 245, 248);
            this.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize   = new System.Drawing.Size(900, 550);
            this.Name          = "FormStafRS";
            this.Load         += new System.EventHandler(this.FormStafRS_Load);

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

            this.lblPageTitle.Text      = "Dashboard Staf Rumah Sakit";
            this.lblPageTitle.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.lblPageTitle.Location  = new System.Drawing.Point(220, 0);
            this.lblPageTitle.Size      = new System.Drawing.Size(440, 60);
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

            // ── PANEL PENCARIAN ───────────────────────────────────────
            this.pnlSearch.BackColor   = System.Drawing.Color.White;
            this.pnlSearch.Location    = new System.Drawing.Point(12, 72);
            this.pnlSearch.Size        = new System.Drawing.Size(876, 54);
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Name        = "pnlSearch";

            this.label1.Text      = "🔍  Filter Stok:";
            this.label1.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.label1.Location  = new System.Drawing.Point(10, 16);
            this.label1.Size      = new System.Drawing.Size(95, 24);
            this.label1.Name      = "label1";

            this.cmbCariGol.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariGol.FormattingEnabled = true;
            this.cmbCariGol.Location          = new System.Drawing.Point(112, 14);
            this.cmbCariGol.Size              = new System.Drawing.Size(130, 26);
            this.cmbCariGol.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCariGol.Name              = "cmbCariGol";

            this.cmbCariRhesus.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariRhesus.FormattingEnabled = true;
            this.cmbCariRhesus.Location          = new System.Drawing.Point(255, 14);
            this.cmbCariRhesus.Size              = new System.Drawing.Size(110, 26);
            this.cmbCariRhesus.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCariRhesus.Name              = "cmbCariRhesus";

            this.btnCari.Text      = "Cari";
            this.btnCari.Location  = new System.Drawing.Point(378, 13);
            this.btnCari.Size      = new System.Drawing.Size(80, 28);
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.btnCari.ForeColor = System.Drawing.Color.White;
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.FlatAppearance.BorderSize = 0;
            this.btnCari.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCari.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCari.Name      = "btnCari";
            this.btnCari.Click    += new System.EventHandler(this.btnCari_Click);

            this.pnlSearch.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.label1, this.cmbCariGol, this.cmbCariRhesus, this.btnCari
            });

            // ── PANEL STOK ────────────────────────────────────────────
            this.pnlStok.BackColor   = System.Drawing.Color.White;
            this.pnlStok.Location    = new System.Drawing.Point(12, 138);
            this.pnlStok.Size        = new System.Drawing.Size(876, 398);
            this.pnlStok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStok.Name        = "pnlStok";

            this.lblPanelStok.Text      = "📋  Ketersediaan Stok Darah PMI";
            this.lblPanelStok.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPanelStok.ForeColor = System.Drawing.Color.White;
            this.lblPanelStok.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPanelStok.Location  = new System.Drawing.Point(0, 0);
            this.lblPanelStok.Size      = new System.Drawing.Size(876, 30);
            this.lblPanelStok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPanelStok.Name      = "lblPanelStok";

            this.lblStatus.Text      = "Total Stok Darah Tersedia : 0 kantong";
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.lblStatus.Location  = new System.Drawing.Point(10, 36);
            this.lblStatus.Size      = new System.Drawing.Size(350, 20);
            this.lblStatus.Name      = "lblStatus";

            this.dgvDarah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDarah.Location           = new System.Drawing.Point(8, 60);
            this.dgvDarah.Size               = new System.Drawing.Size(860, 290);
            this.dgvDarah.RowTemplate.Height  = 28;
            this.dgvDarah.AllowUserToAddRows  = false;
            this.dgvDarah.ReadOnly            = true;
            this.dgvDarah.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDarah.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.dgvDarah.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDarah.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvDarah.EnableHeadersVisualStyles = false;
            this.dgvDarah.BackgroundColor = System.Drawing.Color.White;
            this.dgvDarah.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this.dgvDarah.Name            = "dgvDarah";

            this.btnRequest.Text      = "🩸  Request Darah ke PMI";
            this.btnRequest.Location  = new System.Drawing.Point(660, 356);
            this.btnRequest.Size      = new System.Drawing.Size(200, 36);
            this.btnRequest.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.btnRequest.ForeColor = System.Drawing.Color.White;
            this.btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequest.FlatAppearance.BorderSize = 0;
            this.btnRequest.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRequest.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRequest.Name      = "btnRequest";
            this.btnRequest.Click    += new System.EventHandler(this.btnRequest_Click);

            this.pnlStok.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPanelStok, this.lblStatus, this.dgvDarah, this.btnRequest
            });

            // ── Tambahkan ke Form ─────────────────────────────────────
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlHeader, this.pnlSearch, this.pnlStok
            });

            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlStok.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarah)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Panel         pnlHeader;
        private System.Windows.Forms.Label         lblAppName;
        private System.Windows.Forms.Label         lblPageTitle;
        private System.Windows.Forms.Button        btnLogout;
        private System.Windows.Forms.Panel         pnlSearch;
        private System.Windows.Forms.Label         label1;
        private System.Windows.Forms.ComboBox      cmbCariGol;
        private System.Windows.Forms.ComboBox      cmbCariRhesus;
        private System.Windows.Forms.Button        btnCari;
        private System.Windows.Forms.Panel         pnlStok;
        private System.Windows.Forms.Label         lblPanelStok;
        private System.Windows.Forms.Label         lblStatus;
        private System.Windows.Forms.DataGridView  dgvDarah;
        private System.Windows.Forms.Button        btnRequest;
        // Legacy labels kept to avoid compile errors
        private System.Windows.Forms.Label         lblTitle = new System.Windows.Forms.Label();
        private System.Windows.Forms.GroupBox      groupBox1 = new System.Windows.Forms.GroupBox();
        private System.Windows.Forms.GroupBox      groupBox2 = new System.Windows.Forms.GroupBox();
    }
}