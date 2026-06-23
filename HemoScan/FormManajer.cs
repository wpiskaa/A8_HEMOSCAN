using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HemoScan
{
    public partial class FormManajer : Form
    {
        // ============================================================
        // MODUL 8: Deklarasi DataSet dan DataAdapter
        // ============================================================
        private SqlDataAdapter adapterLaporan;  // Modul 8: DataAdapter laporan
        private DataSet        dsLaporan;       // Modul 8: DataSet sebagai cache lokal

        public FormManajer()
        {
            InitializeComponent();
            // Modul 8: Inisialisasi DataSet
            dsLaporan = new DataSet();
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private void FormManajer_Load(object sender, EventArgs e)
        {
            this.Text = "HemoScan - Dashboard Manajer";
            
            // Programmatically style DataGridView for a premium, clean flat look
            dgvLaporan.BorderStyle = BorderStyle.None;
            dgvLaporan.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvLaporan.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 230, 242);
            dgvLaporan.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvLaporan.RowHeadersVisible = false;
            dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLaporan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            // Programmatically style chart gridlines and palettes
            chartStok.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            chartRequest.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            
            TampilkanLaporan();
        }

        // ============================================================
        // MODUL 8 + MODUL 10: Tampilkan Laporan
        //   - DataSet & DataAdapter (Modul 8)
        //   - Stored Procedure dengan OUTPUT parameter (Modul 10)
        // ============================================================
        private void TampilkanLaporan()
        {
            // ---- A. Grid Laporan via VIEW vw_LaporanPermintaan (Modul 8 + 9) ----
            // Gunakan koneksi TERPISAH untuk DataAdapter agar tidak konflik
            try
            {
                // Modul 8: DataAdapter mengisi DataSet secara disconnected
                // Koneksi baru dibuat khusus agar tidak berbenturan dengan SP di bawah
                using (SqlConnection connAdapter = DbHelper.GetConnection())
                {
                    string queryView = "SELECT * FROM vw_LaporanPermintaan ORDER BY Tanggal_Request DESC";
                    adapterLaporan = new SqlDataAdapter(queryView, connAdapter);

                    if (dsLaporan.Tables.Contains("Laporan"))
                        dsLaporan.Tables.Remove("Laporan");

                    // Modul 8: Fill() membuka koneksi, mengisi DataSet, lalu menutup sendiri
                    adapterLaporan.Fill(dsLaporan, "Laporan");
                }

                // Modul 8: Bind DataTable ke DataGridView melalui DataSet
                dgvLaporan.DataSource = dsLaporan.Tables["Laporan"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ---- B. Hitung Permintaan Pending via SP OUTPUT (Modul 10) ----
            try
            {
                using (SqlConnection connSP = DbHelper.GetConnection())
                {
                    connSP.Open();

                    // Modul 10: Stored Procedure dengan parameter OUTPUT
                    SqlCommand cmdPending = new SqlCommand("sp_CountRequestPending", connSP);
                    cmdPending.CommandType = CommandType.StoredProcedure;

                    SqlParameter pPending = new SqlParameter("@TotalPending", SqlDbType.Int);
                    pPending.Direction = ParameterDirection.Output;
                    cmdPending.Parameters.Add(pPending);
                    cmdPending.ExecuteNonQuery();

                    int countPending = (int)cmdPending.Parameters["@TotalPending"].Value;
                    lblPermintaan.Text = countPending.ToString();
                }
            }
            catch (Exception ex)
            {
                lblPermintaan.Text = "?";
                MessageBox.Show("Gagal menghitung permintaan pending:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ---- C. Hitung Total Stok via SP OUTPUT (Modul 10) ----
            try
            {
                using (SqlConnection connSP = DbHelper.GetConnection())
                {
                    connSP.Open();

                    // Modul 10: Stored Procedure dengan parameter OUTPUT
                    SqlCommand cmdStok = new SqlCommand("sp_CountStokTersedia", connSP);
                    cmdStok.CommandType = CommandType.StoredProcedure;

                    SqlParameter pStok = new SqlParameter("@TotalStok", SqlDbType.Int);
                    pStok.Direction = ParameterDirection.Output;
                    cmdStok.Parameters.Add(pStok);
                    cmdStok.ExecuteNonQuery();

                    int totalStok = (int)cmdStok.Parameters["@TotalStok"].Value;
                    lblTotalStok.Text = totalStok + " kantong";
                }
            }
            catch (Exception ex)
            {
                lblTotalStok.Text = "? kantong";
                MessageBox.Show("Gagal menghitung stok:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ---- D. Muat Data Grafik Dashboard (UCP 3) ----
            LoadDashboardCharts();
        }

        /// <summary>
        /// Mengambil data aggregasi stok dan permintaan darah dari database
        /// untuk divisualisasikan ke kontrol Chart.
        /// </summary>
        private void LoadDashboardCharts()
        {
            // ---- A. Grafik Stok Tersedia per Golongan Darah (Doughnut) ----
            try
            {
                chartStok.Series["Stok"].Points.Clear();
                string queryStok = "SELECT Gol_Darah, COUNT(*) AS Total FROM Tabel_Kantong_Darah WHERE Status = 'Tersedia' GROUP BY Gol_Darah";
                
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStok, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string golDarah = reader["Gol_Darah"].ToString();
                                int total = Convert.ToInt32(reader["Total"]);
                                chartStok.Series["Stok"].Points.AddXY(golDarah, total);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat grafik stok:\n" + ex.Message, "Error Grafik",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ---- B. Grafik Riwayat Permintaan per Golongan Darah (Column) ----
            try
            {
                chartRequest.Series["Permintaan"].Points.Clear();
                string queryReq = "SELECT Golongan_Darah, COUNT(*) AS Total FROM Tabel_Request GROUP BY Golongan_Darah";
                
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryReq, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string golDarah = reader["Golongan_Darah"].ToString();
                                int total = Convert.ToInt32(reader["Total"]);
                                chartRequest.Series["Permintaan"].Points.AddXY(golDarah, total);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat grafik permintaan:\n" + ex.Message, "Error Grafik",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TOMBOL REFRESH
        // ============================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TampilkanLaporan();
            MessageBox.Show("Data laporan dan grafik berhasil diperbarui!", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ============================================================
        // TOMBOL CETAK & EKSPOR LAPORAN
        // ============================================================
        private void btnBukaLaporan_Click(object sender, EventArgs e)
        {
            using (FormLaporan formLaporan = new FormLaporan())
            {
                formLaporan.ShowDialog();
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

        private void lblStatTitle1_Click(object sender, EventArgs e)
        {

        }
    }
}