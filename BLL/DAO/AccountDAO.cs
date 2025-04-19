using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class AccountDAO
    {
        private AccountDAO() { }

        private static AccountDAO instance;

        public bool Login(string userName, string passWord)
        {
            string query = "sp_Login @userName , @passWord";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return data.Rows.Count > 0;
        }

        //public bool UpdatePassword(string username, string password)
        //{
        //    string query = "sp_UpdatePassword @username , @password";
        //    return DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, password }) > 0;
        //}

        public void UpdatePassword(string username, string password)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "sp_UpdatePassword";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenDangNhap", username);
                cmd.Parameters.AddWithValue("@MatKhau", password);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật mật khẩu thất bại");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật thông tin: " + ex.Message);
                }
            }
        }


        public bool UpdateUsername(string username, int id)
        {
            string query = "sp_UpdateUsername @username , @idStaff";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, id }) > 0;
        }

        public void InsertAccount(int id, string user, string pass)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "EXEC sp_TaoTaiKhoan @username, @password, @employee_id";

                SqlCommand cmd = new SqlCommand(query, conn);

                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", user);
                cmd.Parameters.AddWithValue("@password", pass);
                cmd.Parameters.AddWithValue("@employee_id", id);
                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm nhân viên thành công, Mật khẩu mặc định là 123456", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại. Hãy kiểm tra lại thông tin ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public DataTable GetAccountById(int id)
        {
            string query = "sp_GetAccountById @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }


        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }
    }
}
