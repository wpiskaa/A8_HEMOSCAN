using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HemoScan
{
    public partial class FormLogin : Form
    {
        // Koneksi terpusat — didapat dari DbHelper agar tidak hardcode di tiap form
        SqlConnection conn = new SqlConnection(DbHelper.ConnString);

        public FormLogin()
        {
            InitializeComponent();
        }

        // Event saat form pertama kali dibuka
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // BUKTI POIN B: Tes koneksi otomatis dilakukan saat aplikasi pertama kali berjalan
            try
            {
                conn.Open();
                // Koneksi berhasil → langsung tutup, tidak perlu dibiarkan terbuka saat login
                conn.Close();
                MessageBox.Show("Koneksi Database HEMOSCAN Berhasil!",
                    "Status Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Database Gagal!\n\nDetail: " + ex.Message,
                    "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set fokus ke field username agar user langsung bisa mengetik
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validasi input tidak boleh kosong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password tidak boleh kosong!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Query parameterisasi — aman dari SQL Injection
                string query = "SELECT Role FROM Tabel_User WHERE Username=@user AND Password=@pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Username atau password salah!", "Login Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();
                    return;
                }

                // Gunakan ToLower() agar perbandingan tidak case-sensitive
                string role = result.ToString().ToLower();
                this.Hide();

                switch (role)
                {
                    case "adminpmi":
                        FormAdminPMI adminForm = new FormAdminPMI();
                        adminForm.FormClosed += (s, args) => this.Show();
                        adminForm.Show();
                        break;

                    case "stafrs":
                        FormStafRS stafForm = new FormStafRS();
                        stafForm.FormClosed += (s, args) => this.Show();
                        stafForm.Show();
                        break;

                    case "manajer":
                        FormManajer manajerForm = new FormManajer();
                        manajerForm.FormClosed += (s, args) => this.Show();
                        manajerForm.Show();
                        break;

                    default:
                        MessageBox.Show("Role tidak dikenali: " + result.ToString(), "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error koneksi: " + ex.Message, "Error Database",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // Tekan Enter di field password → langsung login
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, new EventArgs());
        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {

        }
    }
}