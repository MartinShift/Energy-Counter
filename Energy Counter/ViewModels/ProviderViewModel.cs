using My.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Energy_Counter.Models;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Energy_Counter.ViewModels
{
    public class ProviderViewModel : NotifyPropertyChangedBase
    {
        public Provider Provider { get; set; }
        public ProviderViewModel(Provider provider)
        {
            Provider = provider;
        }
        public ProviderViewModel(int id, string name)
        {
            Provider = new(id, name);
        }
        public ProviderViewModel() { }
        [JsonIgnore]
        [XmlIgnore]
        public int ID
        {
            get => Provider.ID;
            set { Provider.ID = value; OnPropertyChanged(nameof(ID)); }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string Name
        {
            get => Provider.Name;
            set
            {
                Provider.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
