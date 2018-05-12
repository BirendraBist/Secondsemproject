using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AirMaintenanceSystemMVVM.Model;
using AirMaintenanceSystemMVVM.Persistency;

namespace AirMaintenanceSystemMVVM.CatalogSingleton
{
   public  class StationCatalog:INotifyPropertyChanged
    {
        public static StationCatalog Instance { get; } = new StationCatalog();

        private ObservableCollection<Station> _stations;

        public ObservableCollection<Station> Stations
        {
            get { return _stations; }
            set
            {
                _stations = value;
                OnPropertyChanged();
            }
        }

        private StationCatalog()
        {
            Stations = new ObservableCollection<Station>();
            Stations= new ObservableCollection<Station>(new PersistencyFadace().GetStaions());

        }

        
        //public void Add(int Station_ID, string Station_Name)
        //{
        //    Stations.Add(new Station(Station_ID,Station_Name));
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
