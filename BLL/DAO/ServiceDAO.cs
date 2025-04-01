using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class ServiceDAO
    {
        private static ServiceDAO instance;
        public List<Service> GetServices(int idServiceType)
        {
            List<Service> services = new List<Service>();
            string query = "sp_LoadServiceByServiceType @idServiceType";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { idServiceType });
            foreach (DataRow item in dataTable.Rows)
            {
                Service service = new Service(item);
                services.Add(service);
            }
            return services;
        }
        public bool InsertService(int id,  string name, int idtype, double price)
        {
            string query = "sp_InsertService @id , @name , @idServiceType , @price";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                id, name, idtype, price
            }) > 0;
        }
        
        public bool UpdateService(int id, string name, int idServiceType, double price, string status)
        {
            string query = "sp_UpdateService @id , @name , @idServiceType , @price , @status";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, idServiceType, price , status}) > 0;
        }

        public bool DeleteService(int idService)
        {
            string query = "sp_DeteleService @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idService }) > 0;
        }

        public DataTable LoadFullService()
        {
            string query = "sp_LoadFullService";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LoadFullAvailableService()
        {
            string query = "sp_LoadFullAvailableService";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable Search(string name)
        {
            string query = "sp_SearchService @string ";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name });
        }



        public static ServiceDAO Instance
        {
            get { if (instance == null) instance = new ServiceDAO(); return instance; }
            private set => instance = value;
        }
    }
}
