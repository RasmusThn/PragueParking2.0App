using Newtonsoft.Json;
using Spectre.Console;
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
        public int Number { get; set; }
        public int AvailableSize { get; set; }
        //public string RegNr { get; set; }
        public static List<Vehicle> ParkedVehicles = new();

        public ParkingSpot(int size, int number)
        {
            this.Number = number;
            AvailableSize = size;
        }
        public bool Park(Vehicle vehicle, int spot)//Used for new Vehicles
        {

            ParkedVehicles.Add(vehicle);
            AvailableSize -= vehicle.Size;
            vehicle.SpotNumber = spot + 1;
            ReadDataFiles.SaveVehicleToFile();
            return true;
        }
        public bool Park(Vehicle vehicle) //Used for Vehicles saved to file
        {
            ParkedVehicles.Add(vehicle);
            AvailableSize -= vehicle.Size;
            return true;
        }
        /// <summary>
        /// Returns True if Spot has Avalible size for vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public bool CheckSpace(Vehicle vehicle)
        {
            if (AvailableSize == DataConfig.ParkingSpotSize && vehicle.Size == DataConfig.CarSize)
            {

                return true;
            }
            else if (vehicle.Size == DataConfig.McSize && AvailableSize == DataConfig.McSize
                                        || AvailableSize == DataConfig.ParkingSpotSize)
            {
                return true;
            }
            return false;
        }
        public static void OverViewParkingSpot()
        {
            
           
            int column = 5;
            for (int i = 0; i < ParkingHouse.Phouse.Count; i++)
            {
                if ( i == column)
                {
                    Console.WriteLine();
                    column += 5;
                }
                if (ParkingHouse.Phouse[i].AvailableSize == DataConfig.ParkingSpotSize )
                {
                    string empty = "Empty";
                    Console.Write(string.Format("Nr{0}: {1}", i+1, empty).PadLeft(20, ' '));                  
                }
               
                else if (ParkingHouse.Phouse[i].AvailableSize < DataConfig.ParkingSpotSize)
                {
                    foreach (Vehicle vehicle in ParkedVehicles)
                    {
                        if (vehicle.SpotNumber == (i + 1))
                        {
                            if (vehicle.Size == DataConfig.CarSize)
                            {
                                Console.Write(string.Format("Nr" + (i + 1) + ": " + vehicle.RegNr).PadLeft(20, ' '));
                            }
                            else if (vehicle.Size == DataConfig.McSize)
                            {
                                Console.Write(string.Format("Nr" + (i + 1) + ": " + vehicle.RegNr).PadLeft(20, ' '));
                            }
                                                       
                        }
                    }
                    
                }
                else if (ParkingHouse.Phouse[i].AvailableSize == DataConfig.McSize)
                {
                    Console.Write(string.Format(" Empty Mcspot"));
                }
                

            }
            
        }
    }
}
