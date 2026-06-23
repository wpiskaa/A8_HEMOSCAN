using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;

namespace HemoScan
{
    public partial class FormAdminPMI : Form
    {
        // ============================================================
        // MODUL 8: DataSet & DataAdapter — Disconnected Architecture
        // ============================================================
        private SqlDataAdapter  adapterStok;   // Modul 8: DataAdapter stok darah
        private DataSet         dsHemoScan;    // Modul 8: DataSet (cache data lokal)
        private BindingSource   bsStok;        // Modul 8: BindingSource penghubung UI–DataSet

        public FormAdminPMI()
        {
            InitializeComponent();
            // Modul 8: Inisialisasi DataSet dan BindingSource
            dsHemoScan = new DataSet();
            bsStok     = new BindingSource();
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private void FormAdminPMI_Load(object sender, EventArgs e)
        {
            cmbGol.Items.AddRange(new string[] { "A", "B", "AB", "O" });
            cmbGol.SelectedIndex = 0;
            cmbCariGol.Items.AddRange(new string[] { "Semua", "A", "B", "AB", "O" });
            cmbCariGol.SelectedIndex = 0;
            cmbCariRhesus.Items.AddRange(new string[] { "Semua", "+", "-" });
            cmbCariRhesus.SelectedIndex = 0;

            // Style dgvDarah (Stok)
            dgvDarah.BorderStyle = BorderStyle.None;
            dgvDarah.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvDarah.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 230, 242);
            dgvDarah.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvDarah.RowHeadersVisible = false;
            dgvDarah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDarah.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Style dgvRequestAdmin (Permintaan)
            dgvRequestAdmin.BorderStyle = BorderStyle.None;
            dgvRequestAdmin.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(254, 245, 235);
            dgvRequestAdmin.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(252, 220, 190);
            dgvRequestAdmin.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvRequestAdmin.RowHeadersVisible = false;
            dgvRequestAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequestAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Modul 8: Hubungkan BindingNavigator ke BindingSource
            if (bindingNavigatorStok != null)
                bindingNavigatorStok.BindingSource = bsStok;

            // Muat semua data pertama kali
            LoadDataStokViaAdapter();
            TampilRequestMasuk_SP();
            UpdateTotalStok_SP();
        }

        // ============================================================
        // MODUL 8+9: Load Data Stok via SqlDataAdapter + DataSet + BindingSource
        // Menggunakan VIEW vw_StokDarahPublik (Modul 9) sebagai sumber data
        // ============================================================
        private void LoadDataStokViaAdapter()
        {
            try
            {
                // Modul 9: Baca dari VIEW vw_StokDarahPublik — hanya kolom publik
                string query = "SELECT * FROM vw_StokDarahPublik ORDER BY ID_Kantong";

                // Gunakan koneksi baru (using) agar tidak berbenturan dengan SP lain
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    adapterStok = new SqlDataAdapter(query, conn);

                    // Modul 8: Fill() — DataAdapter buka koneksi, isi DataSet, tutup sendiri
                    if (dsHemoScan.Tables.Contains("Stok"))
                        dsHemoScan.Tables.Remove("Stok");

                    adapterStok.Fill(dsHemoScan, "Stok");
                }

                // Modul 8: Hubungkan BindingSource ke DataTable dalam DataSet
                bsStok.DataSource = dsHemoScan.Tables["Stok"];

                // Modul 8: DataGridView terhubung ke BindingSource
                dgvDarah.DataSource = bsStok;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data stok:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MODUL 9+10: Tampil Request Masuk via VIEW vw_RequestPending
        // ============================================================
        private void TampilRequestMasuk_SP()
        {
            try
            {
                // Modul 9: SELECT dari VIEW vw_RequestPending (sudah menyaring Status = 'Pending')
                string query = "SELECT * FROM vw_RequestPending ORDER BY Tanggal_Request DESC";

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRequestAdmin.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat request:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MODUL 10: Update Label Total Stok via SP dengan OUTPUT Parameter
        // ============================================================
        private void UpdateTotalStok_SP()
        {
            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Modul 10: SP dengan OUTPUT parameter
                    SqlCommand cmd = new SqlCommand("sp_CountStokTersedia", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramOut = new SqlParameter("@TotalStok", SqlDbType.Int);
                    paramOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramOut);
                    cmd.ExecuteNonQuery();

                    // Modul 10: Baca nilai OUTPUT parameter setelah eksekusi
                    int total = (int)cmd.Parameters["@TotalStok"].Value;
                    lblStatus.Text = "Total Stok Kantong Tersedia: " + total;
                }
            }
            catch { /* Biarkan label tidak berubah jika error */ }
        }

        // ============================================================
        // TOMBOL TAMPILKAN — Refresh semua data
        // ============================================================
        private void btnTampil_Click(object sender, EventArgs e)
        {
            LoadDataStokViaAdapter();
            TampilRequestMasuk_SP();
            UpdateTotalStok_SP();
        }

        // ============================================================
        // TOMBOL SIMPAN (INSERT) via Stored Procedure — Modul 10
        // ============================================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbGol.Text))
            {
                MessageBox.Show("Golongan darah harus dipilih!", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbRhesus.Text))
            {
                MessageBox.Show("Field Rhesus tidak boleh kosong!", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRhesus.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Modul 10: Panggil SP INSERT — ID_Kantong di-generate otomatis oleh IDENTITY
                    SqlCommand cmd = new SqlCommand("sp_InsertKantongDarah", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Gol_Darah", cmbGol.Text);
                    cmd.Parameters.AddWithValue("@Rhesus",    cmbRhesus.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID_Unit",   1); // PMI = ID 1
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Data kantong darah berhasil disimpan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                BersihkanForm();
                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal simpan:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TOMBOL UPDATE via Stored Procedure — Modul 10
        // ============================================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Pilih data dari tabel terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbRhesus.Text))
            {
                MessageBox.Show("Field Rhesus tidak boleh kosong!", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin mengubah data kantong darah ini?",
                "Konfirmasi Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Modul 10: Panggil SP UPDATE
                    SqlCommand cmd = new SqlCommand("sp_UpdateKantongDarah", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Kantong", txtID.Text);
                    cmd.Parameters.AddWithValue("@Gol_Darah",  cmbGol.Text);
                    cmd.Parameters.AddWithValue("@Rhesus",     cmbRhesus.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                BersihkanForm();
                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TOMBOL HAPUS via Stored Procedure — Modul 10
        // ============================================================
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Pilih data dari tabel terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin menghapus data kantong darah ini?\nAksi ini tidak dapat dibatalkan.",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (konfirmasi == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Modul 10: Panggil SP DELETE
                    SqlCommand cmd = new SqlCommand("sp_DeleteKantongDarah", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Kantong", txtID.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil dihapus!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                BersihkanForm();
                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TOMBOL CARI via Stored Procedure — Modul 10
        // sp_CariStokDarah — SP SELECT dengan parameter input filter
        // ============================================================
        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    // Modul 10: Panggil SP CARI dengan parameter filter
                    SqlCommand cmd = new SqlCommand("sp_CariStokDarah", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Gol_Darah", cmbCariGol.Text);
                    cmd.Parameters.AddWithValue("@Rhesus",    cmbCariRhesus.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    // Modul 8: Gunakan DataSet untuk menyimpan hasil pencarian
                    DataSet dsHasil = new DataSet();
                    da.Fill(dsHasil, "Hasil");

                    // Modul 8: Update BindingSource dengan data hasil pencarian
                    bsStok.DataSource = dsHasil.Tables["Hasil"];
                    dgvDarah.DataSource = bsStok;

                    lblStatus.Text = "Hasil Pencarian: " + dsHasil.Tables["Hasil"].Rows.Count + " data ditemukan";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // KLIK BARIS DI GRID STOK — auto-isi form input
        // ============================================================
        private void dgvDarah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDarah.Rows[e.RowIndex];
                txtID.Text     = row.Cells["ID_Kantong"].Value?.ToString();
                cmbGol.Text    = row.Cells["Gol_Darah"].Value?.ToString();
                cmbRhesus.Text = row.Cells["Rhesus"].Value?.ToString();

                string status = row.Cells["Status"].Value?.ToString();
                if (status != "Tersedia")
                {
                    btnUpdate.Enabled   = false;
                    btnHapus.Enabled    = false;
                    btnUpdate.BackColor = System.Drawing.Color.LightGray;
                    btnHapus.BackColor  = System.Drawing.Color.LightGray;
                }
                else
                {
                    btnUpdate.Enabled   = true;
                    btnHapus.Enabled    = true;
                    btnUpdate.BackColor = System.Drawing.Color.FromArgb(200, 120, 0);
                    btnHapus.BackColor  = System.Drawing.Color.FromArgb(100, 100, 100);
                }
            }
        }

        // ============================================================
        // TOMBOL PROSES REQUEST via Stored Procedure — Modul 10
        // sp_ProsesRequest — SP dengan parameter INPUT + OUTPUT
        // ============================================================
        private void btnProses_Click(object sender, EventArgs e)
        {
            if (dgvRequestAdmin.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih permintaan yang ingin diproses terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idRequest       = dgvRequestAdmin.SelectedRows[0].Cells["ID_Request"].Value?.ToString();
            string namaRS          = dgvRequestAdmin.SelectedRows[0].Cells["Nama_Rumah_Sakit"].Value?.ToString();
            string golDarahLengkap = dgvRequestAdmin.SelectedRows[0].Cells["Golongan_Darah"].Value?.ToString();

            DialogResult konfirmasi = MessageBox.Show(
                $"Proses permintaan darah {golDarahLengkap} dari {namaRS}?",
                "Konfirmasi Proses", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.No) return;

            try
            {
                // Parse golongan darah dan rhesus dari string seperti "A+" atau "AB-"
                string gol = golDarahLengkap.Replace("+", "").Replace("-", "").Trim();
                string rh  = golDarahLengkap.Contains("+") ? "+" :
                             (golDarahLengkap.Contains("-") ? "-" : "");

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Modul 10: SP sp_ProsesRequest — update Tabel_Request & Tabel_Kantong_Darah
                    SqlCommand cmd = new SqlCommand("sp_ProsesRequest", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Request", idRequest);
                    cmd.Parameters.AddWithValue("@Gol_Darah",  gol);
                    cmd.Parameters.AddWithValue("@Rhesus",     rh);

                    SqlParameter pBerhasil = new SqlParameter("@Berhasil", SqlDbType.Bit);
                    pBerhasil.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pBerhasil);

                    SqlParameter pPesan = new SqlParameter("@PesanHasil", SqlDbType.NVarChar, 200);
                    pPesan.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pPesan);

                    cmd.ExecuteNonQuery();

                    bool   berhasil = (bool)cmd.Parameters["@Berhasil"].Value;
                    string pesan    = cmd.Parameters["@PesanHasil"].Value.ToString();

                    if (berhasil)
                        MessageBox.Show(pesan + $"\n({golDarahLengkap} → {namaRS})", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(pesan, "Gagal Proses",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                TampilRequestMasuk_SP();
                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MODUL 9: RESET DATA — Kembalikan data dari tabel backup
        // Menggunakan SqlTransaction: jika restore gagal, DELETE dibatalkan (rollback)
        // ============================================================
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show(
                "⚠ PERHATIAN!\n\nFitur ini akan MENGHAPUS semua data stok darah saat ini\ndan mengembalikannya ke data backup awal.\n\nLanjutkan?",
                "Konfirmasi Reset Data",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (konfirmasi == DialogResult.No) return;

            SqlTransaction transaksi = null;
            SqlConnection  conn      = null;

            try
            {
                conn = DbHelper.GetConnection();
                conn.Open();

                // Modul 9: Bungkus dalam transaksi — jika restore gagal, DELETE dibatalkan
                transaksi = conn.BeginTransaction();

                // Langkah 1: Hapus semua data aktif
                new SqlCommand("DELETE FROM Tabel_Kantong_Darah", conn, transaksi).ExecuteNonQuery();

                // Langkah 2: Aktifkan IDENTITY_INSERT agar ID asli bisa di-restore
                new SqlCommand("SET IDENTITY_INSERT Tabel_Kantong_Darah ON", conn, transaksi).ExecuteNonQuery();

                // Langkah 3: Restore dari backup dengan kolom eksplisit
                new SqlCommand(@"
                    INSERT INTO Tabel_Kantong_Darah
                        (ID_Kantong, Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit)
                    SELECT
                        ID_Kantong, Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit
                    FROM Backup_Kantong_Darah", conn, transaksi).ExecuteNonQuery();

                // Langkah 4: Matikan kembali IDENTITY_INSERT
                new SqlCommand("SET IDENTITY_INSERT Tabel_Kantong_Darah OFF", conn, transaksi).ExecuteNonQuery();

                // Semua berhasil → commit transaksi
                transaksi.Commit();

                MessageBox.Show("Data berhasil direset ke kondisi backup awal!", "Reset Berhasil",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                // Jika ada error → rollback — data TIDAK jadi terhapus
                try { transaksi?.Rollback(); } catch { }

                MessageBox.Show(
                    "Gagal reset data (semua perubahan dibatalkan):\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
        }

        // ============================================================
        // MODUL 9: SIMULASI SQL INJECTION — Demo query TIDAK aman
        // ============================================================
        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            string inputUji = txtID.Text.Trim();
            if (string.IsNullOrEmpty(inputUji))
            {
                MessageBox.Show("Isi txtID dengan nilai uji, contoh:\n' OR 1=1 --\n\nLalu klik tombol ini.",
                    "Petunjuk SQL Injection Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Modul 9: Query TIDAK AMAN — rentan SQL Injection (untuk demonstrasi saja!)
                    string queryTidakAman = "SELECT * FROM Tabel_Kantong_Darah WHERE ID_Kantong = " + inputUji;

                    SqlCommand cmd = new SqlCommand(queryTidakAman, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDarah.DataSource = dt;
                    lblStatus.Text = $"[INJECTION DEMO] Baris terpanggil: {dt.Rows.Count} (INPUT: {inputUji})";

                    MessageBox.Show(
                        $"⚠ HASIL QUERY TIDAK AMAN:\n\nQuery dieksekusi:\n{queryTidakAman}\n\n" +
                        $"Baris yang tampil: {dt.Rows.Count}\n\n" +
                        "Gunakan Parameterized Query untuk mencegah ini!",
                        "SQL Injection Demo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error (mungkin injeksi menyebabkan syntax error): " + ex.Message,
                    "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TOMBOL LOGOUT
        // ============================================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show(
                "Yakin ingin logout?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
                this.Close();
        }

        // ============================================================
        // FUNGSI PEMBANTU: Bersihkan field input
        // ============================================================
        private void BersihkanForm()
        {
            txtID.Clear();
            cmbRhesus.SelectedIndex = -1;
            cmbGol.SelectedIndex    = 0;
            btnUpdate.Enabled       = true;
            btnHapus.Enabled        = true;
            btnUpdate.BackColor     = System.Drawing.Color.FromArgb(200, 120, 0);
            btnHapus.BackColor      = System.Drawing.Color.FromArgb(100, 100, 100);
        }

        // ============================================================
        // UCP 3: TOMBOL UNDUH TEMPLATE EXCEL
        // ============================================================
        private void btnTemplateExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = "Template_Import_Kantong_Darah.xlsx";
                sfd.Title = "Simpan Template Excel Import";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Kantong Darah");
                            
                            // Menulis header kolom (Seluruh Kolom Stok Darah)
                            ws.Cells[1, 1].Value = "Gol_Darah";
                            ws.Cells[1, 2].Value = "Rhesus";
                            ws.Cells[1, 3].Value = "Tgl_Kadaluwarsa";
                            ws.Cells[1, 4].Value = "Status";
                            ws.Cells[1, 5].Value = "ID_Unit";

                            // Contoh baris petunjuk pengisian (12 baris data stok)
                            string[][] sampleData = new string[][] {
                                new string[] { "A", "+", DateTime.Today.AddDays(35).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "O", "-", DateTime.Today.AddDays(30).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "B", "+", DateTime.Today.AddDays(28).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "AB", "+", DateTime.Today.AddDays(32).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "O", "+", DateTime.Today.AddDays(25).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "A", "-", DateTime.Today.AddDays(27).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "B", "-", DateTime.Today.AddDays(24).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "AB", "-", DateTime.Today.AddDays(29).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "A", "+", DateTime.Today.AddDays(40).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "O", "+", DateTime.Today.AddDays(42).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "B", "+", DateTime.Today.AddDays(45).ToString("yyyy-MM-dd"), "Tersedia", "1" },
                                new string[] { "AB", "+", DateTime.Today.AddDays(38).ToString("yyyy-MM-dd"), "Tersedia", "1" }
                            };

                            for (int i = 0; i < sampleData.Length; i++)
                            {
                                int row = i + 2;
                                ws.Cells[row, 1].Value = sampleData[i][0];
                                ws.Cells[row, 2].Value = sampleData[i][1];
                                ws.Cells[row, 3].Value = sampleData[i][2];
                                ws.Cells[row, 4].Value = sampleData[i][3];
                                ws.Cells[row, 5].Value = Convert.ToInt32(sampleData[i][4]);
                            }

                            // Format kolom agar rapi
                            ws.Column(1).Width = 15;
                            ws.Column(2).Width = 15;
                            ws.Column(3).Width = 20;
                            ws.Column(4).Width = 15;
                            ws.Column(5).Width = 15;

                            FileInfo fi = new FileInfo(sfd.FileName);
                            package.SaveAs(fi);
                        }

                        MessageBox.Show("Template Excel berhasil diunduh!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal mengunduh template Excel:\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ============================================================
        // UCP 3: TOMBOL IMPORT EXCEL → DATABASE
        // ============================================================
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                ofd.Title = "Pilih Berkas Excel Data Kantong Darah";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(ofd.FileName);
                        int barisBerhasil = 0;
                        int barisGagal = 0;

                        using (ExcelPackage package = new ExcelPackage(fileInfo))
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets[1];
                            if (ws == null)
                            {
                                MessageBox.Show("File Excel kosong atau tidak memiliki worksheet!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Validasi Header
                            string col1 = ws.Cells[1, 1].Value?.ToString()?.Trim();
                            string col2 = ws.Cells[1, 2].Value?.ToString()?.Trim();
                            string col3 = ws.Cells[1, 3].Value?.ToString()?.Trim();
                            string col4 = ws.Cells[1, 4].Value?.ToString()?.Trim();
                            string col5 = ws.Cells[1, 5].Value?.ToString()?.Trim();

                            if (col1 != "Gol_Darah" || col2 != "Rhesus" || col3 != "Tgl_Kadaluwarsa" || col4 != "Status" || col5 != "ID_Unit")
                            {
                                MessageBox.Show("Format header Excel tidak sesuai! Harus 'Gol_Darah', 'Rhesus', 'Tgl_Kadaluwarsa', 'Status', dan 'ID_Unit'.", 
                                    "Format Tidak Cocok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            int rowCount = ws.Dimension.End.Row;

                            // Gunakan transaksi SQL agar data konsisten jika terjadi error di tengah jalan
                            using (SqlConnection conn = DbHelper.GetConnection())
                            {
                                conn.Open();
                                using (SqlTransaction trans = conn.BeginTransaction())
                                {
                                    try
                                    {
                                        for (int row = 2; row <= rowCount; row++)
                                        {
                                            string golDarah = ws.Cells[row, 1].Value?.ToString()?.Trim()?.ToUpper();
                                            string rhesus = ws.Cells[row, 2].Value?.ToString()?.Trim();
                                            string tglStr = ws.Cells[row, 3].Value?.ToString()?.Trim();
                                            string status = ws.Cells[row, 4].Value?.ToString()?.Trim();
                                            string unitStr = ws.Cells[row, 5].Value?.ToString()?.Trim();

                                            if (string.IsNullOrEmpty(golDarah) || string.IsNullOrEmpty(rhesus))
                                                continue; // lewati baris kosong

                                            // Validasi Golongan Darah & Rhesus
                                            if (golDarah != "A" && golDarah != "B" && golDarah != "AB" && golDarah != "O")
                                            {
                                                barisGagal++;
                                                continue;
                                            }
                                            if (rhesus != "+" && rhesus != "-")
                                            {
                                                barisGagal++;
                                                continue;
                                            }

                                            // Parse Tgl_Kadaluwarsa
                                            DateTime tglKadaluwarsa;
                                            if (string.IsNullOrEmpty(tglStr))
                                            {
                                                tglKadaluwarsa = DateTime.Today.AddDays(35);
                                            }
                                            else if (!DateTime.TryParse(tglStr, out tglKadaluwarsa))
                                            {
                                                // Coba parsing dari format numeric serial date milik Excel
                                                double dateSerial;
                                                if (double.TryParse(tglStr, out dateSerial))
                                                {
                                                    tglKadaluwarsa = DateTime.FromOADate(dateSerial);
                                                }
                                                else
                                                {
                                                    barisGagal++;
                                                    continue;
                                                }
                                            }

                                            // Status
                                            if (string.IsNullOrEmpty(status))
                                            {
                                                status = "Tersedia";
                                            }

                                            // ID Unit
                                            int idUnit = 1;
                                            if (!string.IsNullOrEmpty(unitStr) && !int.TryParse(unitStr, out idUnit))
                                            {
                                                barisGagal++;
                                                continue;
                                            }

                                            // Panggil Stored Procedure sp_InsertKantongDarah
                                            SqlCommand cmd = new SqlCommand("sp_InsertKantongDarah", conn, trans);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@Gol_Darah", golDarah);
                                            cmd.Parameters.AddWithValue("@Rhesus", rhesus);
                                            cmd.Parameters.AddWithValue("@ID_Unit", idUnit); 
                                            cmd.Parameters.AddWithValue("@Tgl_Kadaluwarsa", tglKadaluwarsa);
                                            cmd.Parameters.AddWithValue("@Status", status);

                                            cmd.ExecuteNonQuery();
                                            barisBerhasil++;
                                        }

                                        trans.Commit();
                                    }
                                    catch
                                    {
                                        trans.Rollback();
                                        throw;
                                    }
                                }
                            }
                        }

                        // Refresh Tampilan Grid & Total
                        LoadDataStokViaAdapter();
                        UpdateTotalStok_SP();

                        string infoMsg = $"Import Selesai!\n\nBerhasil dimasukkan: {barisBerhasil} kantong\n";
                        if (barisGagal > 0)
                        {
                            infoMsg += $"Gagal dimasukkan: {barisGagal} baris (karena format data salah)\n\n" +
                                       "Pastikan golongan darah bernilai (A/B/AB/O) dan rhesus bernilai (+/-).";
                        }
                        
                        MessageBox.Show(infoMsg, "Hasil Import Excel", 
                            MessageBoxButtons.OK, barisGagal > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal melakukan import Excel:\n" + ex.Message, "Error Import",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
