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
    public class BuildingViewModel : NotifyPropertyChangedBase
    {
        public BuildingViewModel(Building building)
        {
            Building = building;
        }
        public BuildingViewModel() { }
        public Building Building { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public int ID
        {
            get => Building.ID; set
            {
                Building.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string Name
        {
            get => Building.Name; set
            {
                Building.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
