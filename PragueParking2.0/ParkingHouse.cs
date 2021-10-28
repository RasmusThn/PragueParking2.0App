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
       
        private List<ParkingSpot> Phouse = new();
        public ParkingHouse()
        {
            Phouse.Add(new ParkingSpot(ParkingSpotSize, 1));
            //for (int i = 1; i <= Size; i++)
            //{
            //    Phouse.Add(new ParkingSpot(ParkingSpotSize, i -1));
            //}
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
        
    }
}
