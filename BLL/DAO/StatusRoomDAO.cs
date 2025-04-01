using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class StatusRoomDAO
    {
        private static StatusRoomDAO instance;
        private StatusRoomDAO() { }
        public static StatusRoomDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusRoomDAO();
                return instance;
            }
            private set => instance = value;
        }

        internal bool UpdateStatusRoom(int id, string name)
        {
            string query = "exec sp_UpdateStatusRoom @id , @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name }) > 0;
        }
        internal bool UpdateStatusRoom(StatusRoom statusRoomNow)
        {
            return UpdateStatusRoom(statusRoomNow.Id, statusRoomNow.Name);
        }
        public DataTable LoadFullStatusRoom()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadFullStatusRoom");
        }
    }
}
