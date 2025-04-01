using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace DAL
{
    public class AccountDAO
    {
        private AccountDAO() { }

        private static AccountDAO instance;

        public bool Login(string userName, string passWord)
        {
            string query = "sp_Login @userName , @passWord";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return data.Rows.Count > 0;
        }

        public bool UpdatePassword(string username, string password)
        {
            string query = "sp_UpdatePassword @username , @password";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, password }) > 0;
        }

        public bool UpdateUsername(string username, int id)
        {
            string query = "sp_UpdateUsername @username , @idStaff";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, id }) > 0;
        }

        public bool InsertAccount(Account account)
        {
            string query = "EXEC sp_InsertAccount @username , @pass";
            object[] parameter = new object[] {account.UserName, account.Pass};
            return DataProvider.Instance.ExecuteNonQuery(query, parameter) > 0;
        }

        public bool InsertAccount(string username, string password)
        {
            string query = "EXEC sp_InsertAccount @username , @pass";
            object[] parameter = new object[] { username, password };
            return DataProvider.Instance.ExecuteNonQuery(query, parameter) > 0;
        }

        public DataTable GetAccountById(int id)
        {
            string query = "sp_GetAccountById @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }


        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }
    }
}
