using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy_Counter.Models
{
    public class Tariff
    {
        public int ID { get; set; }
        public string Currency { get; set; } = "";
        public Resource Resource { get; set; }
        public Provider Provider { get; set; }
        public double PricePerOne { get; set; }
        public Tariff(int id, Resource resource, double pricePerOne, Provider provider, string currency)
        {
            ID = id;
            Resource = resource;
            PricePerOne = pricePerOne;
            Provider = provider;
            Currency = currency;
        }
        public Tariff() { }
    }
}
