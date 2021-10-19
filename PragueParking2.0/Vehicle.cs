using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    public class Vehicle
    {
        private string regNr;
        private int size;

        public int Size
        {
            get { return size; }
            set
            {
                if (size == 2 || size == 4)
                {
                    size = value;
                }
                else
                {
                    Console.WriteLine("Wrong size!");
                }
            }
        }
        public string RegNr
        {
            get { return regNr; }
            set
            {       //Använd regEx här??
                    //if (regNr.Contains(null))
                    //{
                    //    Console.WriteLine("Mellanslag och dyl är inte tillåtet...");
                    //}
                    //else
                    //{
                regNr = value;
            }
        }


    }
    class Car : Vehicle
    {
        public Car(string regNr)
        {
            this.RegNr = regNr;
            this.Size = 4;
        }
    }
    class Mc : Vehicle
    {
        public Mc(string aRegNr)
        {
            this.RegNr = aRegNr;
            this.Size = 2;
        }
    }

    //public enum VehicleType
    //{
    //    //bike = 1,
    //    mc = 2,
    //    car = 4
    //    //bus = 16    
    //}
}
