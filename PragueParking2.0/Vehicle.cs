﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class Vehicle
    {
        public string RegNr { get; set; }
        public int Size { get; set; }
        private DateTime Arrival { get; set; }

        public Vehicle(string regnr)
        {
            RegNr = regnr;
            Arrival = DateTime.Now;
        }
        
        
        


    }
}
