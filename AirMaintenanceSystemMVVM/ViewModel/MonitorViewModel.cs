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
using AirMaintenanceSystemMVVM.Persistency;
using Task = AirMaintenanceSystemMVVM.Model.Task;


namespace AirMaintenanceSystemMVVM.ViewModel
{
    public class MonitorViewModel : INotifyPropertyChanged
    {
        private Monitor _selectedMonitor;
        public MonitorCatalog MonitorCatalog { get; set; }
        private ObservableCollection<Monitor> monitors = new ObservableCollection<Monitor>();
        public TaskCatalog TaskCatalog { get; set; }
        private ObservableCollection<Task> tasks= new ObservableCollection<Task>();
       
        //property of Monitor
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

        public string Monitor_Name
        {
            get { return _monitorName; }
            set
            {
                _monitorName = value;
                OnPropertyChanged();
            }
        }

        public string _monitortype;
        public string Monitor_Type
        {
            get { return _monitortype; }
            set
            {
                _monitortype = value;
                OnPropertyChanged();
            }
        }
        //property of Task
        private int _taskID;
        public int Task_ID
        {
            get { return _taskID; }
            set
            {
                _taskID = value;
                OnPropertyChanged();
            }
        }

        private string _taskDescirption;

        public string Task_Descirption
        {
            get { return _taskDescirption; }
            set
            {
                _taskDescirption = value;
                OnPropertyChanged();
            }
        }

        private string _taskSchedule;

        public string Task_Schedule
        {
            get { return _taskSchedule; }
            set
            {
                _taskSchedule = value;
                OnPropertyChanged();
            }

        }
        private string _taskType;

        public string Task_Type
        {
            get { return _taskType; }
            set
            {
                _taskType = value;
                OnPropertyChanged();
            }

        }
        private string _taskStatus;
        public string Task_Status
        {
            get { return _taskStatus; }
            set
            {
                _taskStatus = value;
                OnPropertyChanged();
            }

        }
        private string _userID;
        public string User_ID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                OnPropertyChanged();
            }

        }
        public MonitorViewModel()
        {
            MonitorCatalog = MonitorCatalog.Instance;
            RightMonitors = new ObservableCollection<Monitor>();
            RightMonitors = MonitorCatalog.Monitors;
           tasks=new ObservableCollection<Task>();
        }
        
        public ObservableCollection<Monitor> RightMonitors
        {
            get { return monitors; }
            set
            {
                monitors = value;

                OnPropertyChanged(nameof(RightMonitors));
            }
        }

        public Monitor SelectedMonitor
        {
            get { return _selectedMonitor; }
            set
            {
                _selectedMonitor = value;
                new PersistencyFadace().GetMonitorsTasks(SelectedMonitor.Monitor_ID);
               Tasks = (new PersistencyFadace().GetTasks());
                OnPropertyChanged(nameof(SelectedMonitor));
            }
        }
        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
