using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Account
    {
        private string userName;
        private string passWord;
        private int idStaff;

        public Account() { }

        public Account(string userName, string passWord, int idStaff)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.idStaff = idStaff;
        }

        public Account(DataRow row)
        {
            UserName = row["userName"].ToString();
            Pass = row["passWord"].ToString();
            IdStaff = (int)row["idStaff"];
        }




        public string UserName { get => userName; set => userName = value; }
        public string Pass { get => passWord; set => passWord = value; }
        public int IdStaff { get => idStaff; set => idStaff = value; }
    }
}
