using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public double GetTotalBill(int maHoaDon, double phuthu, double giamgia)
        {
            double totalBill = 0;

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT dbo.fn_TotalBill(@MaHoaDon, @PhuThu, @GiamGia)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    command.Parameters.AddWithValue("@PhuThu", phuthu);
                    command.Parameters.AddWithValue("@GiamGia", giamgia);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            totalBill = Convert.ToDouble(result);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Lỗi khi tính tổng hóa đơn: {ex.Message}");
                    }
                }
            }

            totalBill = (double)Math.Ceiling(totalBill / 1000) * 1000; // làm tròn phần nghìn

            if (totalBill > 0) return totalBill;
            else return 0;
        }

        public DataTable LoadBill()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadBill");
        }

        public DataTable FindBillbyBookRoom(int id)
        {
            string query = "sp_FindBillbyBookRoom @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        public DataTable FindRoomByBill(int id)
        {
            string query = "sp_FindRoomByBill @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        public bool UpdateStatusBill(int id, string status)
        {
            string query = "sp_UpdateStatusBill @id , @status";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, status }) > 0;
        }

        //public bool InsertBill(Bill b)
        //{
        //    string query = "sp_InsertBill @PhuThu , @NoiDungPhuThu , @GiamGia , @ThanhTien , @TinhTrangThanhToan , @MaHoSoDatPhong , @MaNhanVien";
        //    return DataProvider.Instance.ExecuteNonQuery(query, new object[] { b.Surchange, b.SurchangeInfo, b.Discount, b.TotalPrice, b.Status, b.IdBookRoom, b.StaffSetUp }) > 0;
        //}

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

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }
    }
}
