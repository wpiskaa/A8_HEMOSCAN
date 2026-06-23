using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace HemoScan
{
    /// <summary>
    /// Kelas pembantu (Helper) untuk manajemen koneksi database secara terpusat.
    /// Memungkinkan perubahan Connection String dinamis agar aplikasi bisa dipakai di laptop client.
    /// </summary>
    public static class DbHelper
    {
        private static string _connString = null;
        private const string ConfigFileName = "db_config.txt";

        // Properti Connection String dinamis
        public static string ConnString
        {
            get
            {
                if (_connString == null)
                {
                    string filePath = Path.Combine(Application.StartupPath, ConfigFileName);
                    if (File.Exists(filePath))
                    {
                        try
                        {
                            _connString = File.ReadAllText(filePath).Trim();
                        }
                        catch
                        {
                            // Jika pembacaan gagal, fallback ke default
                        }
                    }

                    // Jika string konfigurasi kosong, gunakan default LocalDB
                    if (string.IsNullOrEmpty(_connString))
                    {
                        _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HEMOSCAN;Integrated Security=True";
                    }
                }
                return _connString;
            }
            set
            {
                _connString = value;
                try
                {
                    string filePath = Path.Combine(Application.StartupPath, ConfigFileName);
                    File.WriteAllText(filePath, _connString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan konfigurasi server database:\n" + ex.Message, 
                        "Error Konfigurasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Membuat objek SqlConnection baru berdasarkan connection string saat ini.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnString);
        }
    }
}
