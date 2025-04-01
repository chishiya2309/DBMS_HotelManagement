using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class ServiceTypeDAO
    {
        private static ServiceTypeDAO instance;

        internal bool InsertServiceType(string name)
        {
            string query = "sp_InsertServiceType @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { name }) > 0;
        }
        internal bool InsertServiceType(ServiceType serviceTypeNow)
        {
            return InsertServiceType(serviceTypeNow.Name);
        }
        internal bool UpdateServiceType(int id, string name)
        {
            string query = "sp_UpdateServiceType @id , @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name }) > 0;
        }
        internal bool UpdateServiceType(ServiceType serviceTypeNow)
        {
            return UpdateServiceType(serviceTypeNow.Id, serviceTypeNow.Name);
        }
        public DataTable LoadFullServiceType()
        {
            string query = "sp_LoadFullServiceType";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        internal DataTable Search(string name, int id)
        {
            string query = "sp_SearchServiceType @string , @int";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name, id });
        }

        public static ServiceTypeDAO Instance
        {
            get { if (instance == null) instance = new ServiceTypeDAO(); return instance; }
            private set => instance = value;
        }

        public List<ServiceType> GetServiceTypes()
        {
            string query = "select * from ServiceType";
            List<ServiceType> serviceTypes = new List<ServiceType>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ServiceType serviceType = new ServiceType(item);
                serviceTypes.Add(serviceType);
            }
            return serviceTypes;
        }
    }
}