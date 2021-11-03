using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Spectre.Console;
using Newtonsoft.Json;
using System.IO;

namespace PragueParking2._0
{
    class Program
    {
        //public static ParkingHouse parkingList = new();
        //public static Config config = new Config();
        

        static void Main(string[] args)
        {
            ParkingHouse parkingList = new(); //Skapar Lista så allt drar igång. Gammal data läses in.
            //StartUpMenu();

            //string path = @"../../../Config.json";
            //string jsonConfig = File.ReadAllText(path);
            //JsonConvert.DeserializeObject<Config>(jsonConfig);
            //Console.WriteLine(Config.CarPriceHour );
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
                 
                 .AddChoices(new[] {"[green]Add vehicle[/]","[yellow]Move vehicle[/]", "[orange4_1]Remove vehicle[/]",
                     "[magenta]Overview[/]", "[DarkGreen]Search[/]", "[Red]Exit Program[/]"
                 }));
              
                switch (menu) //Gets user to input of choice
                {
                    case "[green]Add vehicle[/]":
                        {                          
                            Console.WriteLine(ValidateAction(AddVehicle()));
                            Console.ReadKey();
                        }
                        break;
                    case "[yellow]Move vehicle[/]":
                        {                         
                            Console.WriteLine(ValidateAction(MoveVehicle()));
                            Console.ReadKey();
                        }
                        break;
                    case "[orange4_1]Remove vehicle[/]":
                        {
                            Console.WriteLine(ValidateAction(RemoveVehicle()));
                            Console.ReadKey();
                        }
                        break;
                    case "[magenta]Overview[/]":
                        {
                            AnsiConsole.Write(HeadLine("Overview", Color.Orange4_1));
                            ParkingHouse.Overview();
                            Console.ReadKey();
                        }
                        break;
                    case "[DarkGreen]Search[/]":
                        {
                            string regNr = AskForRegNr();
                           
                            int spot = ParkingHouse.FindVehicleIndex(AskForRegNr());
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
        public static int AskForNewSpotNr()
        {
            
            try
            {
                Console.Write("Enter New Spot Number: ");
                int spotNr = int.Parse(Console.ReadLine());
                return spotNr;
            }
            catch (FormatException)
            {
                Console.WriteLine("You may only use numbers!");
                Console.ReadKey();
                Console.Clear();
                AskForNewSpotNr();
                return -1;
            }
            
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
        public static string AskForVehicleType()
        {
            var inputChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices("Car", "Mc", "Back to menu"));
            if (inputChoice == "Back to menu")
            {
                Menu();
            }
            return inputChoice;
        }    
        public static string AskForRegNr()
        {
            Console.Write("Enter RegNr: ");
            string regNr = Console.ReadLine();        
            return regNr;
        }
        public static Rule HeadLine(string header, Color color)
        {
            var rule = new Rule($"[{color}]{header}[/]");
            return rule;

        }      
        public static bool AddVehicle()
        {
            AnsiConsole.Write(HeadLine("Add Vehicle", Color.Blue));
            string vehicleType = AskForVehicleType();
            string regNr = AskForRegNr();
            bool checkReg = ParkingHouse.IsRegNrUsed(regNr);
            if (checkReg)
            {
                Console.WriteLine("There is already a Vehicle with that RegNr parked here!");
                return false;
            }
            else if (vehicleType == "Car")
            {

                ParkingHouse.ParkVehicle(new Car(regNr));
                return true;
            }
            else if (vehicleType == "Mc")
            {
                ParkingHouse.ParkVehicle(new Mc(regNr));
                return true;
            }

            else return false;

        }
        public static bool MoveVehicle()
        {
            AnsiConsole.Write(HeadLine("Move Vehicle", Color.Yellow));
            string regNr = AskForRegNr();
            int newSpot = AskForNewSpotNr();
           bool checkReg = ParkingHouse.IsRegNrUsed(regNr);
            if (checkReg)
            {
                ParkingHouse.MoveVehicle(regNr, newSpot);
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("There is no Vehicle with that RegNr here!");
                return false;
            }
        }
        public static bool RemoveVehicle()
        {
            AnsiConsole.Write(HeadLine("Remove vehicle", Color.Orange4_1));
            string regNr = AskForRegNr();
            ParkingHouse.RemoveVehicle(regNr);

            return true;
        }
        public static Config ReadInfoFromFile(Config dataConfig)
        {
            string path = @"../../../Config.json";
            string jsonConfig = File.ReadAllText(path);
            dataConfig = JsonConvert.DeserializeObject<Config>(jsonConfig);
            
            return dataConfig;
            //Console.WriteLine(jsonConfig);

            //string configstring = JsonConvert.DeserializeObject<string>(jsonConfig);   

            //CarSize = int.Parse(jsonConfig);
            //McSize = int.Parse(jsonConfig);
            //CarPriceHour = int.Parse(jsonConfig);
            //McPriceHour = int.Parse(jsonConfig);
            //ParkingHouseSpots = int.Parse(jsonConfig);
            //return config;
        }
        public static string ValidateAction(bool isValid)
        {
            if (isValid)
            {

                return "Action Succeded";
            }
            else
            {
                return "Action Failed";
            }
        }
    }
}

