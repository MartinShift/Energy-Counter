using Energy_Counter.Models;
using My.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Energy_Counter.ViewModels
{
    public class CounterViewModel : NotifyPropertyChangedBase
    {
        public Counter Counter { get; set; }
        public CounterViewModel(Counter counter)
        {
            Counter = counter;
        }
        public CounterViewModel() { }
        public CounterViewModel(Tariff tariff, int id)
        {
            Counter = new(id, tariff);
            TariffViewModel = new(tariff);
        }
        public TariffViewModel TariffViewModel
        {
            get; set;
        }
        [JsonIgnore]
        [XmlIgnore]
        public int ID
        {
            get => Counter.ID;
            set { Counter.ID = value; OnPropertyChanged(nameof(ID)); }
        }
        [JsonIgnore]
        [XmlIgnore]
        public ObservableCollection<CounterViewViewModel> Counters
        {
            get => new(Counter.Counts.Select(x => new CounterViewViewModel(x)));
            set
            {
                Counter.Counts = value.Select(x => x.CounterView).ToList();
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public double TotalUsed { get => Counter.Counts.Count == 0 ? 0 : Counter.Counts.Last().Amount - Counter.Counts.First().Amount; }
        [JsonIgnore]
        [XmlIgnore]
        public string TotalPrice
        {
            get
            {
                var price = Counter.Counts.Count == 0 ? 0 : Counter.Counts.Last().Amount * TariffViewModel.PricePerOne;
                return $"{price} {TariffViewModel.Currency}";
            }
        }
    }
}
