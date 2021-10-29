using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class ParkingSpot
    {
        private int Nummer { get; set; }
        private int Size { get; set; }
        private int AvailableSize { get; set; }
        public string RegNr { get; set; }
        public static List<Vehicle> ParkedVehicles = new();

        public ParkingSpot(int size,int nummer)
        {
            // this.RegNr = "Empty";
            this.Nummer = nummer;
            Size = size;
            AvailableSize = size;


        }
        public bool Park(Vehicle vehicle, int spot)
        {
            // TODO: Lägger inte till för att det redan finns på den platsen?
            
            ParkedVehicles.Insert(spot, vehicle);//add kanske?
            AvailableSize -= vehicle.Size;
            return true;
        }
       public static bool Search(Vehicle vehicle, out int spot)
        {
            for (int i = 0; i < ParkedVehicles.Count; i++)
            {
                if (ParkedVehicles.Contains(vehicle))
                {
                    spot = i;
                    return true;
                }
            }

            spot = -1;
            return false;
        }
        public void Remove(string regNr)
        {
            
            //ParkedVehicles.Remove(regNr);  //TODO: Hur tar man bort ett object med bara regNr???
        }
        public bool CheckSpace(Vehicle vehicle)
        {
            //kolla med int om det får plats.
            
                if (AvailableSize == 4 && vehicle.Size == 4)
                {
                    
                    return true;
                }
                else if (AvailableSize == 2 || AvailableSize == 4 && vehicle.Size == 2)
                {
                    return true;
                }
           
            
            return false;
        }
        public static void OverviewParkingSpot()
        {
            Console.WriteLine(ParkedVehicles.ToString());
        }
        

    }
}
