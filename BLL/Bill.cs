using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bill
    {
        public Bill() { }

        private int idBill;
        private int idBookRoom;
        private int staffSetUp;
        private DateTime dateOfCreate;
        private double surchange;
        private string surchangeInfo;
        private double totalPrice;
        private int discount;
        private string status;
        public Bill(DataRow data)
        {
            Id = (int)data["idBill"];
            IdBookRoom = (int)data["idBookRoom"];
            StaffSetUp = (int)data["StaffSetUp"];
            DateOfCreate = (DateTime)data["dateOfCreate"];
            Surchange = (double)data["surchange"];
            SurchangeInfo = data["surchangeInfo"].ToString();
            TotalPrice = (double)data["totalPrice"];
            Discount = (int)data["discount"];
            Status = data["status"].ToString();
        }

        public int Id { get => idBill; set => idBill = value; }
        public int IdBookRoom { get => idBookRoom; set => idBookRoom = value; }
        public int StaffSetUp { get => staffSetUp; set => staffSetUp = value; }
        public DateTime DateOfCreate { get => dateOfCreate; set => dateOfCreate = value; }
        public double Surchange { get => surchange; set => surchange = value; }
        public string SurchangeInfo { get => surchangeInfo; set => surchangeInfo = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int Discount { get => discount; set => discount = value; }
        public string Status { get => status; set => status = value; }
    }
}
