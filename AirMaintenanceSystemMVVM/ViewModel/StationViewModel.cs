using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AirMaintenanceSystemMVVM.CatalogSingleton;
using AirMaintenanceSystemMVVM.Model;
using  AirMaintenanceSystemMVVM.Persistency;
using AirMaintenanceSystemMVVM.Common;

namespace AirMaintenanceSystemMVVM.ViewModel
{
    public class StationViewModel : INotifyPropertyChanged
    {
        private Station _selectedStation;

        public StationCatalog StationCatalog { get; set; }
        //public MonitorCatalog MonitorCatalog { get; set; }

        //private ObservableCollection<Monitor> monitors= new ObservableCollection<Monitor>(); 
        private MonitorCatalog mc;

             //property
        private int _stationID;
        public int Station_ID
        {
            get { return _stationID; }
            set
            {
                _stationID = value;
                OnPropertyChanged();
            }
        }

        private string _stationName;

        public string Station_Name
        {
            get { return _stationName; }
            set
            {
                _stationName = value;
                OnPropertyChanged();
            }
        }
      public StationViewModel()
        {
         //monitors=new ObservableCollection<Monitor>();
           StationCatalog = StationCatalog.Instance;
           mc= MonitorCatalog.Instance;
            SelectedStation=new Station();
      }
       
        public Station SelectedStation
        {
            get { return _selectedStation; }
            set
            {
                _selectedStation = value;
               
                mc.getRightMonitors(SelectedStation.Station_ID);
               // Monitors = (new PersistencyFadace().GetMonitors(SelectedStation.Station_ID));
                OnPropertyChanged(nameof(SelectedStation));
            }
        }

        //public ObservableCollection<Monitor> Monitors
        //{
        //    get { return monitors; }
        //    set
        //    {
        //        monitors = value;
        //        OnPropertyChanged(nameof(Monitors));
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
