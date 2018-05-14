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
        public StationCatalog StationCatalog { get; set; }

             //property
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
            get { return _stationName; }
            set
            {
                _stationName = value;
                OnPropertyChanged();
            }
        }
       
       
        public Station station_ID { get; set; }
      //  public static  int SelectedStationIndex { get; set; }
        public StationViewModel()
        {
            StationCatalog = StationCatalog.Instance;
            station_ID = new Station();
            NewStation= new Station();
            
           // SelectedStationIndex = -1;
        }
        private Station _newStation;
        private Station _selectedEventIndex;

        public Station NewStation
        {
            get { return _newStation; }
            set {
                _newStation = value;
                OnPropertyChanged();
               }
        }

         private ObservableCollection<Station> _selectedListView;

        public ObservableCollection<Station> SelectedListView
        {
            get { return this._selectedListView; }
            set
            {
                _selectedListView = value;
                OnPropertyChanged(nameof(SelectedListView));
            }
        }
        public Station SelectedEventIndex
        {
            get { return _selectedEventIndex; }
            set { _selectedEventIndex = value; OnPropertyChanged(nameof(SelectedEventIndex)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
