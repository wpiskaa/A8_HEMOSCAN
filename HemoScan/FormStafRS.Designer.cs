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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCariGol = new System.Windows.Forms.ComboBox();
            this.cmbCariRhesus = new System.Windows.Forms.ComboBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.pnlStok = new System.Windows.Forms.Panel();
            this.lblPanelStok = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvDarah = new System.Windows.Forms.DataGridView();
            this.btnRequest = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlStok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarah)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
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
            this.lblPageTitle.Size = new System.Drawing.Size(440, 60);
            this.lblPageTitle.TabIndex = 1;
            this.lblPageTitle.Text = "Dashboard Staf Rumah Sakit";
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
            this.btnLogout.Location = new System.Drawing.Point(798, 14);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 32);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "⏻  Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.cmbCariGol);
            this.pnlSearch.Controls.Add(this.cmbCariRhesus);
            this.pnlSearch.Controls.Add(this.btnCari);
            this.pnlSearch.Location = new System.Drawing.Point(12, 72);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(876, 54);
            this.pnlSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "🔍  Filter Stok:";
            // 
            // cmbCariGol
            // 
            this.cmbCariGol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariGol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCariGol.FormattingEnabled = true;
            this.cmbCariGol.Location = new System.Drawing.Point(112, 14);
            this.cmbCariGol.Name = "cmbCariGol";
            this.cmbCariGol.Size = new System.Drawing.Size(130, 33);
            this.cmbCariGol.TabIndex = 1;
            // 
            // cmbCariRhesus
            // 
            this.cmbCariRhesus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariRhesus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCariRhesus.FormattingEnabled = true;
            this.cmbCariRhesus.Location = new System.Drawing.Point(255, 14);
            this.cmbCariRhesus.Name = "cmbCariRhesus";
            this.cmbCariRhesus.Size = new System.Drawing.Size(110, 33);
            this.cmbCariRhesus.TabIndex = 2;
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(188)))));
            this.btnCari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCari.FlatAppearance.BorderSize = 0;
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCari.ForeColor = System.Drawing.Color.White;
            this.btnCari.Location = new System.Drawing.Point(378, 13);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(80, 28);
            this.btnCari.TabIndex = 3;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // pnlStok
            // 
            this.pnlStok.BackColor = System.Drawing.Color.White;
            this.pnlStok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStok.Controls.Add(this.lblPanelStok);
            this.pnlStok.Controls.Add(this.lblStatus);
            this.pnlStok.Controls.Add(this.dgvDarah);
            this.pnlStok.Controls.Add(this.btnRequest);
            this.pnlStok.Location = new System.Drawing.Point(12, 138);
            this.pnlStok.Name = "pnlStok";
            this.pnlStok.Size = new System.Drawing.Size(876, 398);
            this.pnlStok.TabIndex = 2;
            // 
            // lblPanelStok
            // 
            this.lblPanelStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPanelStok.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPanelStok.ForeColor = System.Drawing.Color.White;
            this.lblPanelStok.Location = new System.Drawing.Point(3, -1);
            this.lblPanelStok.Name = "lblPanelStok";
            this.lblPanelStok.Size = new System.Drawing.Size(876, 30);
            this.lblPanelStok.TabIndex = 0;
            this.lblPanelStok.Text = "📋  Ketersediaan Stok Darah PMI";
            this.lblPanelStok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatus.Location = new System.Drawing.Point(10, 36);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(350, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Total Stok Darah Tersedia : 0 kantong";
            // 
            // dgvDarah
            // 
            this.dgvDarah.AllowUserToAddRows = false;
            this.dgvDarah.BackgroundColor = System.Drawing.Color.White;
            this.dgvDarah.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDarah.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDarah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDarah.EnableHeadersVisualStyles = false;
            this.dgvDarah.Location = new System.Drawing.Point(8, 60);
            this.dgvDarah.Name = "dgvDarah";
            this.dgvDarah.ReadOnly = true;
            this.dgvDarah.RowHeadersWidth = 62;
            this.dgvDarah.RowTemplate.Height = 28;
            this.dgvDarah.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDarah.Size = new System.Drawing.Size(860, 290);
            this.dgvDarah.TabIndex = 2;
            // 
            // btnRequest
            // 
            this.btnRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.btnRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequest.FlatAppearance.BorderSize = 0;
            this.btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRequest.ForeColor = System.Drawing.Color.White;
            this.btnRequest.Location = new System.Drawing.Point(660, 356);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(200, 36);
            this.btnRequest.TabIndex = 3;
            this.btnRequest.Text = "🩸  Request Darah ke PMI";
            this.btnRequest.UseVisualStyleBackColor = false;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // FormStafRS
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlStok);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "FormStafRS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HemoScan - Dashboard Staf RS";
            this.Load += new System.EventHandler(this.FormStafRS_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlStok.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarah)).EndInit();
            this.ResumeLayout(false);

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