using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy_Counter.Models
{
    public class Building
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Building(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public Building() { }
    }
}
