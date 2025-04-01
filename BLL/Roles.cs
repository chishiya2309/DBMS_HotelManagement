using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class Roles
    {
        private int idRole;
        private string name;
        public Roles(DataRow dataRow)
        {
            IdRole = (int)dataRow["idRole"];
            Name = dataRow["name"].ToString();
        }

        public int IdRole { get => idRole; set => idRole = value; }
        public string Name { get => name; set => name = value; }
    }
}
