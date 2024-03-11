using Energy_Counter.Models;
using My.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy_Counter.ViewModels
{
    public class CounterViewViewModel : NotifyPropertyChangedBase
    {
        public CounterViewViewModel(CounterView counterView)
        {
            CounterView = counterView;
        }
        public CounterViewViewModel(DateTime date, double amount)
        {
            CounterView = new(amount, date);
        }
        public CounterViewViewModel() { }
        public CounterView CounterView { get; set; }
        public double Amount
        {
            get => CounterView.Amount;
            set { CounterView.Amount = value; OnPropertyChanged(nameof(Amount)); }
        }
        public DateTime Date
        {
            get => CounterView.Date;
            set { CounterView.Date = value; OnPropertyChanged(nameof(Date)); }
        }
    }
}
