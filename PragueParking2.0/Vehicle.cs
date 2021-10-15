using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class Vehicle
    {      
        public string RegNr { get; set; }
        public VehicleType size;
        public Vehicle()
        {

        }
        public Vehicle(string regNr, int type)
        {
            this.RegNr = regNr;
            this.size = (VehicleType)type;
        }
        public Vehicle(VehicleType type)
        {
            this.size = type;
        }
        public VehicleType Size
        {
            get { return size; }
        }
    }
    class Car : Vehicle
    {
        
    }
    class Mc : Vehicle
    {

    }
   public enum VehicleType
    {
        Mc = 2,
        Car = 4            
    }
}
