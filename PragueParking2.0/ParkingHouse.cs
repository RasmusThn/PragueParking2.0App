using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PragueParking2._0
{
     class ParkingHouse
    {
       
        private int ParkingSpotSize = DataConfig.ParkingSpotSize;
        private int Size { get; } = DataConfig.ParkingHouseSpots; 
        public static List<ParkingSpot> Phouse = new();

        public ParkingHouse()
        {
           //Config.ReadInfoFromFile();
            for (int i = 0; i < Size; i++)
            {
                Phouse.Add(new ParkingSpot(ParkingSpotSize, i + 1));
            }
            //läs in sparad data här
           ReadDataFiles.ReadVehicleFromFile();
        }
        public static bool ParkVehicle(Vehicle vehicle)
        {
            
            for (int i = 0; i <= Phouse.Count; i++)
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
        public static int FindVehicleIndex(string regnr)
        {
            Vehicle vehicle = RegNrToObject(regnr);

            int index = -1;
           
            //return index = ParkingSpot.ParkedVehicles.FindIndex(x => x.RegNr == regnr); // SpotNr för parkedvehicles
            return index = vehicle.SpotNumber; //spotNr för fordonet. ska nog använda denna.
        }
        public static void MoveVehicle(string regnr, int newSpot)
        {
            int oldSpot = FindVehicleIndex(regnr);
            if (oldSpot == -1)
            {
                Console.WriteLine("Your vehilce is nowhere to be found"); // borde aldrig köras eftersom vi innan kollat ifall regnr finns med
            }
            Vehicle vehicle = RegNrToObject(regnr);

            bool isSpotEmpty = Phouse[newSpot].CheckSpace(vehicle);
            if (isSpotEmpty)
            {
                RemoveVehicle(regnr);
                Phouse[newSpot].Park(vehicle, newSpot);               

                Phouse[oldSpot].AvailableSize += vehicle.Size;

                Console.WriteLine("Vehicle has been moved");
            }
            else
            {
                Console.WriteLine("Couldn't move vehicle"); //borde heller aldrig köras
            }

           
        }
        public static bool RemoveVehicle(string regNr)
        {

            int spot = FindVehicleIndex(regNr);
            Vehicle vehicle = RegNrToObject(regNr);           
            ParkingSpot.ParkedVehicles.Remove(vehicle);
            Phouse[spot].AvailableSize += vehicle.Size;
            
            ReadDataFiles.SaveVehicleToFile();
            return true;
        }
        public static void Overview()
        {
            
            int x = 0;
            for (int i = 0; i < Phouse.Count; i++)
            {
                if (ParkingSpot.ParkedVehicles != null)
                {
                    Console.Write("Nr{0}: ", i + 1);
                    foreach (Vehicle vehicle in ParkingSpot.ParkedVehicles)
                    {
                        if (vehicle.SpotNumber == i)
                        {
                            Console.Write(vehicle.RegNr + " ");
                        }
                        else break;
                    }
                    //Console.Write(ParkingSpot.ParkedVehicles[i] + " ");
                    x++;
                }
                else if (Phouse[i].RegNr == null)
                {
                    Console.Write("Nr{0}: ", i + 1);
                    x++;
                }
                if (x == 5)
                {
                    Console.WriteLine();
                    x = 0;
                }
            }
        }       
        public static Vehicle RegNrToObject(string regNr)
        {
            List<Vehicle> findReg = ParkingSpot.ParkedVehicles.Where(x => x.RegNr == regNr).ToList();

            return findReg[0];
        }
        /// <summary>
        /// Returns true if there already is a Vehicle registered with that same RegNr
        /// </summary>
        /// <param name="regNr"></param>
        /// <returns></returns>
        public static bool IsRegNrUsed(string regNr)
        {
            if (ParkingSpot.ParkedVehicles != null)
            {
                foreach (Vehicle vehicle in ParkingSpot.ParkedVehicles)
                {
                    if (vehicle.RegNr == regNr)
                    {
                        return true;
                    }
                }
            }
            return false;
            
        }
    }
}
