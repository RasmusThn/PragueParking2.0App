using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class ParkingSpot
    {
        public int Nummer { get; set; }
        public int Size { get; set; }
        public int AvailableSize { get; set; }
        public List<Vehicle> ParkedVehicles { get; set; }

        public ParkingSpot(int size)
        {
            Size = size;

        }
        public bool ParkVehicle(Vehicle vehicle)
        {
            ParkedVehicles.Add(vehicle);
            AvailableSize -= vehicle.Size;
            return true;
        }
    }
}
