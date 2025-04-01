using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class CustomerTypeDAO
    {
        public CustomerTypeDAO() { }

        private static CustomerTypeDAO instance;

        public List<CustomerType> LoadListCustomerType()
        {
            string query = "select * from CustomerType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<CustomerType> listCustomerType = new List<CustomerType>();
            foreach (DataRow item in data.Rows)
            {
                CustomerType CustomerType = new CustomerType(item);
                listCustomerType.Add(CustomerType);
            }
            return listCustomerType;
        }
        public string GetNameById(string idCard)
        {
            string query = "sp_GetCustomerTypeNameById @idCustomer";
            DataRow dataRow = DataProvider.Instance.ExecuteQuery(query, new object[] { idCard }).Rows[0];
            return dataRow["typeName"].ToString();
        }
        internal bool UpdateCustomerType(CustomerType customerTypeNow)
        {
            string query = "sp_UpdateCustomerType @id , @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { customerTypeNow.Id, customerTypeNow.Name }) > 0;
        }

        public DataTable LoadFullCustomerType()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadFullCustomerType");
        }

        public static CustomerTypeDAO Instance
        {
            get { if (instance == null) instance = new CustomerTypeDAO(); return instance; }
            private set => instance = value;
        }
    }
}
