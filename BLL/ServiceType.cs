﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiceType
    {
        private int id;
        private string name;
        public ServiceType() { }
        public ServiceType(DataRow dataRow)
        {
            Id = (int)dataRow["id"];
            Name = dataRow["name"].ToString();
        }
        
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
