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
    public class RoomDAO
    {
        private static RoomDAO instance;
        #region Method

        public bool InsertRoom(string tenPhong, int soGiuong, string loaiGiuong, int khuVuc, string trangThai, string maLoaiPhong)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmdRoom = new SqlCommand("sp_InsertRoom", connection);
                    cmdRoom.CommandType = CommandType.StoredProcedure;

                    cmdRoom.Parameters.AddWithValue("@name", tenPhong);
                    cmdRoom.Parameters.AddWithValue("@Beds", soGiuong);
                    cmdRoom.Parameters.AddWithValue("@BedType", loaiGiuong);
                    cmdRoom.Parameters.AddWithValue("@Floor", khuVuc);
                    cmdRoom.Parameters.AddWithValue("@Status", trangThai);
                    cmdRoom.Parameters.AddWithValue("@idRoomType", maLoaiPhong);

                    int rows = cmdRoom.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool UpdateRoom(int idRoom, string name, int beds, string bedType, int floor, string status, string idRoomType)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmdRoom = new SqlCommand("sp_UpdateRoom", connection);
                    cmdRoom.CommandType = CommandType.StoredProcedure;
                    cmdRoom.Parameters.AddWithValue("@idRoom", idRoom);
                    cmdRoom.Parameters.AddWithValue("@name", name);
                    cmdRoom.Parameters.AddWithValue("@Beds", beds);
                    cmdRoom.Parameters.AddWithValue("@BedType", bedType);
                    cmdRoom.Parameters.AddWithValue("@Floor", floor);
                    cmdRoom.Parameters.AddWithValue("@Status", status);
                    cmdRoom.Parameters.AddWithValue("@idRoomType", idRoomType);
                    cmdRoom.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi cập nhật phòng: {ex.Message}");
                    return false;
                }
            }
        }
        public DataTable SearchRoom(string Hoten)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM dbo.fn_SearchRoom(@string)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@string", Hoten);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi truy xuất thông tin phòng này: {ex.Message}");
                }
            }
            return dt;
        }

        public bool DeleteRoom(int id)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteRoom", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idRoom", id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi xóa phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public DataTable GetAvailableRoomsByType(string maLoaiPhong)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                string query = "sp_GetAvailableRooms";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi lấy phòng trống theo loại phòng: {ex.Message}");
                }
            }
            return dt;
        }

        public DataTable GetAllRooms()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Phong";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi lấy danh sách phòng: {ex.Message}");
                }
            }
            return dt;
        }

        public DataTable LoadRoomWithType()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LoadRoomWithType", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi lấy danh sách phòng kèm loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dt;
        }

        public DataTable MergeRoomTables(string maLoaiPhong, int maPhongHoSo)
        {
            DataTable dtResult = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh SQL để lấy phòng của hồ sơ và các phòng trống cùng loại
                    string query = @"
                    SELECT p.MaPhong, p.TenPhong, p.MaLoaiPhong, lp.TenLoaiPhong, p.TrangThai
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaLoaiPhong = @MaLoaiPhong AND 
                         (p.TrangThai = N'Trống' OR p.MaPhong = @MaPhong)
                    ORDER BY 
                        CASE WHEN p.MaPhong = @MaPhong THEN 0 ELSE 1 END,
                        p.TenPhong";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);
                    command.Parameters.AddWithValue("@MaPhong", maPhongHoSo);

                    SqlDataReader reader = command.ExecuteReader();
                    dtResult.Load(reader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi kết hợp bảng phòng: {ex.Message}");
                    // Trong trường hợp lỗi, trả về bảng phòng trống
                    dtResult = GetAvailableRoomsByType(maLoaiPhong);
                }
            }
            return dtResult;
        }
        #endregion

        public static RoomDAO Instance
        {
            get { if (instance == null) instance = new RoomDAO(); return instance; }
            private set => instance = value;
        }
        private RoomDAO() { }
    }
}
