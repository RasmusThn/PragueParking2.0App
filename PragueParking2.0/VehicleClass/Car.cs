using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class Car : Vehicle
    {
        /// <summary>
        /// Takes in Registration number and sets Regnr, Size and Datetime Now
        /// </summary>
        /// <param name="regNr"></param>
        public Car(string regNr) : base(regNr)
        {         
            this.Size = DataConfig.CarSize;
            this.Arrival = DateTime.Now;
            this.PricePerHour = DataConfig.CarPriceHour;
        }
        
    }
}
