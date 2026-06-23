using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HemoScan
{
    public partial class FormStafRS : Form
    {
        // ID Unit RS yang login (default RS Bethesda = ID 2)
        private int    idUnitSaya = 2;
        private string namaRSSaya = "RS Bethesda Yogyakarta";

        // ============================================================
        // MODUL 8: Deklarasi DataSet, DataAdapter, BindingSource
        // ============================================================
        private SqlDataAdapter adapterStok;   // Modul 8: DataAdapter
        private DataSet        dsStok;        // Modul 8: DataSet (cache lokal)
        private BindingSource  bsStok;        // Modul 8: BindingSource penghubung UI-DataSet

        public FormStafRS()
        {
            InitializeComponent();
            // Modul 8: Inisialisasi DataSet dan BindingSource
            dsStok = new DataSet();
            bsStok = new BindingSource();
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private void FormStafRS_Load(object sender, EventArgs e)
        {
            this.Text = "HemoScan - Dashboard Staf RS: " + namaRSSaya;

            // Programmatically style DataGridView for a premium, clean flat look
            dgvDarah.BorderStyle = BorderStyle.None;
            dgvDarah.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvDarah.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 230, 242);
            dgvDarah.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvDarah.RowHeadersVisible = false;
            dgvDarah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDarah.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cmbCariGol.Items.AddRange(new string[] { "Semua", "A", "B", "AB", "O" });
            cmbCariGol.SelectedIndex = 0;
            cmbCariRhesus.Items.AddRange(new string[] { "Semua", "+", "-" });
            cmbCariRhesus.SelectedIndex = 0;

            // Modul 8: Load data via DataAdapter + DataSet
            LoadDataStokViaAdapter("Semua", "Semua");
        }

        // ============================================================
        // MODUL 8: Load Data Stok via SqlDataAdapter (Disconnected)
        // MODUL 10: Gunakan Stored Procedure sp_CariStokDarah
        // ============================================================
        private void LoadDataStokViaAdapter(string filterGol = "Semua", string filterRhesus = "Semua")
        {
            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    // Modul 10: Gunakan SP sebagai sumber data untuk DataAdapter
                    SqlCommand cmd = new SqlCommand("sp_CariStokDarah", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Gol_Darah", filterGol);
                    cmd.Parameters.AddWithValue("@Rhesus",    filterRhesus);

                    // Modul 8: Buat DataAdapter dari perintah SP
                    adapterStok = new SqlDataAdapter(cmd);

                    // Modul 8: Fill() — mengisi DataSet secara disconnected
                    if (dsStok.Tables.Contains("Stok"))
                        dsStok.Tables.Remove("Stok");

                    adapterStok.Fill(dsStok, "Stok");
                }

                // Modul 8: Hubungkan BindingSource ke DataTable dalam DataSet
                bsStok.DataSource = dsStok.Tables["Stok"];

                // Modul 8: DataGridView terhubung ke BindingSource
                dgvDarah.DataSource = bsStok;

                // Hitung total stok dengan SP OUTPUT parameter (Modul 10)
                UpdateLabelStok_SP();

                // Warnai stok kritis (logika UI dari DataSet lokal)
                WarnaiStokKritis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MODUL 10: Update label jumlah stok via SP dengan OUTPUT parameter
        // ============================================================
        private void UpdateLabelStok_SP()
        {
            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_CountStokTersedia", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Modul 10: Parameter OUTPUT
                    SqlParameter paramOut = new SqlParameter("@TotalStok", SqlDbType.Int);
                    paramOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramOut);

                    cmd.ExecuteNonQuery();

                    int total = (int)cmd.Parameters["@TotalStok"].Value;
                    lblStatus.Text = "Total Stok Darah Tersedia: " + total + " kantong";
                }
            }
            catch { }
        }

        // ============================================================
        // WARNAI STOK KRITIS — hitung dari DataSet lokal (Modul 8)
        // Jika stok golongan darah tertentu < 3, warna baris jadi merah
        // ============================================================
        private void WarnaiStokKritis()
        {
            if (dsStok.Tables["Stok"] == null) return;

            foreach (DataGridViewRow row in dgvDarah.Rows)
            {
                if (row.Cells["Gol_Darah"].Value == null) continue;
                string gol = row.Cells["Gol_Darah"].Value.ToString();

                // Modul 8: Gunakan DataTable.Select() dari DataSet (bukan query ulang ke DB)
                DataRow[] hasil = dsStok.Tables["Stok"].Select("Gol_Darah = '" + gol + "'");
                if (hasil.Length < 3)
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        // ============================================================
        // TOMBOL CARI — filter via SP (Modul 10) + DataSet (Modul 8)
        // ============================================================
        private void btnCari_Click(object sender, EventArgs e)
        {
            LoadDataStokViaAdapter(cmbCariGol.Text, cmbCariRhesus.Text);
        }

        // ============================================================
        // TOMBOL REQUEST DARAH — INSERT via Stored Procedure (Modul 10)
        // ============================================================
        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (dgvDarah.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih baris golongan darah yang ingin di-request!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string golDarah   = dgvDarah.SelectedRows[0].Cells["Gol_Darah"].Value?.ToString();
            string rhesus     = dgvDarah.SelectedRows[0].Cells["Rhesus"].Value?.ToString();
            string golLengkap = golDarah + rhesus;

            DialogResult konfirmasi = MessageBox.Show(
                $"Kirim permintaan darah golongan '{golLengkap}' dari {namaRSSaya} ke PMI?",
                "Konfirmasi Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Modul 10: SP sp_InsertRequest — insert ke Tabel_Request
                    SqlCommand cmd = new SqlCommand("sp_InsertRequest", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Golongan_Darah",  golLengkap);
                    cmd.Parameters.AddWithValue("@ID_Unit_Peminta", idUnitSaya);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    $"Request darah '{golLengkap}' dari {namaRSSaya} berhasil dikirim ke PMI!\nTunggu proses dari pihak PMI.",
                    "Request Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengirim request:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
