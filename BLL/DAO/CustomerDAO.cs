using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class CustomerDAO
    {
        public CustomerDAO() { }

        private static CustomerDAO instance;

        public bool InsertCustomer(Customer customer)
        {
            string query = "exec sp_InsertCustomer @CCCD , @fullName , @idCustomerType , @dateofBirth , @address , @Phonenumber , @sex , @email";
            object[] parameter = new object[] { customer.IdCard, customer.Name, customer.IdCustomerType, customer.DateOfBirth, customer.Address,
                                                customer.PhoneNumber, customer.Sex, customer.Email};
            return DataProvider.Instance.ExecuteNonQuery(query, parameter) > 0;
        }

        public bool UpdateCustomer(Customer customer)
        {
            string query = "exec sp_UpdateCustomerInfo @idCustomer , @CCCD , @fullName , @idCustomerType , @dateofBirth , @address , @Phonenumber , @sex , @email";
            object[] parameter = new object[] {customer.Id, customer.IdCard, customer.Name, customer.IdCustomerType, customer.DateOfBirth, customer.Address,
                                                customer.PhoneNumber, customer.Sex, customer.Email};
            return DataProvider.Instance.ExecuteNonQuery(query, parameter) > 0;
        }

        public DataTable LoadFullCustomer()
        {
            string query = "sp_LoadFullCustomer";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool DeleteCustomer(int idCustomer)
        {
            string query = "sp_DeteleCustomer @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idCustomer }) > 0;
        }

        public DataTable Search(string lb, int mode)
        {
            string query = "sp_SearchCustomer @string , @mode";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { lb, mode });
        }

        public int GetIDCustomerFromBookRoom(int idBookRoom)
        {
            string query = "sp_GetIdCustomerFromBookRoom @idBookRoom";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { idBookRoom });
        }



        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set => instance = value;
        }
    }
}
