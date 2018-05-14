using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AirMaintenanceSystemMVVM.CatalogSingleton;
using AirMaintenanceSystemMVVM.CatalogSingleton;
using AirMaintenanceSystemMVVM.Model;


namespace AirMaintenanceSystemMVVM.ViewModel
{
    public class MonitorViewModel : INotifyPropertyChanged
    {
        public MonitorCatalog Monitor { get; set; }

        //property
        private int _monitorID;
        public int MonitorID
        {
            get { return _monitorID; }
            set
            {
                _monitorID = value;
                OnPropertyChanged();
            }
        }

        private string _monitorName;

        public string MonitorName
        {
            get { return _monitorName; }
            set
            {
                _monitorName = value;
                OnPropertyChanged();
            }
        }


        public Station monitor_ID { get; set; } 
         //public static  int SelectedMonitorIndex { get; set; }

        public MonitorViewModel()
        {
            MonitorCatalog = new MonitorCatalog.Instance;
        }
        private Monitor _newMonitor;
        private Monitor _selectedEventIndex;

        public Monitor NewMonitor
        {
            get { return _newMonitor; }
            set
            {
                _newMonitor = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Monitor> _selectedListView;

        public ObservableCollection<Monitor> SelectedListView
        {
            get { return this._selectedListView; }
            set
            {
                _selectedListView = value;
                OnPropertyChanged(nameof(SelectedListView));
            }
        }
        public Monitor SelectedEventIndex
        {
            get { return _selectedEventIndex; }
            set { _selectedEventIndex = value; OnPropertyChanged(nameof(SelectedEventIndex)); }
        }

        public object MonitorCatalog { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
