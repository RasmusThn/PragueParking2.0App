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
            ReadDataFiles.SaveVehicleToFile();
            //RegNr = vehicle.RegNr;
            return true;
        }    
        public bool CheckSpace(Vehicle vehicle)
        {
            //kolla med int om det får plats.
            
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
