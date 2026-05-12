using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HemoScan
{
    public partial class FormAdminPMI : Form
    {
        // ============================================================
        // MODUL 8: DataSet & DataAdapter — Disconnected Architecture
        // Deklarasi SqlDataAdapter dan DataSet di level class
        // agar bisa digunakan oleh BindingNavigator dan BindingSource
        // ============================================================
        private SqlDataAdapter  adapterStok;          // Modul 8: DataAdapter stok darah
        private DataSet         dsHemoScan;           // Modul 8: DataSet (cache data lokal)
        private BindingSource   bsStok;               // Modul 8: BindingSource penghubung UI–DataSet

        // Koneksi terpusat via DbHelper
        SqlConnection conn = DbHelper.GetConnection();

        public FormAdminPMI()
        {
            InitializeComponent();
            // Modul 8: inisialisasi objek DataSet dan BindingSource
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

            // Modul 8: Hubungkan BindingNavigator ke BindingSource
            if (bindingNavigatorStok != null)
                bindingNavigatorStok.BindingSource = bsStok;

            // Muat data pertama kali menggunakan DataAdapter (Modul 8)
            LoadDataStokViaAdapter();
            TampilRequestMasuk_SP();   // Modul 10: via Stored Procedure
            UpdateTotalStok_SP();      // Modul 10: via SP dengan OUTPUT parameter
        }

        // ============================================================
        // MODUL 8: Load Data Stok via SqlDataAdapter + DataSet + BindingSource
        // Method Fill() mengisi DataSet secara disconnected
        // ============================================================
        private void LoadDataStokViaAdapter()
        {
            try
            {
                // Modul 8: Buat SqlDataAdapter dengan query JOIN
                string query = @"
                    SELECT 
                        K.ID_Kantong, K.Gol_Darah, K.Rhesus,
                        K.Tgl_Kadaluwarsa, K.Status,
                        U.Nama_Unit AS [Unit PMI]
                    FROM Tabel_Kantong_Darah K
                    INNER JOIN Tabel_Unit_Medis U ON K.ID_Unit = U.ID_Unit
                    ORDER BY K.ID_Kantong";

                adapterStok = new SqlDataAdapter(query, conn);

                // Modul 8: method Fill() — isi DataSet tanpa koneksi terbuka terus
                if (dsHemoScan.Tables.Contains("Stok")) dsHemoScan.Tables.Remove("Stok");
                adapterStok.Fill(dsHemoScan, "Stok");

                // Modul 8: Hubungkan BindingSource ke DataTable dalam DataSet
                bsStok.DataSource = dsHemoScan.Tables["Stok"];

                // Modul 8: Hubungkan DataGridView ke BindingSource (bukan langsung ke DataTable)
                dgvDarah.DataSource = bsStok;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data stok: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MODUL 10: Tampil Request Masuk via Stored Procedure
        // sp_GetRequestPending — SP SELECT dengan JOIN
        // ============================================================
        private void TampilRequestMasuk_SP()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Modul 10: Panggil SP menggunakan CommandType.StoredProcedure
                SqlCommand cmd = new SqlCommand("sp_GetRequestPending", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRequestAdmin.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat request: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // ============================================================
        // MODUL 10: Update Label Total Stok via SP dengan OUTPUT Parameter
        // sp_CountStokTersedia — SP dengan parameter OUTPUT
        // ============================================================
        private void UpdateTotalStok_SP()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Modul 10: SP dengan OUTPUT parameter
                SqlCommand cmd = new SqlCommand("sp_CountStokTersedia", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Modul 10: Tambahkan parameter OUTPUT
                SqlParameter paramOut = new SqlParameter("@TotalStok", SqlDbType.Int);
                paramOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramOut);

                cmd.ExecuteNonQuery();

                // Modul 10: Baca nilai OUTPUT parameter setelah eksekusi
                int total = (int)cmd.Parameters["@TotalStok"].Value;
                lblStatus.Text = "Total Stok Kantong Tersedia: " + total;
            }
            catch { /* Biarkan label tidak berubah jika error */ }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // ============================================================
        // TOMBOL TAMPILKAN — Refresh semua data
        // ============================================================
        private void btnTampil_Click(object sender, EventArgs e)
        {
            LoadDataStokViaAdapter();   // Modul 8: refresh via DataAdapter
            TampilRequestMasuk_SP();   // Modul 10: via SP
            UpdateTotalStok_SP();      // Modul 10: via SP OUTPUT
        }

        // ============================================================
        // TOMBOL SIMPAN (INSERT) via Stored Procedure — Modul 10
        // ============================================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbRhesus.Text))
            {
                MessageBox.Show("Field Rhesus tidak boleh kosong!", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRhesus.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbGol.Text))
            {
                MessageBox.Show("Golongan darah harus dipilih!", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Modul 10: Panggil SP INSERT dengan parameter input
                SqlCommand cmd = new SqlCommand("sp_InsertKantongDarah", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Gol_Darah", cmbGol.Text);
                cmd.Parameters.AddWithValue("@Rhesus",    cmbRhesus.Text.Trim());
                cmd.Parameters.AddWithValue("@ID_Unit",   1); // PMI = ID 1
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data kantong darah berhasil disimpan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                BersihkanForm();
                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal simpan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
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
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Modul 10: Panggil SP UPDATE
                SqlCommand cmd = new SqlCommand("sp_UpdateKantongDarah", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Kantong", txtID.Text);
                cmd.Parameters.AddWithValue("@Gol_Darah",  cmbGol.Text);
                cmd.Parameters.AddWithValue("@Rhesus",     cmbRhesus.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                BersihkanForm();
                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
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
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Modul 10: Panggil SP DELETE
                SqlCommand cmd = new SqlCommand("sp_DeleteKantongDarah", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Kantong", txtID.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil dihapus!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                BersihkanForm();
                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
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
                if (conn.State == ConnectionState.Closed) conn.Open();

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

                lblStatus.Text = "Hasil Pencarian: " + dsHasil.Tables["Hasil"].Rows.Count + " data";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
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

            string idRequest      = dgvRequestAdmin.SelectedRows[0].Cells["ID_Request"].Value?.ToString();
            string namaRS         = dgvRequestAdmin.SelectedRows[0].Cells["Nama Rumah Sakit"].Value?.ToString();
            string golDarahLengkap = dgvRequestAdmin.SelectedRows[0].Cells["Golongan_Darah"].Value?.ToString();

            DialogResult konfirmasi = MessageBox.Show(
                $"Proses permintaan darah {golDarahLengkap} dari {namaRS}?",
                "Konfirmasi Proses", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.No) return;

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string gol = golDarahLengkap.Replace("+", "").Replace("-", "");
                string rh  = golDarahLengkap.Contains("+") ? "+" : (golDarahLengkap.Contains("-") ? "-" : "");

                // Modul 10: SP dengan OUTPUT parameter berupa BIT dan NVARCHAR
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

                bool berhasil   = (bool)cmd.Parameters["@Berhasil"].Value;
                string pesan    = cmd.Parameters["@PesanHasil"].Value.ToString();

                if (berhasil)
                    MessageBox.Show(pesan + $"\n({golDarahLengkap} → {namaRS})", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(pesan, "Gagal Proses",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TampilRequestMasuk_SP();
                LoadDataStokViaAdapter();
                UpdateTotalStok_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // ============================================================
        // MODUL 9: RESET DATA — Kembalikan data dari tabel backup
        // Menggunakan SqlTransaction: jika restore gagal, DELETE dibatalkan (rollback)
        // Menggunakan IDENTITY_INSERT ON agar ID asli bisa di-restore
        // ============================================================
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show(
                "⚠ PERHATIAN!\n\nFitur ini akan MENGHAPUS semua data stok darah saat ini\ndan mengembalikannya ke data backup awal.\n\nLanjutkan?",
                "Konfirmasi Reset Data",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (konfirmasi == DialogResult.No) return;

            SqlTransaction transaksi = null;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Modul 9: Bungkus dalam transaksi — jika restore gagal, DELETE dibatalkan
                transaksi = conn.BeginTransaction();

                // Langkah 1: Hapus semua data aktif
                SqlCommand cmdHapus = new SqlCommand(
                    "DELETE FROM Tabel_Kantong_Darah", conn, transaksi);
                cmdHapus.ExecuteNonQuery();

                // Langkah 2: Aktifkan IDENTITY_INSERT agar ID asli bisa di-restore
                SqlCommand cmdIdentOn = new SqlCommand(
                    "SET IDENTITY_INSERT Tabel_Kantong_Darah ON", conn, transaksi);
                cmdIdentOn.ExecuteNonQuery();

                // Langkah 3: Restore dari backup dengan kolom eksplisit (tanpa SELECT *)
                SqlCommand cmdRestore = new SqlCommand(@"
                    INSERT INTO Tabel_Kantong_Darah 
                        (ID_Kantong, Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit)
                    SELECT 
                        ID_Kantong, Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit
                    FROM Backup_Kantong_Darah", conn, transaksi);
                cmdRestore.ExecuteNonQuery();

                // Langkah 4: Matikan kembali IDENTITY_INSERT
                SqlCommand cmdIdentOff = new SqlCommand(
                    "SET IDENTITY_INSERT Tabel_Kantong_Darah OFF", conn, transaksi);
                cmdIdentOff.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // ============================================================
        // MODUL 9: SIMULASI SQL INJECTION — Demo query TIDAK aman
        // Tujuan: menunjukkan bahaya query string concatenation
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
                if (conn.State == ConnectionState.Closed) conn.Open();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error (mungkin injeksi menyebabkan syntax error): " + ex.Message,
                    "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
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
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                this.Close();
            }
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
    }
}
