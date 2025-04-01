using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StatusRoom
    {
        private int id;
        private string name;
        

        
        public StatusRoom() { }
        public StatusRoom(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public StatusRoom(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}
