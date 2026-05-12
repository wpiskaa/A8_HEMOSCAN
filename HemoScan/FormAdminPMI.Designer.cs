namespace HemoScan
{
    partial class FormAdminPMI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblCari = new System.Windows.Forms.Label();
            this.cmbCariGol = new System.Windows.Forms.ComboBox();
            this.cmbCariRhesus = new System.Windows.Forms.ComboBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblPanelInput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbGol = new System.Windows.Forms.ComboBox();
            this.cmbRhesus = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTampli = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTestInjection = new System.Windows.Forms.Button();
            this.pnlStok = new System.Windows.Forms.Panel();
            this.lblPanelStok = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvDarah = new System.Windows.Forms.DataGridView();
            this.pnlRequest = new System.Windows.Forms.Panel();
            this.lblPanelReq = new System.Windows.Forms.Label();
            this.dgvRequestAdmin = new System.Windows.Forms.DataGridView();
            this.btnProses = new System.Windows.Forms.Button();
            this.bindingNavigatorStok = new System.Windows.Forms.BindingNavigator(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlStok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarah)).BeginInit();
            this.pnlRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorStok)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlHeader.Controls.Add(this.lblAppName);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 60);
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
            this.lblPageTitle.Text = "Dashboard Admin PMI";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(900, 14);
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
            this.pnlSearch.Controls.Add(this.lblCari);
            this.pnlSearch.Controls.Add(this.cmbCariGol);
            this.pnlSearch.Controls.Add(this.cmbCariRhesus);
            this.pnlSearch.Controls.Add(this.btnCari);
            this.pnlSearch.Location = new System.Drawing.Point(12, 72);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(976, 54);
            this.pnlSearch.TabIndex = 1;
            // 
            // lblCari
            // 
            this.lblCari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCari.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblCari.Location = new System.Drawing.Point(10, 16);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(95, 24);
            this.lblCari.TabIndex = 0;
            this.lblCari.Text = "🔍  Filter Stok:";
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
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInput.Controls.Add(this.lblPanelInput);
            this.pnlInput.Controls.Add(this.label1);
            this.pnlInput.Controls.Add(this.label2);
            this.pnlInput.Controls.Add(this.label3);
            this.pnlInput.Controls.Add(this.txtID);
            this.pnlInput.Controls.Add(this.cmbGol);
            this.pnlInput.Controls.Add(this.cmbRhesus);
            this.pnlInput.Controls.Add(this.btnSimpan);
            this.pnlInput.Controls.Add(this.btnUpdate);
            this.pnlInput.Controls.Add(this.btnHapus);
            this.pnlInput.Controls.Add(this.btnTampli);
            this.pnlInput.Controls.Add(this.btnReset);
            this.pnlInput.Controls.Add(this.btnTestInjection);
            this.pnlInput.Location = new System.Drawing.Point(12, 138);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(430, 239);
            this.pnlInput.TabIndex = 2;
            // 
            // lblPanelInput
            // 
            this.lblPanelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPanelInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPanelInput.ForeColor = System.Drawing.Color.White;
            this.lblPanelInput.Location = new System.Drawing.Point(0, 0);
            this.lblPanelInput.Name = "lblPanelInput";
            this.lblPanelInput.Size = new System.Drawing.Size(430, 30);
            this.lblPanelInput.TabIndex = 0;
            this.lblPanelInput.Text = "Form Input Kantong Darah";
            this.lblPanelInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Kantong:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Golongan Darah:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rhesus:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(145, 45);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(265, 31);
            this.txtID.TabIndex = 4;
            // 
            // cmbGol
            // 
            this.cmbGol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGol.FormattingEnabled = true;
            this.cmbGol.Location = new System.Drawing.Point(145, 85);
            this.cmbGol.Name = "cmbGol";
            this.cmbGol.Size = new System.Drawing.Size(265, 33);
            this.cmbGol.TabIndex = 5;
            // 
            // cmbRhesus
            // 
            this.cmbRhesus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRhesus.FormattingEnabled = true;
            this.cmbRhesus.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cmbRhesus.Location = new System.Drawing.Point(145, 125);
            this.cmbRhesus.Name = "cmbRhesus";
            this.cmbRhesus.Size = new System.Drawing.Size(265, 33);
            this.cmbRhesus.TabIndex = 6;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.FlatAppearance.BorderSize = 0;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(10, 158);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(95, 30);
            this.btnSimpan.TabIndex = 7;
            this.btnSimpan.Text = "💾  Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(115, 158);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 30);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "✏  Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapus.FlatAppearance.BorderSize = 0;
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(220, 158);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(95, 30);
            this.btnHapus.TabIndex = 9;
            this.btnHapus.Text = "🗑  Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTampli
            // 
            this.btnTampli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(80)))));
            this.btnTampli.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTampli.FlatAppearance.BorderSize = 0;
            this.btnTampli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampli.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTampli.ForeColor = System.Drawing.Color.White;
            this.btnTampli.Location = new System.Drawing.Point(325, 158);
            this.btnTampli.Name = "btnTampli";
            this.btnTampli.Size = new System.Drawing.Size(95, 30);
            this.btnTampli.TabIndex = 10;
            this.btnTampli.Text = "🔄  Tampilkan";
            this.btnTampli.UseVisualStyleBackColor = false;
            this.btnTampli.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(10, 192);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 31);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "♻  Reset Data";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTestInjection
            // 
            this.btnTestInjection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnTestInjection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestInjection.FlatAppearance.BorderSize = 0;
            this.btnTestInjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestInjection.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnTestInjection.ForeColor = System.Drawing.Color.Yellow;
            this.btnTestInjection.Location = new System.Drawing.Point(140, 192);
            this.btnTestInjection.Name = "btnTestInjection";
            this.btnTestInjection.Size = new System.Drawing.Size(140, 31);
            this.btnTestInjection.TabIndex = 12;
            this.btnTestInjection.Text = "⚠  Injection Demo";
            this.btnTestInjection.UseVisualStyleBackColor = false;
            this.btnTestInjection.Click += new System.EventHandler(this.btnTestInjection_Click);
            // 
            // pnlStok
            // 
            this.pnlStok.BackColor = System.Drawing.Color.White;
            this.pnlStok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStok.Controls.Add(this.lblPanelStok);
            this.pnlStok.Controls.Add(this.lblStatus);
            this.pnlStok.Controls.Add(this.dgvDarah);
            this.pnlStok.Location = new System.Drawing.Point(12, 383);
            this.pnlStok.Name = "pnlStok";
            this.pnlStok.Size = new System.Drawing.Size(976, 267);
            this.pnlStok.TabIndex = 4;
            // 
            // lblPanelStok
            // 
            this.lblPanelStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblPanelStok.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPanelStok.ForeColor = System.Drawing.Color.White;
            this.lblPanelStok.Location = new System.Drawing.Point(0, 0);
            this.lblPanelStok.Name = "lblPanelStok";
            this.lblPanelStok.Size = new System.Drawing.Size(976, 30);
            this.lblPanelStok.TabIndex = 0;
            this.lblPanelStok.Text = "📋  Data Stok Kantong Darah PMI";
            this.lblPanelStok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatus.Location = new System.Drawing.Point(535, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(440, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Total Stok Kantong : 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDarah
            // 
            this.dgvDarah.AllowUserToAddRows = false;
            this.dgvDarah.BackgroundColor = System.Drawing.Color.White;
            this.dgvDarah.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDarah.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDarah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDarah.EnableHeadersVisualStyles = false;
            this.dgvDarah.Location = new System.Drawing.Point(-1, 56);
            this.dgvDarah.Name = "dgvDarah";
            this.dgvDarah.ReadOnly = true;
            this.dgvDarah.RowHeadersWidth = 62;
            this.dgvDarah.RowTemplate.Height = 28;
            this.dgvDarah.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDarah.Size = new System.Drawing.Size(960, 210);
            this.dgvDarah.TabIndex = 2;
            this.dgvDarah.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDarah_CellClick);
            // 
            // pnlRequest
            // 
            this.pnlRequest.BackColor = System.Drawing.Color.White;
            this.pnlRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRequest.Controls.Add(this.lblPanelReq);
            this.pnlRequest.Controls.Add(this.dgvRequestAdmin);
            this.pnlRequest.Controls.Add(this.btnProses);
            this.pnlRequest.Location = new System.Drawing.Point(454, 138);
            this.pnlRequest.Name = "pnlRequest";
            this.pnlRequest.Size = new System.Drawing.Size(534, 195);
            this.pnlRequest.TabIndex = 3;
            // 
            // lblPanelReq
            // 
            this.lblPanelReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.lblPanelReq.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPanelReq.ForeColor = System.Drawing.Color.White;
            this.lblPanelReq.Location = new System.Drawing.Point(0, 0);
            this.lblPanelReq.Name = "lblPanelReq";
            this.lblPanelReq.Size = new System.Drawing.Size(534, 30);
            this.lblPanelReq.TabIndex = 0;
            this.lblPanelReq.Text = "📥  Permintaan Darah Masuk (Pending)";
            this.lblPanelReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvRequestAdmin
            // 
            this.dgvRequestAdmin.AllowUserToAddRows = false;
            this.dgvRequestAdmin.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequestAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequestAdmin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRequestAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequestAdmin.EnableHeadersVisualStyles = false;
            this.dgvRequestAdmin.Location = new System.Drawing.Point(8, 35);
            this.dgvRequestAdmin.Name = "dgvRequestAdmin";
            this.dgvRequestAdmin.ReadOnly = true;
            this.dgvRequestAdmin.RowHeadersWidth = 62;
            this.dgvRequestAdmin.RowTemplate.Height = 26;
            this.dgvRequestAdmin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequestAdmin.Size = new System.Drawing.Size(518, 118);
            this.dgvRequestAdmin.TabIndex = 1;
            // 
            // btnProses
            // 
            this.btnProses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.btnProses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProses.FlatAppearance.BorderSize = 0;
            this.btnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProses.ForeColor = System.Drawing.Color.White;
            this.btnProses.Location = new System.Drawing.Point(368, 158);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(158, 30);
            this.btnProses.TabIndex = 2;
            this.btnProses.Text = "✔  Proses Request";
            this.btnProses.UseVisualStyleBackColor = false;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // bindingNavigatorStok
            // 
            this.bindingNavigatorStok.AddNewItem = null;
            this.bindingNavigatorStok.CountItem = null;
            this.bindingNavigatorStok.DeleteItem = null;
            this.bindingNavigatorStok.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigatorStok.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorStok.MoveFirstItem = null;
            this.bindingNavigatorStok.MoveLastItem = null;
            this.bindingNavigatorStok.MoveNextItem = null;
            this.bindingNavigatorStok.MovePreviousItem = null;
            this.bindingNavigatorStok.Name = "bindingNavigatorStok";
            this.bindingNavigatorStok.PositionItem = null;
            this.bindingNavigatorStok.Size = new System.Drawing.Size(100, 25);
            this.bindingNavigatorStok.TabIndex = 0;
            // 
            // FormAdminPMI
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlRequest);
            this.Controls.Add(this.pnlStok);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "FormAdminPMI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HemoScan - Dashboard Admin PMI";
            this.Load += new System.EventHandler(this.FormAdminPMI_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlStok.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarah)).EndInit();
            this.pnlRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorStok)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel         pnlHeader;
        private System.Windows.Forms.Label         lblAppName;
        private System.Windows.Forms.Label         lblPageTitle;
        private System.Windows.Forms.Button        btnLogout;
        private System.Windows.Forms.Panel         pnlSearch;
        private System.Windows.Forms.Label         lblCari;
        private System.Windows.Forms.ComboBox      cmbCariGol;
        private System.Windows.Forms.ComboBox      cmbCariRhesus;
        private System.Windows.Forms.Button        btnCari;
        private System.Windows.Forms.Panel         pnlInput;
        private System.Windows.Forms.Label         lblPanelInput;
        private System.Windows.Forms.Label         label1;
        private System.Windows.Forms.Label         label2;
        private System.Windows.Forms.Label         label3;
        private System.Windows.Forms.TextBox       txtID;
        private System.Windows.Forms.ComboBox      cmbGol;
        private System.Windows.Forms.ComboBox      cmbRhesus;
        private System.Windows.Forms.Button           btnSimpan;
        private System.Windows.Forms.Button           btnUpdate;
        private System.Windows.Forms.Button           btnHapus;
        private System.Windows.Forms.Button           btnTampli;
        private System.Windows.Forms.Button           btnReset;           // Modul 9
        private System.Windows.Forms.Button           btnTestInjection;   // Modul 9
        private System.Windows.Forms.BindingNavigator bindingNavigatorStok; // Modul 8
        private System.Windows.Forms.Panel            pnlStok;
        private System.Windows.Forms.Label            lblPanelStok;
        private System.Windows.Forms.Label            lblStatus;
        private System.Windows.Forms.DataGridView     dgvDarah;
        private System.Windows.Forms.Panel            pnlRequest;
        private System.Windows.Forms.Label            lblPanelReq;
        private System.Windows.Forms.DataGridView     dgvRequestAdmin;
        private System.Windows.Forms.Button           btnProses;
        // Legacy
        private System.Windows.Forms.GroupBox groupBox1 = new System.Windows.Forms.GroupBox();
        private System.Windows.Forms.GroupBox grpInput  = new System.Windows.Forms.GroupBox();
    }
}
