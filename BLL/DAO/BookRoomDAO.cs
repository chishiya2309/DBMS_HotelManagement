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

        public static BookRoomDAO Instance
        {
            get { if (instance == null) instance = new BookRoomDAO(); return instance; }
            private set => instance = value;
        }
    }
}
