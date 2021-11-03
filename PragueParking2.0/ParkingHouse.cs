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
       
        const int ParkingSpotSize = 4;
        public int Size { get; } = 100;      
        public static List<ParkingSpot> Phouse = new();

        public ParkingHouse()
        {
           //Config.ReadInfoFromFile();
            for (int i = 0; i < Size; i++)
            {
                Phouse.Add(new ParkingSpot(ParkingSpotSize, i + 1));
            }
            //läs in sparad data här
           Config.ReadVehicleFromFile();
        }
        public static bool ParkVehicle(Vehicle vehicle)
        {
            
            for (int i = 0; i <= Phouse.Count; i++)
            {
               bool isSpotEmpty = Phouse[i].CheckSpace(vehicle);
                //bool alreadyThere = ParkingSpot.ParkedVehicles[i].Equals(vehicle.RegNr);
                if (ParkingSpot.ParkedVehicles.Equals(vehicle.RegNr))
                {
                    return false;
                }
               // bool alreadyThere = Phouse[i].Equals(vehicle.RegNr); 
                if (isSpotEmpty)
                {
                     Phouse[i].Park(vehicle, i);
                     //vehicle.SpotNumber = i + 1;
                    
                    break;
                }
            }

            return true;
        }
       
        public static int FindVehicleIndex(string regnr)
        {
            Vehicle vehicle = RegNrToObject(regnr);

            int index = -1;
            //for (int i = 0; i <= Phouse.Count; i++)
            //{
            //    if (Phouse[i].Equals(vehicle))
            //    {
            //        return i;
            //    }
            //    //else
            //    //{
            //    //    return -1;
            //    //}
            //}
            //return -1;
            return index = ParkingSpot.ParkedVehicles.FindIndex(x => x.RegNr == regnr);
        }
        public static int MoveVehicle(string regnr, int newSpot)
        {
            int oldSpot = FindVehicleIndex(regnr);
            if (oldSpot == -1)
            {
                return -1;
            }
            Vehicle vehicle = RegNrToObject(regnr);
            //List<Vehicle> findReg = ParkingSpot.ParkedVehicles.Where(x => x.RegNr == regnr).ToList();
           
            //int oldSpot = FindVehicle(findReg[0]);

            bool isSpotEmpty = Phouse[newSpot].CheckSpace(vehicle);
            if (isSpotEmpty)
            {
                RemoveVehicle(regnr);
                Phouse[newSpot].Park(vehicle, newSpot);
               // Phouse[oldSpot].Remove(vehicle);

                Phouse[oldSpot].AvailableSize += vehicle.Size;
                
                //ParkingSpot.Move(findReg[0], newSpot);
                return 1;
            }
            else
            {
                return 2;
            }

           
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
        public static bool RemoveVehicle(string regNr)
        {
            int spot = FindVehicleIndex(regNr);
            Vehicle vehicle = RegNrToObject(regNr);
            ParkingSpot.ParkedVehicles.Remove(vehicle);
            Phouse[spot].AvailableSize += vehicle.Size;
            
            Config.SaveVehicleToFile();
            return true;
        }
        public static Vehicle RegNrToObject(string regNr)
        {
            List<Vehicle> findReg = ParkingSpot.ParkedVehicles.Where(x => x.RegNr == regNr).ToList();

            return findReg[0];
        }
    }
}
