using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class UsedServiceInfoDAO
    {
        public UsedServiceInfoDAO() { }

        private static UsedServiceInfoDAO instance;

        public DataTable Search(int idBookRoom)
        {
            string query = "sp_SearchUsedServiceInfo @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom });
        }

        public bool InsertUsedService(int idService, int count, double totalPrice, int idBookRoom)
        {
            string query = "sp_InsertUsedService @idService , @count , @totalPrice , @idBookRoom";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idService, count, totalPrice, idBookRoom }) > 0;
        }

        public bool UpdateUsedService(int idService, int count, double totalPrice, int idBookRoom)
        {
            string query = "sp_UpdateUsedService @idService , @count , @totalPrice , @idBookRoom";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idService, count, totalPrice, idBookRoom }) > 0;
        }

        public static UsedServiceInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsedServiceInfoDAO();
                return instance;
            }
            private set => instance = value;
        }
    }
}
