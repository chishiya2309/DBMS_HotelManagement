using DAL;
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
    public class BookRoomDAO
    {
        private BookRoomDAO() { }

        private static BookRoomDAO instance;

        public DataTable LoadBookRoom()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadBookRoom");
        }

        public bool InsertBookRoom(BookingRecord bk)
        {
            string query = "sp_InsertBookRoom @TienDatCoc, @TrangThaiDatPhong, @ThoiGianCheckinDuKien, @ThoiGianCheckoutDuKien, @SoDem, @MaPhong, @MaKhachHang, @SoTheTinDung, @GhiChu, @ThoiGianDatPhong, @ThoiGianCheckinThucTe, @ThoiGianCheckoutThucTe";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {
                bk.TienDatCoc,
                bk.TrangThaiDatPhong,
                bk.ThoiGianCheckinDuKien,
                bk.ThoiGianCheckoutDuKien,
                bk.SoDem,
                bk.MaPhong,
                bk.MaKhachHang,
                bk.SoTheTinDung,
                (object)bk.GhiChu ?? DBNull.Value,
                bk.ThoiGianDatPhong,
                (object)bk.ThoiGianCheckinThucTe ?? DBNull.Value,
                (object)bk.ThoiGianCheckoutThucTe ?? DBNull.Value
            }) > 0;
        }

        public bool UpdateBookRoom(BookingRecord bk)
        {
            string query = "sp_UpdateBookRoom @MaHoSoDatPhong, @TienDatCoc, @TrangThaiDatPhong, @ThoiGianCheckinDuKien, @ThoiGianCheckoutDuKien, @SoDem, @MaPhong, @MaKhachHang, @SoTheTinDung, @GhiChu, @ThoiGianDatPhong, @ThoiGianCheckinThucTe, @ThoiGianCheckoutThucTe";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {
                bk.MaHoSoDatPhong,
                bk.TienDatCoc,
                bk.TrangThaiDatPhong,
                bk.ThoiGianCheckinDuKien,
                bk.ThoiGianCheckoutDuKien,
                bk.SoDem,
                bk.MaPhong,
                bk.MaKhachHang,
                bk.SoTheTinDung,
                (object)bk.GhiChu ?? DBNull.Value,
                bk.ThoiGianDatPhong,
                (object)bk.ThoiGianCheckinThucTe ?? DBNull.Value,
                (object)bk.ThoiGianCheckoutThucTe ?? DBNull.Value
            }) > 0;
        }

        public void ConfirmBookRoomBonus(int MaHoSoDatPhong, string note)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "sp_ConfirmBookRoomBonus";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHoSoDatPhong", MaHoSoDatPhong);
                cmd.Parameters.AddWithValue("@Note", note);
                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Ghi nhận thành công");
                    }
                    else
                    {
                        MessageBox.Show("Ghi nhận thất bại");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi ghi nhận hồ sơ đặt phòng: " + ex.Message);
                }
            }
        }

        public DataTable Search(int maHoSoDatPhong)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "sp_SearchBookRoom";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi tìm kiếm hồ sơ đặt phòng: {ex.Message}");
                }
            }
            return dt;
        }

        public DataTable FindRoomTypeByBookRoom(int maHoSoDatPhong)
        {
            string query = "sp_FindRoomTypeByBookRoom @MaHoSoDatPhong";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maHoSoDatPhong });
        }

        public DataTable GetBookRoomList()
        {
            return DataProvider.Instance.ExecuteQuery("sp_GetBookRoomList");
        }

        public static BookRoomDAO Instance
        {
            get { if (instance == null) instance = new BookRoomDAO(); return instance; }
            private set => instance = value;
        }
    }
}
