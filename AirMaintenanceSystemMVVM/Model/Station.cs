using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  AirMaintenanceSystemMVVM.View;

namespace AirMaintenanceSystemMVVM.Model
{
    public class Station
    {
        public int Station_ID { get; set; }
        public string Station_Name { get; set; }

        public Station(int station_id,string station_name)
        {
            Station_ID = station_id;
            Station_Name = station_name;

        }

        public Station()
        {

        }

        public override string ToString()
        {
            return $"{nameof(Station_ID)}:{Station_ID},{nameof(Station_Name)}:{Station_Name}";
        }
    }
}
