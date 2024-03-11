using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy_Counter.Models
{
    public class CounterView
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public CounterView(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
        public CounterView() { }
    }
}
