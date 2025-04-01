using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Service
    {
        int idService;
        string nameService;
        int idServiceType;
        double price;
        string status;

        public Service() { }
        public Service(DataRow data)
        {
            Id = (int)data["id"];
            Name = data["Name"].ToString();
            IdServiceType = (int)data["idServiceType"];
            Price = (double)data["Price"];
            Status = data["status"].ToString();
        }
        
        public int Id { get => idService; set => idService = value; }
        public string Name { get => nameService; set => nameService = value; }
        public int IdServiceType { get => idServiceType; set => idServiceType = value; }
        public double Price { get => price; set => price = value; }
        public string Status { get => status; set => status = value; }
    }
}
