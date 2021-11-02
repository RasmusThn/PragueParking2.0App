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
        public int CarSize { get; set; }
        public int McSize { get; set; }
        public int CarPriceHour { get; set; }
        public int McPriceHour { get; set; }
        public int ParkingHouseSpots { get; set; }

        public Config()
        {
            
        }
        public Config(Config config)
        {
            
            CarSize = config.CarSize;
            McSize = config.McSize;
            CarPriceHour = config.CarPriceHour;
            McPriceHour = config.McPriceHour;
            ParkingHouseSpots = config.ParkingHouseSpots;


        }
        public static Config ReadFromFile()
        {
            string path = @"../../../Config.Json";
            string jsonConfig = File.ReadAllText(path);
            Config config = new Config(JsonConvert.DeserializeObject<Config>(jsonConfig));
            
            return config;
        }
    }
}
