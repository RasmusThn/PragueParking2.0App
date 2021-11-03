using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PragueParking2._0
{
    public class Config
    {
        public static int CarSize { get; }
        public static int McSize { get; set ; }
        public static int CarPriceHour { get; set; }
        public static int McPriceHour { get; set; }
        public static int ParkingHouseSpots { get; set; }


        //public Config(Config config)
        //{
         

        //    CarSize = config.CarSize;
        //    McSize = config.McSize;
        //    CarPriceHour = config.CarPriceHour;
        //    McPriceHour = config.McPriceHour;
        //    ParkingHouseSpots = config.ParkingHouseSpots;
        //}

        //public void SetValueToConfig(Config config)
        //{
        //    CarSize = config.CarSize;
        //    McSize = config.McSize;
        //    CarPriceHour = config.CarPriceHour;
        //    McPriceHour = config.McPriceHour;
        //    ParkingHouseSpots = config.ParkingHouseSpots;

        //}

        public static void SaveVehicleToFile()
        {
            string path = @"../../../SavedVehicles.json";
            string vehicles = JsonConvert.SerializeObject(ParkingSpot.ParkedVehicles);
            
            File.WriteAllText(path, vehicles);
        }
        public static void ReadVehicleFromFile()
        {
            string path = @"../../../SavedVehicles.json";
            string readJson = File.ReadAllText(path);
            List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(readJson).ToList();

            foreach (Vehicle vehicle in vehicles)
            {
                ParkingHouse.ParkVehicle(vehicle);
                
                
            }
        }
    }
}
