using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Energy_Counter.Models
{
    public class Resource
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Unit { get; set; } = "";
        public Resource(int id, string name, string unit)
        {
            ID = id;
            Name = name;
            Unit = unit;
        }
        public Resource() { }
    }
}
