using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Spectre.Console;

namespace PragueParking2._0
{
    class Program
    {
       public static ParkingHouse parkingList = new();
        static void Main(string[] args)
        {
            
            //StartUpMenu();
            Menu();
        }

        public static void Menu()
        {
            string menu;
            do
            {
                Console.Clear();
                AnsiConsole.Write(HeadLine("Prague Parking 2.0", Color.Gold3));
                menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
                 
                 .AddChoices(new[] {"[green]Add vehicle[/]","[yellow]Move vehicle[/]", "[orange4_1]Remove vehicle[/]","[magenta]Overview[/]","[Red]Exit Program[/]", "Search"

                 }
                
                 ));

                switch (menu) //Gets user to input of choice
                {
                    case "[green]Add vehicle[/]":
                        {
                            AnsiConsole.Write(HeadLine("Add Vehicle", Color.Blue));
                            string vehicleType = VehicleTypeChecker();
                            string regNr = AskForRegNr();
                            if (vehicleType == "Car")
                            {
                                parkingList.ParkVehicle(new Car(regNr));                               
                            }
                            else 
                            {
                                parkingList.ParkVehicle(new Mc(regNr));
                            }                       
                        }
                        break;
                    case "[yellow]Move vehicle[/]":
                        {
                            AnsiConsole.Write(HeadLine("Move Vehicle", Color.Yellow));
                            string regNr = AskForRegNr();
                            int newSpot = AskForNewSpotNr();
                            parkingList.MoveVehicle(regNr, newSpot);
                            Console.ReadKey();
                        }
                        break;
                    case "[orange4_1]Remove vehicle[/]":
                        {
                            AnsiConsole.Write(HeadLine("Remove vehicle", Color.Orange4_1));
                            Console.ReadKey();
                        }
                        break;
                    case "[magenta]Overview[/]":
                        {
                            AnsiConsole.Write(HeadLine("Overview", Color.Orange4_1));
                            parkingList.Overview();
                            Console.ReadKey();
                        }
                        break;
                    case "Search":
                        {
                            string regNr = AskForRegNr();
                            //bool isContaining = parkingList.Search(regNr, out int spotNr);
                            //if (isContaining)
                            //{
                            //    Console.WriteLine("Your vehicle with reg nr: {0} were found at spot nr:{1}",regNr,spotNr);
                            //}
                             int spot = parkingList.FindVehicle(regNr);
                            Console.WriteLine(spot);
                            Console.ReadKey();
                        }   
                        break;
                    case "[Red]Exit Program[/]": Console.WriteLine("Exit funkar"); break;
                    default:
                        break;
                }
            }
            while (menu != "[Red]Exit Program[/]");

        }

        private static int AskForNewSpotNr()
        {
            Console.Write("Enter New Spot Number: ");
            int spotNr = int.Parse(Console.ReadLine());
            return spotNr;
        }

        public static void StartUpMenu()
        {
            AnsiConsole.Status()
        .Start("Starting ParkingApp2.0", ctx =>
        {
            Thread.Sleep(2000);

            ctx.Status("Loading potential files...");
            Thread.Sleep(2000);

            ctx.Status("Turning 1's and 0's on and off...");
            Thread.Sleep(2000);
        });
        }
        public static void Overview()
        {

        }
        public static string VehicleTypeChecker()
        {
            var inputChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices("Car", "Mc"));
            return inputChoice;
        }
        public static void ParkedVehicleBar()
        {
            AnsiConsole.Write(new BarChart()
            .Width(60)
            .Label("[green bold underline]Number of Vehicles[/]")
            .CenterLabel()
            .AddItem("CAR", 52, Color.Yellow)
            .AddItem("MC", 12, Color.Green)
            .AddItem("Bus", 4, Color.Red));
        }
        public static Rule HeadLine(string header, Color color)
        {
            var rule = new Rule($"[{color}]{header}[/]");
            return rule;

        }
        public static string AskForRegNr()
        {
            Console.Write("Enter RegNr: ");
            string regNr = Console.ReadLine();
            return regNr;
        }
        public static void AddVehicle(string vehicleType)
        {
            string regNr = AskForRegNr();
            
                
            
        }
       
    }
}

