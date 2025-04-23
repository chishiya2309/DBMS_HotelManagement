using DAL;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Gọi hàm tạo login và gắn user nếu cần
            EnsureLoginAndUser();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormChinh(3));
        }

        static void EnsureLoginAndUser()
        {
            try
            {
                string connectionString = "Server="+ DBConnection.GetSqlServerName() + ";Database=master;Integrated Security=True;"; // Kết nối bằng Windows Authentication

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string createLogin = @"
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'quanghung')
BEGIN
    CREATE LOGIN [quanghung] WITH PASSWORD = '123456', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;
END";

                    string mapUser = @"
USE [Hotel2025];
IF EXISTS (SELECT * FROM sys.database_principals WHERE name = 'quanghung')
BEGIN
    ALTER USER [quanghung] WITH LOGIN = [quanghung];
END";

                    using (SqlCommand cmd = new SqlCommand(createLogin, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(mapUser, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo login hoặc gắn user: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}