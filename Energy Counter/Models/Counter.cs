using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy_Counter.Models
{
    public class Counter
    {
        public int ID { get; set; }
        public Tariff Tariff { get; set; }
        public List<CounterView> Counts { get; set; }
        public Counter(int id, Tariff tariff)
        {
            ID = id;
            Tariff = tariff;
            Counts = new();
        }
        public Counter() { }
        public void AddCount(CounterView view)
        {
            Counts.Add(view);
        }
    }
}
