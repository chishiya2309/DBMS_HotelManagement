using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Staff
    {
        private int idStaff;
        private string fullName;
        private string sex;
        private DateTime dateofBirth;
        private string address;
        private string CCCD;
        private string email;
        private int idRole;
        private string Phonenumber;
        private DateTime startDay;
        private byte[] img; // filePath

        public Staff() { }

        public Staff(int idStaff, string fullName, string sex, DateTime dateofBirth, string address, string CCCD, string email, int idRole, string phonenumber, DateTime startDay, byte[] img)
        {
            this.idStaff = idStaff;
            this.fullName = fullName;
            this.sex = sex;
            this.dateofBirth = dateofBirth;
            this.address = address;
            this.CCCD = CCCD;
            this.email = email;
            this.idRole = idRole;
            this.Phonenumber = phonenumber;
            this.startDay = startDay;
            this.img = img;
            //this.img = img;
        }

        public Staff(DataRow row)
        {
            IdStaff = (int)row["idStaff"];
            Fullname = row["fullName"].ToString();
            Sex = (string)row["sex"];
            DoB = (DateTime)row["dateofBirth"];
            Address = row["address"].ToString();
            IdNumber = row["CCCD"].ToString();
            Email = row["email"].ToString();
            IdRole = (int)row["idRole"];
            Phone = row["Phonenumber"].ToString();
            StartDay = (DateTime)row["startDay"];
            

        }




        public int IdStaff { get => idStaff; set => idStaff = value; }

        public string Fullname { get => fullName; set => fullName = value; }
        public string Sex { get => sex; set => sex = value; }
        public DateTime DoB { get => dateofBirth; set => dateofBirth = value; }
        public string Address { get => address; set => address = value; }
        public string IdNumber { get => CCCD; set => CCCD = value; }
        public string Email { get => email; set => email = value; }
        public int IdRole { get => idRole; set => idRole = value; }
        public string Phone { get => Phonenumber; set => Phonenumber = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        
    }
}
