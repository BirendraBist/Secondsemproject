using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirMaintenanceSystemMVVM.Model;
using AirMaintenanceSystemMVVM.ViewModel;
using AirMaintenanceSystemMVVM.Persistency;

namespace AirMaintenanceSystemMVVM.Handler
{
    public class TaskHandler
    {
        public MonitorViewModel MonitorViewModel { get; set; }

        public TaskHandler(MonitorViewModel monitorViewModel)
        {
            MonitorViewModel = monitorViewModel;
        }

        public void UpdateTask()
        {
            //    Task task=new Task
            //    {

            //    }
        }

    }
}
