using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AirMaintenanceSystemMVVM.CatalogSingleton;
using AirMaintenanceSystemMVVM.Model;


namespace AirMaintenanceSystemMVVM.ViewModel
{
    public class MonitorViewModel : INotifyPropertyChanged
    {
        public MonitorCatalog MonitorCatalog { get; set; }

      

        //property
        private int _monitorID;
        public int Monitor_ID
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


      
        
        public MonitorViewModel()
        {
            MonitorCatalog = MonitorCatalog.Instance;
           
           NewMonitor = new Monitor();
            

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

        
      

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
