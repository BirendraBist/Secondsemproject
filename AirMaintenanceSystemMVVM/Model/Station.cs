using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMaintenanceSystemMVVM.Model
{
   public class Station
    {
        public int Station_ID { get; set; }
        public string Station_Name { get; set; }

        public Station(int stationid,string stationname)
        {
            Station_ID = stationid;
            Station_Name = stationname;

        }

        public Station()
        {

        }

        public override string ToString()
        {
            return "";
        }
    }
}
