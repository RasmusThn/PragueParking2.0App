using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class ParkingSpot
    {
        private int Number { get; set; }
        //private int Size { get; set; }
        public int AvailableSize { get; set; }
        public string RegNr { get; set; }
        public static List<Vehicle> ParkedVehicles = new();

        public ParkingSpot(int size,int nummer)
        {
             //this.RegNr = "Empty";
            this.Number = nummer;
            //Size = size;
            AvailableSize = size;
            

        }
        public bool Park(Vehicle vehicle, int spot)
        {
            // TODO: Lägger inte till för att det redan finns på den platsen?
            
            ParkedVehicles.Add(vehicle);
            AvailableSize -= vehicle.Size;
            vehicle.SpotNumber = spot + 1;
            Config.SaveVehicleToFile();
            //RegNr = vehicle.RegNr;
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
        //public static void RemoveFromSpot(Vehicle vehicle)
        //{

        //    ParkedVehicles.Remove(vehicle);
        //    Config.SaveVehicleToFile();
        //}
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
        public static bool Move(Vehicle vehicle, int newSpot)
        {
            
            ParkedVehicles.Remove(vehicle);
            ParkedVehicles.Insert(newSpot, vehicle);
            return true;

        }
        public static void OverviewParkingSpot()
        {
            
            for (int i = 0; i < ParkedVehicles.Count; i++)
            {

                Console.Write("Nr{0}:", i + 1);
                Console.WriteLine(ParkedVehicles[i]);
            }
            
            
            
        }
        
       
        
    }
}
