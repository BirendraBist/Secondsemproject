using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMaintenanceSystemMVVM.Model
{
   public class Task
    {
        public int Task_ID { get; set; }
        public string Task_Description { get; set; }
        public string Task_Schedule { get; set; }
        public string Task_Type { get; set; }

        public string Task_Status { get; set; }

        public int User_ID { get; set; }
        public int Monitor_ID { get; set; }
        public Task(int task_id, string task_description, string task_schedule, string task_type, string task_status,
            int user_id,int monitor_id)
        {
            Task_ID = task_id;
            Task_Description = task_description;
            Task_Schedule = task_schedule;
            Task_Type = task_type;
            Task_Status = task_status;
            User_ID = user_id;
            Monitor_ID = monitor_id;

        }

        public Task()
        {

        }
    }
}
