using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectre.Console;

namespace PragueParking2._0
{
    class ParkingHouse
    {

        private int ParkingSpotSize = DataConfig.ParkingSpotSize;
        private int Size { get; } = DataConfig.ParkingHouseSpots;
        public static List<ParkingSpot> Phouse = new();

        public ParkingHouse()
        {          
            for (int i = 0; i < Size; i++)
            {
                Phouse.Add(new ParkingSpot(ParkingSpotSize, i + 1));
            }
            //läser in sparad data här
            ReadDataFiles.ReadVehicleFromFile();
        }
        public static bool ParkVehicle(Vehicle vehicle)
        {
            for (int i = 0; i <= Phouse.Count; i++)
            {
                bool isSpotEmpty = Phouse[i].CheckSpace(vehicle);

                if (isSpotEmpty)
                {
                    Phouse[i].Park(vehicle, i);
                    break;
                }
            }

            return true;
        }// Parks new Vehicles
        public static bool ParkVehicle(Vehicle vehicle, int spot) // Parks Saved vehicles at the begining
        {
            Phouse[spot - 1].Park(vehicle);
            return true;
        }
        public static void FindVehicle(string regnr)
        {
            bool checkReg = IsRegNrUsed(regnr);
            if (checkReg)
            {
                Vehicle vehicle = RegNrToObject(regnr);
                
                Console.WriteLine($"{vehicle.RegNr} has been parked at spot number {vehicle.SpotNumber} since {vehicle.Arrival}");
                
            }
            else
            {
                Console.WriteLine("There is no vehicle with that RegNr here");
            }
            
        }
        public static void ShowParkingSpot(int spot)
        {
            if (Phouse[spot - 1].AvailableSize == DataConfig.ParkingSpotSize)
            {
                Console.WriteLine("No vehilce is parked at that spot");                
            }
            else
            {
                foreach (Vehicle vehicle in ParkingSpot.ParkedVehicles)
                {
                    if (vehicle.SpotNumber == spot)
                    {
                        Console.WriteLine(vehicle.RegNr);
                    }
                }              
            }
        }
        public static void MoveVehicle(string regnr, int newSpot)
        {          
            Vehicle vehicle = RegNrToObject(regnr);
            int oldSpot = vehicle.SpotNumber;
            bool isSpotEmpty = Phouse[newSpot].CheckSpace(vehicle);
            if (isSpotEmpty)
            {
                RemoveVehicle(regnr);
                Phouse[newSpot].Park(vehicle, newSpot);
                Phouse[oldSpot].AvailableSize += vehicle.Size;

                Console.WriteLine("Vehicle has been moved");
            }
            else
            {
                Console.WriteLine("Couldn't move vehicle"); //borde heller aldrig köras
            }
        }
        public static bool RemoveVehicle(string regNr)
        {
            Vehicle vehicle = RegNrToObject(regNr);
            ParkingSpot.ParkedVehicles.Remove(vehicle);
            Phouse[vehicle.SpotNumber].AvailableSize += vehicle.Size;
            
            ReadDataFiles.SaveVehicleToFile();
            return true;
        }
        public static void Overview()
        {
            //Fick hjälp av Edwin med denna!

            Table newTable = new Table().Centered();
            var spotColor = "";
            var printResult = "";

            for (int i = 0; i < DataConfig.ParkingHouseSpots; i++)
            {
                if (Phouse[i].AvailableSize == DataConfig.ParkingSpotSize)
                {
                    spotColor = "green";
                }
                else if (Phouse[i].AvailableSize == DataConfig.McSize)
                {
                    spotColor = "yellow";
                }
                else if (Phouse[i].AvailableSize == 0)
                {
                    spotColor = "red";
                }
                printResult += ($"[{spotColor}] {i + 1}[/] ");
            }
            newTable.AddColumn(new TableColumn(printResult));
            AnsiConsole.Write(newTable);

            Table t1 = new Table();
            t1.AddColumns("[green] EMPTY [/]", "[yellow] HALF-FULL [/]", "[red] FULL [/]").Centered().Alignment(Justify.Center);
            AnsiConsole.Write(t1);
        }
        public static Vehicle RegNrToObject(string regNr)
        {
            List<Vehicle> findReg = ParkingSpot.ParkedVehicles.Where(x => x.RegNr == regNr).ToList();
            
            return findReg[0];
        }
        /// <summary>
        /// Returns true if there already is a Vehicle registered with that same RegNr
        /// </summary>
        /// <param name="regNr"></param>
        /// <returns></returns>
        public static bool IsRegNrUsed(string regNr)
        {
            if (ParkingSpot.ParkedVehicles != null)
            {
                foreach (Vehicle vehicle in ParkingSpot.ParkedVehicles)
                {
                    if (vehicle.RegNr == regNr)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static void CalculatePrice(string regNr)
        {
            Vehicle vehicle = RegNrToObject(regNr);
            DateTime then = vehicle.Arrival;
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = now - then;
            
            if (timeSpan.TotalHours > 0.10)
            {
                double hours = timeSpan.TotalHours;
                double roundedHours = Math.Round(hours);
                if (timeSpan.Seconds > 0 && timeSpan.Minutes < 30)
                {
                    roundedHours++;
                }
                double payTime = roundedHours * vehicle.PricePerHour;
                Math.Round(payTime);                              
                Console.WriteLine("Your total cost will be {0} CSK", payTime);
                Console.WriteLine("Have a Good Day!");
            }
            else
            {
                Console.WriteLine("You have parked for less than 10 minutes, therefore you aren't charged any CSK");
                Console.WriteLine("Have a Good Day!");
            }
        }

    }
}
