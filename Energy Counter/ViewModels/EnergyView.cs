using Energy_Counter.Models;
using My.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Energy_Counter.ViewModels
{
    public class EnergyView : NotifyPropertyChangedBase
    {
        public int ID { get; set; }
        public EnergyView(BuildingViewModel buildingViewModel, CounterViewModel counterViewModel)
        {
            BuildingViewModel = buildingViewModel;
            CounterViewModel = counterViewModel;
        }
        public EnergyView() { }
        public BuildingViewModel BuildingViewModel { get; set; }
        public CounterViewModel CounterViewModel { get; set; }
        public ICommand AddCount => new RelayCommand(x =>
        {
            var window = new AddCount();
            window.ShowDialog();
            CounterViewModel.Counter.Counts.Add(new CounterView(window.Amount, CounterViewModel.Counters.Count == 0 ? DateTime.Now : CounterViewModel.Counters.Last().Date + new TimeSpan(1, 0, 0, 0)));
            OnPropertyChanged(nameof(CounterViewModel));
        });
        private  SolidColorBrush _Brush { get; set; } = Brushes.WhiteSmoke;
        public SolidColorBrush Brush { get => _Brush; 
            set { _Brush = value; OnPropertyChanged(nameof(Brush)); } }

    }
}
