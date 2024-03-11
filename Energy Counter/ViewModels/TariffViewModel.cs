using Energy_Counter.Models;
using My.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Energy_Counter.ViewModels
{
    public class TariffViewModel : NotifyPropertyChangedBase
    {
        public Tariff Tariff { get; set; }
        public TariffViewModel(Tariff tariff)
        {
            Tariff = tariff;
            ResourceViewModel = new(tariff.Resource);
            ProviderViewModel = new(tariff.Provider);
        }
        public TariffViewModel(int id, Resource resource, Provider provider, double pricePerOne, string currency) 
        {
            Tariff = new(id, resource, pricePerOne, provider,currency);
        }
        public TariffViewModel() { }
        [JsonIgnore]
        [XmlIgnore]
        public int ID
        {
            get => Tariff.ID;
            set
            {
                Tariff.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public ResourceViewModel ResourceViewModel
        {
            get;set;

        }
        public ProviderViewModel ProviderViewModel
        {
            get;set;
        }
        [JsonIgnore]
        [XmlIgnore]
        public double PricePerOne
        {
            get => Tariff.PricePerOne;
            set
            {
                Tariff.PricePerOne = value;
                OnPropertyChanged(nameof(PricePerOne));
                OnPropertyChanged(nameof(FullPrice));
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string FullPrice
        {
            get => $"{PricePerOne} {Currency}/{Tariff.Resource.Unit}";
        }
        [JsonIgnore]
        [XmlIgnore]
        public string Currency
        {
            get=> Tariff.Currency;
            set
            {
                Tariff.Currency = value;
                OnPropertyChanged(nameof(Currency));
                OnPropertyChanged(nameof(FullPrice));
            }
        }
    }
}
