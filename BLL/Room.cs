using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Room
    {
        private int idRoom;
        private string roomname;
        private int idRoomType;
        private int idStatusRoom;
        public Room() { }
        public Room(int id, string name, int idRoomType, int idStatusRoom)
        {
            this.idRoom = id;
            this.roomname = name;
            this.idRoomType = idRoomType;
            this.idStatusRoom = idStatusRoom;
        }
        public Room(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.Name = row["Name"].ToString();
            this.IdRoomType = (int)row["idRoomType"];
            this.IdStatusRoom = (int)row["idStatusRoom"];
        }

        public int Id { get => idRoom; set => idRoom = value; }
        public string Name { get => roomname; set => roomname = value; }
        public int IdRoomType { get => idRoomType; set => idRoomType = value; }
        public int IdStatusRoom { get => idStatusRoom; set => idStatusRoom = value; }
    }
}
