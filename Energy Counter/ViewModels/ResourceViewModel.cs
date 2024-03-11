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
    public class ResourceViewModel : NotifyPropertyChangedBase
    {
        public ResourceViewModel(Resource resource) 
        {
            Resource = resource;
        }
        public ResourceViewModel(int id, string name, string unit)
        {
        Resource = new(id,name, unit);
        }
        public ResourceViewModel() { }
        public Resource Resource { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public int ID
        {
            get => Resource.ID;
            set
            {
               Resource.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string Name
        {
            get => Resource.Name;
            set
            {
                Resource.Name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Resource));
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string Unit
        {
            get => Resource.Unit;
            set
            {
                Resource.Unit = value;
                OnPropertyChanged(nameof(Unit));
               
            }
        }
    }
}
