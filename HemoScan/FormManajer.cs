using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HemoScan
{
    public partial class FormManajer : Form
    {
        // Koneksi terpusat
        SqlConnection conn = DbHelper.GetConnection();

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
            TampilkanLaporan();
        }

        // ============================================================
        // MODUL 8 + MODUL 10: Tampilkan Laporan
        //   - DataSet & DataAdapter (Modul 8)
        //   - Stored Procedure (Modul 10)
        //   - SP dengan OUTPUT parameter (Modul 10)
        // ============================================================
        private void TampilkanLaporan()
        {
            try
            {
                // ---- A. Grid Laporan via SP + DataSet (Modul 8 & 10) ----
                SqlCommand cmdLaporan = new SqlCommand("sp_GetLaporanPermintaan", conn);
                cmdLaporan.CommandType = CommandType.StoredProcedure;

                // Modul 8: DataAdapter mengisi DataSet secara disconnected
                adapterLaporan = new SqlDataAdapter(cmdLaporan);
                if (dsLaporan.Tables.Contains("Laporan")) dsLaporan.Tables.Remove("Laporan");
                adapterLaporan.Fill(dsLaporan, "Laporan");
                dgvLaporan.DataSource = dsLaporan.Tables["Laporan"];

                // ---- B. Hitung Permintaan Pending via SP OUTPUT (Modul 10) ----
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmdPending = new SqlCommand("sp_CountRequestPending", conn);
                cmdPending.CommandType = CommandType.StoredProcedure;

                // Modul 10: Parameter OUTPUT
                SqlParameter pPending = new SqlParameter("@TotalPending", SqlDbType.Int);
                pPending.Direction = ParameterDirection.Output;
                cmdPending.Parameters.Add(pPending);
                cmdPending.ExecuteNonQuery();

                int countPending = (int)cmdPending.Parameters["@TotalPending"].Value;
                lblPermintaan.Text = countPending.ToString();

                // ---- C. Hitung Total Stok via SP OUTPUT (Modul 10) ----
                SqlCommand cmdStok = new SqlCommand("sp_CountStokTersedia", conn);
                cmdStok.CommandType = CommandType.StoredProcedure;

                // Modul 10: Parameter OUTPUT
                SqlParameter pStok = new SqlParameter("@TotalStok", SqlDbType.Int);
                pStok.Direction = ParameterDirection.Output;
                cmdStok.Parameters.Add(pStok);
                cmdStok.ExecuteNonQuery();

                int totalStok = (int)cmdStok.Parameters["@TotalStok"].Value;
                lblTotalStok.Text = totalStok + " kantong";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // ============================================================
        // TOMBOL REFRESH
        // ============================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TampilkanLaporan();
            MessageBox.Show("Data laporan berhasil diperbarui!", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}