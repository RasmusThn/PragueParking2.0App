using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class Vehicle
    {
        public string RegNr { get; set; }
        public int Size { get; set; }
        public int SpotNumber { get; set; } 
        public DateTime Arrival { get; set; }
        public int PricePerHour { get; set; }



        public Vehicle(string regnr)
        {
            RegNr = regnr;
           
        }
        public override string ToString()
        {
            
            return RegNr;
        }

    }
}
