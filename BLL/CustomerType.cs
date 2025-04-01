using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class CustomerType
    {
        private int idCustomerType;
        private string typeName;
        public CustomerType(int id, string name)
        {
            this.idCustomerType = id;
            this.typeName = name;
        }
        public CustomerType(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["Name"].ToString();
        }

        public int Id { get => idCustomerType; set => idCustomerType = value; }
        public string Name { get => typeName; set => typeName = value; }
    }
}
