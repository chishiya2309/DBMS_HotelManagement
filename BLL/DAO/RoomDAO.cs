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

        public DataTable LoadFullRoom()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadFullRoom");
        }
        internal bool InsertRoom(Room roomNow)
        {
            return InsertRoom(roomNow.Name, roomNow.IdRoomType, roomNow.IdStatusRoom);
        }
        public bool InsertRoom(string roomName, int idRoomType, int idStatusRoom)
        {
            string query = "sp_InsertRoom @nameRoom , @idType , @idStatus";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { roomName, idRoomType, idStatusRoom }) > 0;
        }
        public bool UpdateRoom(Room roomNow)
        {
            string query = "sp_UpdateRoom  @id , @name , @idType , @idStatus";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { roomNow.Id, roomNow.Name, roomNow.IdRoomType, roomNow.IdStatusRoom }) > 0;
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


        public DataTable LoadAllEmptyRoom(int id)
        {
            string query = "sp_LoadAvailableRoom @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] {  id });
        }

        public bool DeleteRoom(int id)
        {
            string query = "sp_DeteleRoom @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id }) > 0;
        }

        public List<Room> LoadEmptyRoom(int idRoomType)
        {
            List<Room> rooms = new List<Room>();
            string query = "USP_LoadEmptyRoom @idRoomType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoomType });
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                rooms.Add(room);
            }
            return rooms;
        }
        public List<Room> LoadListFullRoom()
        {
            string query = "USP_LoadListFullRoom @getToday";
            List<Room> rooms = new List<Room>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date });
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                rooms.Add(room);
            }
            return rooms;
        }
        public int GetPeoples(int idBill)
        {
            string query = "USP_GetPeoples @idBill";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { idBill }) + 1;
        }
        public int GetIdRoomFromReceiveRoom(int idReceiveRoom)
        {
            string query = "USP_GetIDRoomFromReceiveRoom @idReceiveRoom";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { idReceiveRoom });
        }
        public bool UpdateStatusRoom(int idRoom)
        {
            string query = "USP_UpdateStatusRoom @idRoom";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idRoom }) > 0;
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
