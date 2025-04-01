using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookingRecord
    {
        public BookingRecord() { }

        private int idBookRoom;
        private int idCustomer;
        private int idRoom;
        private double deposit;
        private int days;
        private string status;
        private DateTime dateCheckIn;
        private DateTime dateCheckOut;
        private DateTime dateBookRoom;

        public BookingRecord(int idBookRoom, int idCustomer, int idRoom, double deposit, int nights, string status, DateTime dateCheckIn, DateTime dateCheckOut, DateTime dateBookRoom)
        {
            this.idBookRoom = idBookRoom;
            this.idCustomer = idCustomer;
            this.idRoom = idRoom;
            this.deposit = deposit;
            this.Days = nights;
            this.status = status;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.dateBookRoom = dateBookRoom;
        }

        public BookingRecord(DataRow row)
        {
            Id = (int)row["id"];
            IdCustomer = (int)row["idCustomer"];
            IdRoom = (int)row["IdRoomType"];
            Deposit = (double)row["deposit"];
            Days = (int)row["days"];
            Status = row["status"].ToString();
            DateCheckIn = (DateTime)row["DateCheckIn"];
            DateCheckOut = (DateTime)row["DateCheckOut"];
            DateBookRoom = (DateTime)row["DateBookRoom"];
        }

        public int Id { get => idBookRoom; set => idBookRoom = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public int IdRoom { get => idRoom; set => idRoom = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public int Days { get => days; set => days = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public DateTime DateBookRoom { get => dateBookRoom; set => dateBookRoom = value; }
    }
}
