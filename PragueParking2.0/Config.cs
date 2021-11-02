using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PragueParking2._0
{
    class Config
    {
        public static int CarSize { get; set; }
        public static int McSize { get; set; }
        public static int CarPriceHour { get; set; }
        public static int McPriceHour { get; set; }
        public static int ParkingHouseSpots { get; set; }


        //public Config()
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
        public static void ReadInfoFromFile()
        {
            string path = @"../../../Config.json";
            string jsonConfig = File.ReadAllText(path);
            JsonConvert.DeserializeObject<Config>(jsonConfig);

           
            //Console.WriteLine(jsonConfig);

            //string configstring = JsonConvert.DeserializeObject<string>(jsonConfig);   
           
            //CarSize = int.Parse(jsonConfig);
            //McSize = int.Parse(jsonConfig);
            //CarPriceHour = int.Parse(jsonConfig);
            //McPriceHour = int.Parse(jsonConfig);
            //ParkingHouseSpots = int.Parse(jsonConfig);
            //return config;
        }
        public static void SaveVehicleToFile()
        {
            string path = @"../../../ParkedJsonVehicles.json";
            string vehicles = JsonConvert.SerializeObject(ParkingSpot.ParkedVehicles).ToString();
            
            File.WriteAllText(path, vehicles);
        }
        public static void ReadVehicleFromFile()
        {
            string path = @"../../../ParkedJsonVehicles.json";
            string readJson = File.ReadAllText(path);
            List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(readJson).ToList();

            foreach (Vehicle vehicle in vehicles)
            {
                ParkingSpot.ParkedVehicles.Add(vehicle);
                
            }
        }
    }
}
