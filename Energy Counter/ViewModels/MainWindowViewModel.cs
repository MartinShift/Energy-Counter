using Energy_Counter.Models;
using Microsoft.Win32;
using My.BaseViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace Energy_Counter.ViewModels;

public class MainWindowViewModel : NotifyPropertyChangedBase
{
    public MainWindowViewModel()
    {
        EnergyViews = new();
        for (int i = 0; i < 10; i++)
        {
            var View = new EnergyView()
            {
                ID = i,
                BuildingViewModel = new(new Building(EnergyViews.Count, $"Some apartment, Floor: {i}")),
                CounterViewModel = new(new Tariff(EnergyViews.Count, new Resource(0, "Electricity", "KW"), 1.44, new Provider(EnergyViews.Count, "OblEnergo"), "UAH"), EnergyViews.Count)
            };
            EnergyViews.Add(View);
            OnPropertyChanged(nameof(EnergyViews));
        }
        OnPropertyChanged(nameof(EnergyViews));
    }
    public ObservableCollection<EnergyView> EnergyViews { get; set; }
    private EnergyView _SelectedItem { get; set; }
    public EnergyView SelectedItem
    {
        get => _SelectedItem;
        set
        {
            _SelectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
            OnPropertyChanged(nameof(Visibility));
            OnPropertyChanged(nameof(EnergyViews));
        }
    }
    public Visibility Visibility { get => SelectedItem == null ? Visibility.Hidden : Visibility.Visible; }
    public ICommand FullView => new RelayCommand(x =>
    {

    });
    public ICommand EditWindow => new RelayCommand(x =>
    {
        var window = new EditWindow(SelectedItem);
        window.ShowDialog();
        OnPropertyChanged(nameof(SelectedItem));
    });
    public ICommand CreateNew => new RelayCommand(x =>
    {
        int ID = EnergyViews.MaxBy(x => x.ID).ID + 1;
        EnergyView view = new EnergyView(new BuildingViewModel(new Building(ID, "")), new CounterViewModel(new Tariff(ID, new Resource(ID, "", ""), 0, new Provider(ID, ""), ""), ID));
        var window = new CreateWindow(view);
        window.ShowDialog();
        if ((window.DataContext as CreateWindowViewModel).IsAdd == true)
        {
            EnergyViews.Add(view);
        }
        OnPropertyChanged(nameof(EnergyViews));
    });
    public ICommand SaveAs => new RelayCommand(x =>
    {
        var dialog = new SaveFileDialog();
        dialog.Filter = "Xml File (*.xml)|*.xml|Json File (*.json)|*.json";
        if (dialog.ShowDialog() == true)
        {
            if (Path.GetExtension(dialog.FileName) == ".xml")
            {
                XmlHelper<List<EnergyView>>.Serialize(EnergyViews.ToList(), dialog.FileName);
            }
            else if (Path.GetExtension(dialog.FileName) == ".json")
            {
                File.WriteAllText(dialog.FileName, JsonSerializer.Serialize(EnergyViews.ToList()));
            }
        }
    });
    public ICommand OpenReplace => new RelayCommand(x =>
    {
        var views = OpenFile();
        if (views != null)
        {
            EnergyViews = new(views);
            OnPropertyChanged(nameof(EnergyViews));
        }
    });
    public ICommand OpenAdd => new RelayCommand(x =>
    {
        var views = OpenFile();
        if (views != null)
        {
            views.ForEach(x => EnergyViews.Add(x));
        }
    });
    public List<EnergyView> OpenFile()
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = "Xml File (*.xml)|*.xml|Json File (*.json)|*.json";
        if (dialog.ShowDialog() == true)
        {
            if (Path.GetExtension(dialog.FileName) == ".xml")
            {
                return XmlHelper<List<EnergyView>>.Deserialize(dialog.FileName);
            }
            else if (Path.GetExtension(dialog.FileName) == ".json")
            {
                return JsonSerializer.Deserialize<List<EnergyView>>(File.ReadAllText(dialog.FileName));
            }
        }
        return null;
    }
}