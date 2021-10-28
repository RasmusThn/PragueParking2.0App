using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class ParkingHouse
    {
        private const int ParkingSpotSize = 4;
        private int Size { get; } = 100;
        //public string RegNr { get; set; }
        private List<ParkingSpot> Phouse = new();
        public ParkingHouse()
        {
            for (int i = 1; i <= Size; i++)
            {
                Phouse.Add(new ParkingSpot(ParkingSpotSize, i -1));
            }
            //läs in data här
        }
        public bool ParkVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < Phouse.Count; i++)
            {
                Phouse[i].CheckSPace(vehicle);
                bool ok = true;
                if (true)
                {
                    Phouse[i].ParkVehicle(vehicle);
                }
            }

            return true;
        }
        
    }
}
