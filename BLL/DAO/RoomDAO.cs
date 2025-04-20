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

        internal bool InsertRoom(Room roomNow)
        {
            return InsertRoom(roomNow.Name, roomNow.IdRoomType, roomNow.IdStatusRoom);
        }
        public bool InsertRoom(string roomName, int idRoomType, int idStatusRoom)
        {
            string query = "sp_InsertRoom @nameRoom , @idType , @idStatus";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { roomName, idRoomType, idStatusRoom }) > 0;
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
                catch (SqlException)
                {
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

        public DataTable GetAllRoomsByType(string maLoaiPhong)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                string query = "sp_GetAllRoomsByType";
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
                    Console.WriteLine($"Lỗi khi lấy tất cả phòng theo loại phòng: {ex.Message}");
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
        #endregion

        public static RoomDAO Instance
        {
            get { if (instance == null) instance = new RoomDAO(); return instance; }
            private set => instance = value;
        }
        private RoomDAO() { }
    }
}
