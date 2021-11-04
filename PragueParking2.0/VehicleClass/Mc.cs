using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class Mc : Vehicle
    {
        /// <summary>
        /// Takes in Registration number and sets Regnr, Size and Datetime Now
        /// </summary>
        /// <param name="regNr"></param>
        public Mc(string regNr) :base(regNr)
        {           
            this.Size = DataConfig.McSize;
            this.Arrival = DateTime.Now;
            this.PricePerHour = DataConfig.McPriceHour;
        }
       

    }
}
