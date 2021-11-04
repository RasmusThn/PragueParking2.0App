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
        public int Number { get; set; }
        public int AvailableSize { get; set; }
        //public string RegNr { get; set; }
        public static List<Vehicle> ParkedVehicles = new();

        public ParkingSpot(int size,int number)
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
    }
}
