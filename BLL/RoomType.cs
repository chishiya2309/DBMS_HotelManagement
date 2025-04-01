using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomType
    {
        private int idRoomType;
        private string name;
        private double price;
        private int limit;
        public RoomType() { }
        public RoomType(int id, string name, double price, int limitPerson)
        {
            this.idRoomType = id;
            this.name = name;
            this.price = price;
            this.limit = limitPerson;
        }
        public RoomType(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Price = (double)row["price"];
            this.Limit = (int)row["limit"];
        }


        public int Id { get => idRoomType; set => idRoomType = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Limit { get => limit; set => limit = value; }
    }
}
