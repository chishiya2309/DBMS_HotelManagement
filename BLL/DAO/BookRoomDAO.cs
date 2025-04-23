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
                connection.Open();
                string query = "sp_SearchBookRoom";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
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
            DataTable dt = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                string query = "sp_FindRoomTypeByBookRoom";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi tìm kiếm loại phòng: {ex.Message}");
                }
            }
            return dt;
        }

        public DataTable GetBookRoomList()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                string query = "sp_GetBookRoomList";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi lấy danh sách hồ sơ đặt phòng: {ex.Message}");
                }
            }
            return dt;
        }

        public DataTable FindBookRoomByStatus(string status)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                string query = "sp_FindBookRoomByStatus";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@string", status);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi lấy danh sách hồ sơ đặt phòng: {ex.Message}");
                }
            }
            return dt;
        }

        public DataTable GetParticipantsByBookingId(int maHoSoDatPhong)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                string query = "sp_GetParticipantsByBookingId";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi lấy danh sách người tham gia: {ex.Message}");
                }
            }
            return dt;
        }

        public bool CheckInBooking(int maHoSoDatPhong, DateTime thoiGianCheckinThucTe)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                string query = "sp_CheckInBooking";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                command.Parameters.AddWithValue("@ThoiGianCheckinThucTe", thoiGianCheckinThucTe);
                try
                {
                    return command.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi check-in: {ex.Message}");
                    return false;
                }
            }
        }

        public int InsertBooking(SqlConnection conn, SqlTransaction transaction, int maPhong, int maKhachHangDaiDien, string soTheTinDung, string ghiChu, int soDem, decimal tienDatCoc, string trangThaiDatPhong, DateTime thoiGianCheckinDuKien, DateTime thoiGianCheckoutDuKien)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ThemHoSoDatPhong", conn, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHangDaiDien);
                cmd.Parameters.AddWithValue("@SoTheTinDung", soTheTinDung);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                cmd.Parameters.AddWithValue("@SoDem", soDem);
                cmd.Parameters.AddWithValue("@TienDatCoc", tienDatCoc);
                cmd.Parameters.AddWithValue("@TrangThaiDatPhong", trangThaiDatPhong);
                cmd.Parameters.AddWithValue("@ThoiGianCheckinDuKien", thoiGianCheckinDuKien);
                cmd.Parameters.AddWithValue("@ThoiGianCheckoutDuKien", thoiGianCheckoutDuKien);
                cmd.ExecuteNonQuery();
            }
            using (SqlCommand cmdGetId = new SqlCommand("SELECT IDENT_CURRENT('HoSoDatPhong')", conn, transaction))
            {
                object queryResult = cmdGetId.ExecuteScalar();
                int maHoSoDatPhong = Convert.ToInt32(queryResult);
                if (maHoSoDatPhong == 0)
                    throw new Exception("Không thể lấy mã hồ sơ đặt phòng!");
                return maHoSoDatPhong;
            }
        }

        public void UpdateBooking(SqlConnection conn, SqlTransaction transaction, int maHoSoDatPhong, int maPhong, int maKhachHangDaiDien, string soTheTinDung, string ghiChu, int soDem, decimal tienDatCoc, string trangThaiDatPhong, DateTime thoiGianCheckinDuKien, DateTime thoiGianCheckoutDuKien, DateTime? thoiGianCheckinThucTe, DateTime? thoiGianCheckoutThucTe)
        {
            using (SqlCommand cmd = new SqlCommand("sp_SuaHoSoDatPhong", conn, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHangDaiDien);
                cmd.Parameters.AddWithValue("@SoTheTinDung", soTheTinDung);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                cmd.Parameters.AddWithValue("@SoDem", soDem);
                cmd.Parameters.AddWithValue("@TienDatCoc", tienDatCoc);
                cmd.Parameters.AddWithValue("@TrangThaiDatPhong", trangThaiDatPhong);
                cmd.Parameters.AddWithValue("@ThoiGianCheckinDuKien", thoiGianCheckinDuKien);
                cmd.Parameters.AddWithValue("@ThoiGianCheckoutDuKien", thoiGianCheckoutDuKien);

                // Tham số tùy chọn - có thể là null
                cmd.Parameters.AddWithValue("@ThoiGianCheckinThucTe", thoiGianCheckinThucTe.HasValue ? (object)thoiGianCheckinThucTe.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@ThoiGianCheckoutThucTe", thoiGianCheckoutThucTe.HasValue ? (object)thoiGianCheckoutThucTe.Value : DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertParticipants(SqlConnection conn, SqlTransaction transaction, int maHoSoDatPhong, List<int> danhSachThanhVien)
        {
            foreach (int maKH in danhSachThanhVien)
            {
                using (SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO ThamGia (MaKhachHang, MaHoSoDatPhong) VALUES (@MaKhachHang, @MaHoSoDatPhong)",
                    conn, transaction))
                {
                    cmdInsert.Parameters.AddWithValue("@MaKhachHang", maKH);
                    cmdInsert.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                    cmdInsert.ExecuteNonQuery();
                }
            }
        }

        public void DeleteParticipantsByBookingId(SqlConnection conn, SqlTransaction transaction, int maHoSoDatPhong)
        {
            using (SqlCommand cmdDelete = new SqlCommand(
                "DELETE FROM ThamGia WHERE MaHoSoDatPhong = @MaHoSoDatPhong", conn, transaction))
            {
                cmdDelete.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                cmdDelete.ExecuteNonQuery();
            }
        }

        public static BookRoomDAO Instance
        {
            get { if (instance == null) instance = new BookRoomDAO(); return instance; }
            private set => instance = value;
        }
    }
}
