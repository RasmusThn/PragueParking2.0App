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
            AvailableSize = size;


        }
        public bool Park(Vehicle vehicle,int spotNr)
        {        
            // TODO: fixa så att det läggs in rätt borde gå med ADD
            
            ParkedVehicles.Insert(spotNr, vehicle);
            AvailableSize -= vehicle.Size;
            return true;
        }
       public bool Search(Vehicle vehicle)
        {
            var find = ParkedVehicles.Contains(vehicle);

            return find;
        }
        public void Remove(string regNr)
        {

        }
        public bool CheckSpace(Vehicle vehicle, out int nr)
        {
            for (int i = 0; i <= ParkedVehicles.Count; i++)
            {
                if (AvailableSize == 4)
                {
                    nr = i;
                    return true;
                }
            }
            nr = -1;
            return false;
        }
    }
}
