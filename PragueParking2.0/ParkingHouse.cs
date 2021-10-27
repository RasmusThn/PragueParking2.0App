using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class ParkingHouse
    {
        public int Size { get; } = 100;
        public string RegNr { get; set; }
        public List<ParkingSpot> PSpots { get; set; }
        public ParkingHouse()
        {
            for (int i = 1; i <= 100; i++)
            {
                PSpots.Add(new ParkingSpot(4));
            }
        }
    }
}
