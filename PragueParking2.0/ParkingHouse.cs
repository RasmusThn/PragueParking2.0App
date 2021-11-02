using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class ParkingHouse
    {
        const int ParkingSpotSize = 4;
        public static int Size { get; } = 100;
       
        public static List<ParkingSpot> Phouse = new();
        public ParkingHouse()
        {
            for (int i = 0; i < Size; i++)
            {
                Phouse.Add(new ParkingSpot(ParkingSpotSize, i + 1));
            }
            //läs in sparad data här
        }
        public bool ParkVehicle(Vehicle vehicle)
        {
            
            for (int i = 0; i <= Phouse.Count; i++)
            {
               bool isSpotEmpty = Phouse[i].CheckSpace(vehicle);
                
                if (isSpotEmpty)
                {
                     Phouse[i].Park(vehicle);
                     vehicle.SpotNumber = i + 1;
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
            Vehicle vehicle = RegNrToObject(regnr);
            
            //int index = -1;
            for (int i = 1; i <= Phouse.Count; i++)
            {
                if (Phouse[i].Equals(vehicle))
                {
                    return i;
                }
            }
            return -1;
           // return index = ParkingSpot.ParkedVehicles.FindIndex(x => x.RegNr == regnr);
        }
        public int MoveVehicle(string regnr, int newSpot)
        {
            int oldSpot = FindVehicle(regnr);
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
                Phouse[newSpot].Park(vehicle);
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
        public void Overview()
        {
            //for (int i = 0; i < Phouse.Count; i++)
            //{

            //        ParkingSpot.OverviewParkingSpot(); // Knas!!

            //}
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
        public bool RemoveVehicle(string regNr)
        {
            Vehicle vehicle = RegNrToObject(regNr);
            ParkingSpot.ParkedVehicles.Remove(vehicle);
            return true;
        }
        public static Vehicle RegNrToObject(string regNr)
        {
            List<Vehicle> findReg = ParkingSpot.ParkedVehicles.Where(x => x.RegNr == regNr).ToList();

            return findReg[0];
        }
    }
}
