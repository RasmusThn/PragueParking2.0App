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
        public static int AvailableSize { get; set; }
        public string RegNr { get; set; }
        public static List<Vehicle> ParkedVehicles = new();

        public ParkingSpot(int size,int nummer)
        {
            // this.RegNr = "Empty";
            this.Nummer = nummer;
            Size = size;

        }
        public static bool ParkVehicle(Vehicle vehicle)
        {
            
            ParkedVehicles.Add(vehicle);
            AvailableSize -= vehicle.Size;
            return true;
        }
       public static bool Search(Vehicle vehicle)
        {
            var find = ParkedVehicles.Contains(vehicle);

            return find;
        }
        public static void Remove(string regNr)
        {

        }
        public bool CheckSpace()
        {
            for (int i = 0; i < ParkedVehicles.Count; i++)
            {

            }

            return true;
        }
    }
}
