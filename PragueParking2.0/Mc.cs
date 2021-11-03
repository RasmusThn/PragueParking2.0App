using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class Mc : Vehicle
    {
        public Mc(string regNr) :base(regNr)
        {           
            this.Size = 2;
            this.Arrival = DateTime.Now;
        }
       

    }
}
