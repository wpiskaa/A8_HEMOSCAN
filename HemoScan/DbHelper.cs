using System.Data.SqlClient;

namespace HemoScan
{
    /// <summary>
    /// Kelas pembantu (Helper) untuk manajemen koneksi database secara terpusat.
    /// Dengan class ini, connection string hanya perlu diubah di SATU TEMPAT saja
    /// jika terjadi perubahan nama server, database, atau kredensial.
    /// </summary>
    public static class DbHelper
    {
        // Connection String terpusat — cukup ubah di sini jika server berubah
        public const string ConnString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HEMOSCAN;Integrated Security=True";

        /// <summary>
        /// Membuat objek SqlConnection baru siap pakai.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnString);
        }
    }
}
