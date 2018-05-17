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
using AirMaintenanceSystemMVVM.ViewModel;


namespace AirMaintenanceSystemMVVM.CatalogSingleton
{
    public class MonitorCatalog : INotifyPropertyChanged
    {
        public static MonitorCatalog Instance { get; } = new MonitorCatalog();

        public StationViewModel  svm;

        private ObservableCollection<Monitor> _monitors;

        public ObservableCollection<Monitor> Monitors
        {
            get { return _monitors; }
            set
            {
                _monitors = value;
                OnPropertyChanged();
            }
        }

        public MonitorCatalog()
        {
            svm = new StationViewModel();
            Monitors =new ObservableCollection<Monitor>();
            //int myint = svm.SelectedStation.Station_ID;
            //Monitors= new ObservableCollection<Monitor>(new PersistencyFadace().GetMonitors());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
