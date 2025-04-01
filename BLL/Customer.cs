using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Customer
    {
        private int idCustomer;
        private string CCCD;
        private string fullname;
        private int idCustomerType;
        private DateTime dateOfBirth;
        private string address;
        private string phoneNumber;
        private string sex;
        private string email;
        public Customer()
        {

        }
        public Customer(int id, string idCard, string name, int idcustomerType, string address, string phoneNumber, string sex, string email, DateTime dateOfBirth)
        {
            this.Id = id;
            this.IdCard = idCard;
            this.Name = name;
            this.IdCustomerType = idcustomerType;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Sex = sex;
            this.Email = email;
        }
        public Customer(DataRow row)
        {
            this.Id = (int)row["idCustomer"];
            this.IdCard = row["CCCD"].ToString();
            this.Name = row["fullname"].ToString();
            this.IdCustomerType = (int)row["idCustomerType"];
            this.DateOfBirth = (DateTime)row["dateofbirth"];
            this.Address = row["address"].ToString();
            this.PhoneNumber = row["phoneNumber"].ToString();
            this.Sex = row["sex"].ToString();
            this.Email = row["email"].ToString();
        }




        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string IdCard { get => CCCD; set => CCCD = value; }
        public string Name { get => fullname; set => fullname = value; }
        public int IdCustomerType { get => idCustomerType; set => idCustomerType = value; }
        public int Id { get => idCustomer; set => idCustomer = value; }
    }
}
