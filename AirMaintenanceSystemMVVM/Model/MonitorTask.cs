using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMaintenanceSystemMVVM.Model
{
    public class MonitorTask
    {
        public int MonitorTask_ID { get; set; }
        public int Monitor_ID { get; set; }
        public int Task_ID { get; set; }

        public MonitorTask(int monitortask_id, int monitor_id, int task_id)
        {
            MonitorTask_ID = monitortask_id;
            Monitor_ID = monitor_id;
            Task_ID = task_id;
        }

        public MonitorTask()
        {

        }
    }
}
