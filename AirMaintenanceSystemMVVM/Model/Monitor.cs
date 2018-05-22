 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMaintenanceSystemMVVM.Model
{
    public class Monitor
    {
        public int Monitor_ID { get; set; }
        public string Monitor_Name { get; set; }
        public string Monitor_Type { get; set;  }

        public int Station_ID { get; set; }

        public Monitor(int monitor_id, string monitor_name,string monitor_type,int station_id)
        {
            Monitor_ID = monitor_id;
            Monitor_Name = monitor_name;
            Monitor_Type = monitor_type;
            Station_ID = station_id;

        }

        public Monitor()
        {

        }

        public override string ToString()
        {
            return
                $"{nameof(Monitor_ID)}:{Monitor_ID},{nameof(Monitor_Name)}:{Monitor_Name},{nameof(Monitor_Type)}:{Monitor_Type},{nameof(Station_ID)}:{Station_ID}";
        }
    }


}
