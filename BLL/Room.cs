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
        private string idRoomType;
        private int beds;
        private int area;
        private string status;
        private string typebed;

        public Room() { }
        public Room(int id, string name, string idRoomType, int beds, int area, string status, string typebed)
        {
            this.idRoom = id;
            this.roomname = name;
            this.idRoomType = idRoomType;
            this.beds = beds;
            this.area = area;
            this.status = status;
            this.typebed = typebed;
        }

        public int Id { get => idRoom; set => idRoom = value; }
        public string Name { get => roomname; set => roomname = value; }
        public string IdRoomType { get => idRoomType; set => idRoomType = value; }
        public int Beds { get => beds; set => beds = value; }

        public string TypeBed { get => typebed; set => typebed = value; }
        public string Status { get => status; set => status = value; }


        public int Area { get => area; set => area = value; }
    }
}
