using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HemoScan
{
    public partial class FormLaporan : Form
    {
        public FormLaporan()
        {
            InitializeComponent();
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            cmbLaporan.Items.AddRange(new string[] {
                "Laporan Stok Darah Tersedia",
                "Laporan Permintaan Darah Masuk"
            });
            cmbLaporan.SelectedIndex = 0;
        }

        private void cmbLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            if (cmbLaporan.SelectedIndex == 0)
            {
                GenerateStokReport();
            }
            else
            {
                GeneratePermintaanReport();
            }
        }

        private void GenerateStokReport()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM vw_StokDarahPublik ORDER BY ID_Kantong";
                
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<!DOCTYPE html><html><head><style>");
                sb.AppendLine("body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin: 30px; color: #333; background-color: #fff; }");
                sb.AppendLine(".header-container { display: flex; align-items: center; justify-content: space-between; border-bottom: 3px solid #c00000; padding-bottom: 15px; margin-bottom: 20px; }");
                sb.AppendLine(".title { font-size: 24px; font-weight: bold; color: #c00000; margin: 0; }");
                sb.AppendLine(".subtitle { font-size: 14px; color: #666; margin: 5px 0 0 0; }");
                sb.AppendLine(".meta-info { text-align: right; font-size: 12px; color: #555; }");
                sb.AppendLine(".summary-box { display: inline-block; background-color: #f8f9fa; border-left: 5px solid #00783c; padding: 10px 20px; margin-bottom: 20px; border-radius: 4px; font-size: 14px; font-weight: bold; }");
                sb.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 10px; }");
                sb.AppendLine("th { background-color: #c00000; color: #fff; text-align: left; padding: 10px; font-size: 13px; font-weight: bold; border: 1px solid #c00000; }");
                sb.AppendLine("td { padding: 10px; border: 1px solid #ddd; font-size: 13px; }");
                sb.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
                sb.AppendLine(".footer { margin-top: 50px; text-align: right; font-size: 12px; color: #888; border-top: 1px solid #eee; padding-top: 15px; }");
                sb.AppendLine(".signature { margin-top: 40px; display: inline-block; text-align: center; float: right; width: 200px; font-size: 13px; }");
                sb.AppendLine(".signature-space { height: 60px; }");
                sb.AppendLine("</style></head><body>");

                // Header
                sb.AppendLine("<div class='header-container'>");
                sb.AppendLine("  <div>");
                sb.AppendLine("    <div class='title'>🩸 HEMOSCAN — LAPORAN STOK DARAH</div>");
                sb.AppendLine("    <div class='subtitle'>Unit Pelayanan Donor Darah PMI Kota Yogyakarta</div>");
                sb.AppendLine("  </div>");
                sb.AppendLine("  <div class='meta-info'>");
                sb.AppendLine($"    Tanggal Cetak: {DateTime.Now:dd MMMM yyyy HH:mm}<br>");
                sb.AppendLine("    Klasifikasi: Dokumen Internal");
                sb.AppendLine("  </div>");
                sb.AppendLine("</div>");

                // Summary
                sb.AppendLine($"<div class='summary-box'>Total Stok Tersedia saat ini: {dt.Rows.Count} Kantong Darah</div>");

                // Table
                sb.AppendLine("<table>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <th>ID Kantong</th>");
                sb.AppendLine("    <th>Golongan Darah</th>");
                sb.AppendLine("    <th>Rhesus</th>");
                sb.AppendLine("    <th>Tanggal Kadaluwarsa</th>");
                sb.AppendLine("    <th>Status</th>");
                sb.AppendLine("    <th>Unit PMI</th>");
                sb.AppendLine("  </tr>");

                foreach (DataRow row in dt.Rows)
                {
                    DateTime tglKadaluwarsa = Convert.ToDateTime(row["Tgl_Kadaluwarsa"]);
                    sb.AppendLine("  <tr>");
                    sb.AppendLine($"    <td>{row["ID_Kantong"]}</td>");
                    sb.AppendLine($"    <td><b>{row["Gol_Darah"]}</b></td>");
                    sb.AppendLine($"    <td>{row["Rhesus"]}</td>");
                    sb.AppendLine($"    <td>{tglKadaluwarsa:dd/MM/yyyy}</td>");
                    sb.AppendLine($"    <td><span style='color: green; font-weight: bold;'>{row["Status"]}</span></td>");
                    sb.AppendLine($"    <td>{row["Unit_PMI"]}</td>");
                    sb.AppendLine("  </tr>");
                }
                sb.AppendLine("</table>");

                // Signature
                sb.AppendLine("<div class='signature'>");
                sb.AppendLine("  Yogyakarta, " + DateTime.Now.ToString("dd MMMM yyyy") + "<br>");
                sb.AppendLine("  Mengetahui,<br><b>Kepala Unit PMI Kota</b>");
                sb.AppendLine("  <div class='signature-space'></div>");
                sb.AppendLine("  ( ____________________ )");
                sb.AppendLine("</div>");

                sb.AppendLine("<div style='clear: both;'></div>");
                sb.AppendLine("<div class='footer'>Laporan ini digenerate secara otomatis oleh Sistem Manajemen HemoScan.</div>");
                sb.AppendLine("</body></html>");

                wbReport.DocumentText = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan stok:\n" + ex.Message, "Error Laporan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneratePermintaanReport()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM vw_LaporanPermintaan ORDER BY Tanggal_Request DESC";
                
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<!DOCTYPE html><html><head><style>");
                sb.AppendLine("body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin: 30px; color: #333; background-color: #fff; }");
                sb.AppendLine(".header-container { display: flex; align-items: center; justify-content: space-between; border-bottom: 3px solid #c00000; padding-bottom: 15px; margin-bottom: 20px; }");
                sb.AppendLine(".title { font-size: 24px; font-weight: bold; color: #c00000; margin: 0; }");
                sb.AppendLine(".subtitle { font-size: 14px; color: #666; margin: 5px 0 0 0; }");
                sb.AppendLine(".meta-info { text-align: right; font-size: 12px; color: #555; }");
                sb.AppendLine(".summary-box { display: inline-block; background-color: #f8f9fa; border-left: 5px solid #a05000; padding: 10px 20px; margin-bottom: 20px; border-radius: 4px; font-size: 14px; font-weight: bold; }");
                sb.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 10px; }");
                sb.AppendLine("th { background-color: #c00000; color: #fff; text-align: left; padding: 10px; font-size: 13px; font-weight: bold; border: 1px solid #c00000; }");
                sb.AppendLine("td { padding: 10px; border: 1px solid #ddd; font-size: 13px; }");
                sb.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
                sb.AppendLine(".footer { margin-top: 50px; text-align: right; font-size: 12px; color: #888; border-top: 1px solid #eee; padding-top: 15px; }");
                sb.AppendLine(".signature { margin-top: 40px; display: inline-block; text-align: center; float: right; width: 200px; font-size: 13px; }");
                sb.AppendLine(".signature-space { height: 60px; }");
                sb.AppendLine("</style></head><body>");

                // Header
                sb.AppendLine("<div class='header-container'>");
                sb.AppendLine("  <div>");
                sb.AppendLine("    <div class='title'>🩸 HEMOSCAN — LAPORAN PERMINTAAN DARAH</div>");
                sb.AppendLine("    <div class='subtitle'>Riwayat Distribusi Darah Ke Rumah Sakit Mitra</div>");
                sb.AppendLine("  </div>");
                sb.AppendLine("  <div class='meta-info'>");
                sb.AppendLine($"    Tanggal Cetak: {DateTime.Now:dd MMMM yyyy HH:mm}<br>");
                sb.AppendLine("    Klasifikasi: Dokumen Internal");
                sb.AppendLine("  </div>");
                sb.AppendLine("</div>");

                // Summary
                sb.AppendLine($"<div class='summary-box'>Total Log Permintaan Terdaftar: {dt.Rows.Count} Transaksi</div>");

                // Table
                sb.AppendLine("<table>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <th>ID Request</th>");
                sb.AppendLine("    <th>Golongan Darah</th>");
                sb.AppendLine("    <th>Status Permintaan</th>");
                sb.AppendLine("    <th>Tanggal Request</th>");
                sb.AppendLine("    <th>Rumah Sakit Peminta</th>");
                sb.AppendLine("    <th>Alamat RS</th>");
                sb.AppendLine("  </tr>");

                foreach (DataRow row in dt.Rows)
                {
                    DateTime tglRequest = Convert.ToDateTime(row["Tanggal_Request"]);
                    string status = row["Status_Permintaan"].ToString();
                    string color = status == "Pending" ? "orange" : "blue";
                    
                    sb.AppendLine("  <tr>");
                    sb.AppendLine($"    <td>{row["ID_Request"]}</td>");
                    sb.AppendLine($"    <td><b>{row["Golongan_Darah"]}</b></td>");
                    sb.AppendLine($"    <td><span style='color: {color}; font-weight: bold;'>{status}</span></td>");
                    sb.AppendLine($"    <td>{tglRequest:dd/MM/yyyy HH:mm}</td>");
                    sb.AppendLine($"    <td>{row["Nama_Rumah_Sakit"]}</td>");
                    sb.AppendLine($"    <td>{row["Alamat_RS"]}</td>");
                    sb.AppendLine("  </tr>");
                }
                sb.AppendLine("</table>");

                // Signature
                sb.AppendLine("<div class='signature'>");
                sb.AppendLine("  Yogyakarta, " + DateTime.Now.ToString("dd MMMM yyyy") + "<br>");
                sb.AppendLine("  Mengetahui,<br><b>Kepala Unit PMI Kota</b>");
                sb.AppendLine("  <div class='signature-space'></div>");
                sb.AppendLine("  ( ____________________ )");
                sb.AppendLine("</div>");

                sb.AppendLine("<div style='clear: both;'></div>");
                sb.AppendLine("<div class='footer'>Laporan ini digenerate secara otomatis oleh Sistem Manajemen HemoScan.</div>");
                sb.AppendLine("</body></html>");

                wbReport.DocumentText = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan permintaan:\n" + ex.Message, "Error Laporan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            wbReport.ShowPrintDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "HTML Files (*.html)|*.html";
                sfd.FileName = cmbLaporan.SelectedItem.ToString().Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMdd") + ".html";
                sfd.Title = "Ekspor Laporan ke HTML";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, wbReport.DocumentText);
                        MessageBox.Show("Laporan berhasil diekspor ke HTML!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal mengekspor laporan:\n" + ex.Message, "Error Ekspor",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
