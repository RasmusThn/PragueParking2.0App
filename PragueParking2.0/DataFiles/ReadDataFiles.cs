using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PragueParking2._0
{
    public class ReadDataFiles
    {
        
        public static void SetValuesFromConfig()
        {
            string path = @"../../../DataFiles/Config.json";
            string jsonConfig = File.ReadAllText(path);
            JsonConvert.DeserializeObject<DataConfig>(jsonConfig);                    
        }

        public static void SaveVehicleToFile()
        {
            string path = @"../../../DataFiles/SavedVehicles.json";
            string vehicles = JsonConvert.SerializeObject(ParkingSpot.ParkedVehicles);          
            File.WriteAllText(path, vehicles);
        }
        public static void ReadVehicleFromFile()
        {
            string path = @"../../../DataFiles/SavedVehicles.json";
            string readJson = File.ReadAllText(path);
            List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(readJson).ToList();

            foreach (Vehicle vehicle in vehicles)
            {
                ParkingHouse.ParkVehicle(vehicle, vehicle.SpotNumber);               
            }
        }
    }
}
