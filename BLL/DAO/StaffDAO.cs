using DAL;
using iTextSharp.text;
using QLKS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DAO
{
    public class StaffDAO
    {
        public StaffDAO() { }

        private static StaffDAO instance;

        public Staff LoadStaffInforById(int id)
        {
            
            string query = "select * from Staff where idStaff=" + id.ToString() + "";
            DataTable dataTable = DBConnection.Instance.ExecuteQuery(query);

            Staff s = new Staff(dataTable.Rows[0]);
            return s;
        }

        public void InsertStaff(string Hoten, string gioitinh, DateTime ngaysinh, string CCCD, string diachi, string email, string sdt,
                 DateTime ngayvaolam, string vaitro, byte[] chandung)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "sp_InsertStaff";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Hoten", Hoten);
                cmd.Parameters.AddWithValue("@Gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Sodienthoai", sdt);
                cmd.Parameters.AddWithValue("@Ngayvaolam", ngayvaolam);


                cmd.Parameters.AddWithValue("@Vaitro", vaitro);
                cmd.Parameters.AddWithValue("@Chandung", chandung);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //Thêm nhân viên thành công. Tiến hành thêm tài khoản tương ứng

                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại. Hãy kiểm tra lại thông tin ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public DataTable LoadFullStaff()
        {
            string query = "sp_LoadFullStaff";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable SearchProfileStaffByID(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM dbo.fn_SearchProfileStaffByID(@id)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi truy xuất thông tin nhân viên này: {ex.Message}");
                }

            }

            return dt;
        }

        public DataTable SearchStaffByCCCD(string cccd)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM dbo.fn_SearchStaffByCCCD(@CCCD)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@CCCD", cccd);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi truy xuất thông tin nhân viên này: {ex.Message}");
                }

            }

            return dt;
        }

        public void UpdateStaff(int id, string Hoten, string gioitinh, DateTime ngaysinh, string CCCD, string diachi, string email, string sdt,
            DateTime ngayvaolam, string vaitro, byte[] chandung)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "sp_UpdateStaff";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNhanVien", id);
                cmd.Parameters.AddWithValue("@Hoten", Hoten);
                cmd.Parameters.AddWithValue("@Gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Sodienthoai", sdt);
                cmd.Parameters.AddWithValue("@Ngayvaolam", ngayvaolam);


                cmd.Parameters.AddWithValue("@Vaitro", vaitro);
                cmd.Parameters.AddWithValue("@Chandung", chandung);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin cơ bản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin thất bại");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật thông tin: " + ex.Message);
                }
            }
        }

        public bool DeleteStaff(int idStaff)
        {
            string query = "sp_DeteleStaff @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStaff }) > 0;
        }

        public DataTable Search(string FullName)
        {
            string query = "SELECT * FROM dbo.fn_SearchStaff(@FullName)";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { FullName});
        }

        public DataTable SearchStaffByName(string Hoten)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM dbo.fn_SearchStaffByName(@Hoten)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Hoten", Hoten);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi truy xuất thông tin nhân viên này: {ex.Message}");
                }
            }
            return dt;
        }

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return instance; }
            private set => instance = value;
        }
    }
}
