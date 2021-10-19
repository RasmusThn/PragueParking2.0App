using System;
using System.Collections.Generic;
using System.Threading;
using Spectre.Console;

namespace PragueParking2._0
{
    class Program
    {
        public static List<string> parkingList = new List<string>(100);
        static void Main(string[] args)
        {
            RunThroughParkingList();  //Lägg till så att den först kollar igenom sparade fordon.         
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
                 
                 .AddChoices(new[] {"[green]Add vehicle[/]","[yellow]Move vehicle[/]", "[orange4_1]Remove vehicle[/]","[magenta]Overview[/]","[Red]Exit Program[/]"

                 }
                
                 ));

                switch (menu) //Gets user to input of choice
                {
                    case "[green]Add vehicle[/]":
                        {
                            AnsiConsole.Write(HeadLine("Add Vehicle", Color.Blue));
                            string vehicleType = VehicleTypeChecker();
                            AddVehicle(vehicleType);
                        }
                        break;
                    case "[yellow]Move vehicle[/]":
                        {
                            AnsiConsole.Write(HeadLine("Move Vehicle", Color.Yellow));
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
                            Overview();
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
        public static void RunThroughParkingList()
        {
            for (int i = 0; i < 101; i++)
            {
                parkingList.Add("Empty");
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
        public static void Overview()
        {

            #region old overview
            const int column = 6;
            int x = 1;

            
            for (int i = 1; i < 101; i++)
            {


                if (x >= column && x % column == 0)
                {
                    Console.WriteLine();
                    x = 1;
                }
                if (parkingList[i] == "Empty")//If spot is Empty
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(i + ": ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Empty \t");
                    Console.ResetColor();
                    x++;
                }
                else if (parkingList[i].Contains("MC") && parkingList[i].Length < 14 && !parkingList[i].Contains('|'))//Adds Yellow color if half full with mc
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(i + ": ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(parkingList[i] + "  Empty ");
                    Console.ResetColor();
                    x++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(i + ": ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(parkingList[i] + "\t");
                    Console.ResetColor();
                    x++;
                }

                // Console.WriteLine(i + ": " + parkingList[i]);
            }
            #endregion
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
            if (vehicleType == "Car")
            {
                new Car(regNr);
                for (int i = 1; i < 101; i++)
                {
                    if (parkingList[i] == "Empty")
                    {
                        parkingList[i] = regNr;
                        break;
                    }
                }
            }
            else if (vehicleType == "Mc")
            {
                new Mc(regNr);
                for (int i = 1; i < 101; i++)
                {
                    if (parkingList[i] == "Empty")
                    {
                        parkingList[i] = regNr;
                        break;
                    }
                }
            }
        }
    }
}

