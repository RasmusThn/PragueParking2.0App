using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class ParkingHouse
    {
        const int ParkingSpotSize = 4;
        private int Size { get; } = 100;
       
        public static List<ParkingSpot> Phouse = new();
        public ParkingHouse()
        {
            for (int i = 1; i <= Size; i++)
            {
                Phouse.Add(new ParkingSpot(ParkingSpotSize, i));
            }
            //läs in sparad data här
        }
        public bool ParkVehicle(Vehicle vehicle)
        {
            
            for (int i = 0; i < Phouse.Count; i++)
            {
               bool isSpotEmpty = Phouse[i].CheckSpace(vehicle);
                
                if (isSpotEmpty)
                {
                    Phouse[i].Park(vehicle, i);
                    break;
                }
            }

            return true;
        }
        public bool Search(string regNr, out int spot)
        {
            for (int i = 0; i <= Phouse.Count; i++)
            {
                
                //if (Phouse[i]) 
                //{
                //    spot = i;
                //    return true;
                //}
            }
            spot = -1;
            return false;
        }
        public int FindVehicle(string regnr)
        {
            int index = -1;
            return index = ParkingSpot.ParkedVehicles.FindIndex(x => x.RegNr == regnr);
        }
        public void Overview()
        {
            for (int i = 0; i < Phouse.Count; i++)
            {
            
                ParkingSpot.OverviewParkingSpot(); // Knas!!
            }
           
        }
    }
}
