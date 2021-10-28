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
                Phouse.Add(new ParkingSpot(ParkingSpotSize, i - 1));
            }
            //läs in data här
        }
        public bool ParkVehicle(Vehicle vehicle)
        {
            
            for (int i = 0; i < Phouse.Count; i++)
            {
               bool isSpotEmpty = Phouse[i].CheckSpace(vehicle,out int spotNr);
                
                if (isSpotEmpty)
                {
                    Phouse[i].Park(vehicle, spotNr);
                    break;
                }
            }

            return true;
        }
        public bool Search(string regNr, out int spot)
        {
            for (int i = 0; i <= Phouse.Count; i++)
            {
                if (Phouse[i]) 
                {
                    spot = i;
                    return true;
                }
                
                

            }
            spot = -1;
            return false;
        }
        
    }
}
