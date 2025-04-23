using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public DataTable GetTotalBill(int maDatPhong, double phuthu, double giamgia)
        {
            

            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM dbo.fn_TotalBill(@MaDatPhong, @PhuThu, @GiamGia)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    command.Parameters.AddWithValue("@PhuThu", phuthu);
                    command.Parameters.AddWithValue("@GiamGia", giamgia);

                    try
                    {
                        connection.Open();

                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                        
                       
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Lỗi khi tính tổng hóa đơn: {ex.Message}");
                    }
                }
            }

            return dt;
            
        }

        public DataTable FindBill(string info)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM dbo.fn_SearchBillByInfo(@string)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@string", info);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi tìm kiếm hoá đơn: {ex.Message}");
                }

            }

            return dt;
        }

        public bool UpdateStatusBill(int id, string status)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {

                string query = "sp_UpdateStatusBill";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Status", status);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật hoá đơn thành công");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật hoá đơn thất bại");
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi đặt dịch vụ: " + ex.Message);
                }
            }
            return false;
        }

        public void SendBillToEmail(string emailCustomer, string emailSubject, string emailBody, string emailFormat)
        {
            string connectionString1 = DBConnection.ConnectionString;
            DBConnection.ConnectionString += "Integrated Security=True";
           
            using (SqlConnection conn = DBConnection.GetConnection())
            {

                string query = "usp_SendConfirmEmail";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecipientEmail", emailCustomer);
                cmd.Parameters.AddWithValue("@EmailSubject", emailSubject);
                cmd.Parameters.AddWithValue("@EmailBody", emailBody);
                cmd.Parameters.AddWithValue("@BodyFormat", emailFormat);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Đã gửi email xác nhận hoàn tất thanh toán đến khách hàng");
                    }
                    else
                    {
                        MessageBox.Show("Gửi email xác nhận hoàn tất thanh toán thất bại");
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi gửi hoá đơn: " + ex.Message);
                }
            }
            DBConnection.ConnectionString = connectionString1;
        }

        public void InsertBill(double phuThu, string noiDungPhuThu, double giamGia, double thanhTien, string tinhTrangThanhToan, string phuongThucThanhToan, int maHoSoDatPhong, int maNhanVien )
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "sp_InsertBill";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PhuThu", phuThu);
                command.Parameters.AddWithValue("@NoiDungPhuThu", noiDungPhuThu );
                command.Parameters.AddWithValue("@GiamGia", giamGia);
                command.Parameters.AddWithValue("@ThanhTien", thanhTien);
                command.Parameters.AddWithValue("@TinhTrangThanhToan", tinhTrangThanhToan);
                command.Parameters.AddWithValue("@PhuongThucThanhToan", phuongThucThanhToan);
                command.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn thất bại, vui lòng kiểm tra lại dữ liệu.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi thêm hóa đơn: {ex.Message}");
                }
            }
        }

        public DataTable PrintBill(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM dbo.fn_PrintBill(@id)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi cố in hoá đơn: {ex.Message}");
                }

            }

            return dt;
        }

        public string SearchEmailByIdBookRoom(SqlConnection conn, int maHoSoDatPhong)
        {
            string email = null;

            using (SqlCommand cmd = new SqlCommand(
                "SELECT email FROM KhachHang a INNER JOIN HoSoDatPhong b ON b.MaKhachHang = a.MaKhachHang WHERE b.MaHoSoDatPhong = @MaHoSoDatPhong", conn))
            {
                cmd.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);

                // Đảm bảo kết nối đã mở
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        email = reader["email"].ToString();
                    }
                }
            }

            return email;
        }
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }
    }
}
