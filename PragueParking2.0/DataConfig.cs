using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class DataConfig
    {
       
        [JsonProperty("CarSize")]
        public static int CarSize { get; set; }
        [JsonProperty("McSize")]
        public static int McSize { get; set; }
        [JsonProperty("CarPriceHour")]
        public static int CarPriceHour { get; set; }
        [JsonProperty("McPriceHour")]
        public static int McPriceHour { get; set; }
        [JsonProperty("ParkingHouseSpots")]
        public static int ParkingHouseSpots { get; set; }
        [JsonProperty("ParkingSpotSize")]
        public static int ParkingSpotSize { get; set; }

    }
}
