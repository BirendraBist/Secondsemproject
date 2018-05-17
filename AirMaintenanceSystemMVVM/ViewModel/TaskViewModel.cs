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
using Task = AirMaintenanceSystemMVVM.Model.Task;


namespace AirMaintenanceSystemMVVM.ViewModel
{
    public class TaskViewModel:INotifyPropertyChanged
    {
        public TaskCatalog TaskCatalog { get; set; }


        //property
        private int _taskID;
        public int TaskID
        {
            get { return _taskID; }
            set
            {
                _taskID = value;
                OnPropertyChanged();
            }
        }

        private string _taskDescirption;

        public string TaskDescirption
        {
            get { return _taskDescirption; }
            set
            {
                _taskDescirption = value;
                OnPropertyChanged();
            }
        }

        private string _taskSchedule;

        public string TaskSchedule
        {
            get { return _taskSchedule; }
            set
            {
                _taskSchedule = value;
                OnPropertyChanged();
            }

        }
        private string _taskType;

        public string TaskType
        {
            get { return _taskType; }
            set
            {
                _taskType = value;
                OnPropertyChanged();
            }

        }
        private string _taskStatus;

        public string TaskStatus
        {
            get { return _taskStatus; }
            set
            {
                _taskStatus = value;
                OnPropertyChanged();
            }

        }



        public Station task_ID { get; set; }
        
        public TaskViewModel()
        {
            TaskCatalog = TaskCatalog.Instance;
            
        }
        

       
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
