using My.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Energy_Counter.Models;
namespace Energy_Counter.ViewModels;

public class CreateWindowViewModel : NotifyPropertyChangedBase
{
    public EnergyView? View { get; set; }
    public Window Window { get; set; }
    public bool IsAdd { get; set; }
    public CreateWindowViewModel()
    {
        IsAdd = false;
    }
    public ICommand Submit => new RelayCommand(x =>
    {  
        if (View.BuildingViewModel.Name == "")
        {
            var answer = MessageBox.Show("Empty Building Name, Continue?", "Incorrect data!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (answer == MessageBoxResult.Yes)
            {
                Window.Close();
            }
            return;
        }
        if (View.CounterViewModel.TariffViewModel.ProviderViewModel.Name == "")
        {
            var answer = MessageBox.Show("Empty Provider Name, Continue?", "Incorrect data!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (answer == MessageBoxResult.Yes)
            {
                Window.Close();
            }
            return;
        }
        if (View.CounterViewModel.TariffViewModel.PricePerOne.ToString() == "")
        {
            MessageBox.Show("Empty Price per One!", "Incorrect data!", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (View.CounterViewModel.TariffViewModel.Currency == "")
        {
            MessageBox.Show("Empty Currency!", "Incorrect data!", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (View.CounterViewModel.TariffViewModel.ResourceViewModel.Name == "")
        {
            MessageBox.Show("Empty Resource Name!", "Incorrect data!", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (View.CounterViewModel.TariffViewModel.ResourceViewModel.Unit == "")
        {
            MessageBox.Show("Empty Resource Unit!", "Incorrect data!", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        IsAdd = true;
        Window.Close();
    });
    public ICommand Reset => new RelayCommand(x =>
    {
        View.BuildingViewModel.Name = "";
        View.CounterViewModel.TariffViewModel.PricePerOne = 0;
        View.CounterViewModel.TariffViewModel.Currency = "";
        View.CounterViewModel.TariffViewModel.ResourceViewModel.Name = "";
        View.CounterViewModel.TariffViewModel.ResourceViewModel.Unit = "";
        View.CounterViewModel.Counter.Counts.Clear();
    });
}
