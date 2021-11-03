using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class Car : Vehicle
    {
        public Car(string regNr) : base(regNr)
        {         
            this.Size = 4;
            this.Arrival = DateTime.Now;
        }
        
    }
}
