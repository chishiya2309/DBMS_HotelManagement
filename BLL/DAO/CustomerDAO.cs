using DAL;
using QLKS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DAO
{
    public class CustomerDAO
    {
        public CustomerDAO() { }

        private static CustomerDAO instance;


        public void InsertCustomer(string Hoten, string gioitinh, DateTime ngaysinh, string CCCD, string diachi,
            string sdt, string email, string loaikhachhang, string tinhtrang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "sp_InsertCustomer";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Hoten", Hoten);
                cmd.Parameters.AddWithValue("@Gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Sodienthoai", sdt);
                cmd.Parameters.AddWithValue("@LoaiKhachHang", loaikhachhang);
                cmd.Parameters.AddWithValue("@TinhTrangDatPhong", tinhtrang);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm khách hàng. Hãy kiểm tra lại thông tin");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateCustomer(int id, string Hoten, string gioitinh, DateTime ngaysinh, string CCCD, string diachi, 
            string sdt, string email, string loaikhachhang, string tinhtrang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "sp_UpdateCustomer";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKhachHang", id);
                cmd.Parameters.AddWithValue("@Hoten", Hoten);
                cmd.Parameters.AddWithValue("@Gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Sodienthoai", sdt);
                cmd.Parameters.AddWithValue("@LoaiKhachHang", loaikhachhang);
                cmd.Parameters.AddWithValue("@TinhTrangDatPhong", tinhtrang);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin khách hàng thất bại");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật thông tin: " + ex.Message);
                }
            }
        }

        public bool DeleteCustomer(int maKhachHang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public DataTable Search(string searchString, int searchMode)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * from dbo.fn_SearchCustomer(@string,@mode)";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@string", searchString);
                cmd.Parameters.AddWithValue("@mode", searchMode);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Tìm thấy {dt.Rows.Count} khách hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            return dt;
        }

        public DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM KhachHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dt;
        }

        public DataTable GetCustomerById(string customerId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM KhachHang WHERE MaKhachHang = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", customerId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }

                    if (dt.Rows.Count == 0)
                    {
                        Console.WriteLine($"Không tìm thấy khách hàng với mã {customerId}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi truy vấn khách hàng: " + ex.Message);
                }
            }
            return dt;
        }

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set => instance = value;
        }
    }
}
