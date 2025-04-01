using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class RolesDAO
    {
        public RolesDAO() { }

        private static RolesDAO instance;

        public DataTable LoadAllRole()
        {
            string query = "sp_LoadAllRole";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Roles GetStaffTypeByUserName(string username)
        {
            string query = "sp_GetRoleByUsername @username";
            Roles staffType = new Roles(DataProvider.Instance.ExecuteQuery(query, new object[] { username }).Rows[0]);
            return staffType;
        }

        internal bool Delete(int idRole)
        {
            string query = "sp_DeteleRole @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idRole }) > 0;
        }

        internal bool Update(int idRole, string text)
        {
            string query = "sp_UpdateRole @id , @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idRole, text }) > 0;
        }

        internal bool Insert(int idRole, string text)
        {
            string query = "sp_InsertRole @id , @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idRole, text }) > 0;
        }

        public static RolesDAO Instance
        {
            get { if (instance == null) instance = new RolesDAO(); return instance; }
            private set => instance = value;
        }
    }
}
