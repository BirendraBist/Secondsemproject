using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AirMaintenanceSystemMVVM.Model;
using  AirMaintenanceSystemMVVM.Persistency;


namespace AirMaintenanceSystemMVVM.CatalogSingleton
{
    public  class TaskCatalog : INotifyPropertyChanged
    {
        public static TaskCatalog Instance { get; }= new TaskCatalog();
        private ObservableCollection<Task> _tasks;

        public ObservableCollection<Task>Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged();
                
            }
        }

        private TaskCatalog()
        {
            Tasks= new ObservableCollection<Task>();
           
        }
        //public ObservableCollection<Task> GetSpecificTasks(int Mid)
        //{
        //   return  Tasks = new PersistencyFadace().GetRighTasks(Mid);
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
