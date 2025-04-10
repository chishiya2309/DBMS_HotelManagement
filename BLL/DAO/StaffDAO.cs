using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class StaffDAO
    {
        public StaffDAO() { }

        private static StaffDAO instance;

        public Staff LoadStaffInforById(int id)
        {
            
            string query = "select * from Staff where idStaff=" + id.ToString() + "";
            DataTable dataTable = DBConnection.Instance.ExecuteQuery(query);

            Staff s = new Staff(dataTable.Rows[0]);
            return s;
        }

        public bool InsertStaff(Staff staff)
        {
            string query = "EXEC sp_InsertStaff @fullName , @sex , @dateofBirth , @CCCD , @address , @email , @Phonenumber , @idRole , @Startday";
            object[] parameter = new object[] {staff.Fullname, staff.Sex, staff.DoB, staff.IdNumber, 
                staff.Address, staff.Email, staff.Phone, staff.IdRole, staff.StartDay};
            return DataProvider.Instance.ExecuteNonQuery(query, parameter) > 0;
        }

        public bool UpdateStaff(Staff staff)
        {
            string query = "EXEC sp_UpdateStaffInfo @idStaff , @fullName , @sex , @dateofBirth , @CCCD , @address , @email , @Phonenumber , @idRole , @Startday";
            object[] parameter = new object[] {staff.IdStaff ,staff.Fullname, staff.Sex, staff.DoB, staff.IdNumber,
                staff.Address, staff.Email, staff.Phone, staff.IdRole, staff.StartDay};
            return DataProvider.Instance.ExecuteNonQuery(query, parameter) > 0;
        }

        public bool UpdateInfo(int idStaff, string fullName, string sex, DateTime dateofBirth,  string CCCD,string address, string email, string phonenumber)
        {
            string query = "EXEC sp_UpdateInfo @idStaff , @fullName , @sex , @dateofBirth , @CCCD , @address , @email , @Phonenumber";
            object[] parameter = new object[] {idStaff , fullName, sex, dateofBirth, address, CCCD, email, phonenumber};
            return DataProvider.Instance.ExecuteNonQuery(query, parameter) > 0;
        }

        public DataTable LoadFullStaff()
        {
            string query = "sp_LoadFullStaff";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool DeleteStaff(int idStaff)
        {
            string query = "sp_DeteleStaff @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStaff }) > 0;
        }

        public DataTable Search(string FullName)
        {
            string query = "sp_SearchStaff @FullName";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { FullName});
        }

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return instance; }
            private set => instance = value;
        }
    }
}
