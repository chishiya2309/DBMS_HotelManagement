using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsedServiceDetail
    {
        private int idInfo;
        private int idService;
        private int count;
        private double totalPrice;
        private DateTime usedDate;
        private int idBookRoom;
        public UsedServiceDetail(DataRow data)
        {
            Id = (int)data["idInfo"];
            IdService = (int)data["idService"];
            Count = (int)data["count"];
            TotalPrice = (int)data["totalPrice"];
            UsedDate = (DateTime)data["usedDate"];
            IDBookRoom = (int)data["idBookRoom"];
        }



        public int Id { get => idInfo; set => idInfo = value; }
        public int IdService { get => idService; set => idService = value; }
        public int Count { get => count; set => count = value; }
        public int IDBookRoom { get => idBookRoom; set => idBookRoom = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public DateTime UsedDate { get => usedDate; set => usedDate = value; }
    }
}
