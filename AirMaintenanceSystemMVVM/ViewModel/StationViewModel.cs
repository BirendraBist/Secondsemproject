using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AirMaintenanceSystemMVVM.CatalogSingleton;
using AirMaintenanceSystemMVVM.Model;

namespace AirMaintenanceSystemMVVM.ViewModel
{
    public class StationViewModel : INotifyPropertyChanged
    {
        public StationCatalog StationCatalog { get; set; }
        private int _stationID;
        public int StationID
        {
            get { return _stationID; }
            set
            {
                _stationID = value;
                OnPropertyChanged();
            }
        }

        private string _stationName;

        public string StationName
        {
            get { return _stationName;}
            set
            {
                _stationName = value;
                OnPropertyChanged();
            }
        }

        public StationViewModel()
        {
            StationCatalog= StationCatalog.Instance; 
        }
       

        public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
