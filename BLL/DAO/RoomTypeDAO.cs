using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;
        public DataTable LoadFullRoomType()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadFullRoomType");
        }
        public bool InsertRoomType(int id, string name, double price, int limitPerson)
        {
            string query = "sp_InsertRoomType @id , @name , @limit , @price";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, limitPerson , price }) > 0;

        }
        internal bool InsertRoomType(RoomType roomTypeNow)
        {
            return InsertRoomType(roomTypeNow.Id ,roomTypeNow.Name, roomTypeNow.Price, roomTypeNow.Limit);
        }
        public bool UpdateRoomType(RoomType roomNow)
        {
            string query = "sp_UpdateRoomType @id , @name , @price , @limitPerson";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { roomNow.Id, roomNow.Name, roomNow.Price, roomNow.Limit }) > 0;
        }
        internal DataTable Search(string text, int id)
        {
            string query = "sp_SearchRoomType @label , @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, id });
        }
 
        public static RoomTypeDAO Instance
        {
            get { if (instance == null) instance = new RoomTypeDAO(); return instance; }
            private set => instance = value;
        }
        public RoomTypeDAO() { }
        public RoomType LoadRoomTypeInfo(int id)
        {
            string query = "sp_RoomTypeInfo @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }
        public List<RoomType> LoadListRoomType()
        {
            string query = "select * from RoomType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<RoomType> listRoomType = new List<RoomType>();
            foreach (DataRow item in data.Rows)
            {
                RoomType roomType = new RoomType(item);
                listRoomType.Add(roomType);
            }
            return listRoomType;
        }
        public RoomType GetRoomTypeByIdRoom(int idRoom)
        {
            string query = "USP_GetRoomTypeByIdRoom @idRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }
        public RoomType GetRoomTypeByIdBookRoom(int idBookRoom)
        {
            string query = "USP_GetRoomTypeByIdBookRoom @idBookRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }
    }
}
