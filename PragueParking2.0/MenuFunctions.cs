using System;
using System.Threading;
using Spectre.Console;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace PragueParking2._0
{
    static class MenuFunctions
    {
        public static void StartProgram()
        {
            ReadDataFiles.SetValuesFromConfig();
            ParkingHouse parkingList = new(); //Skapar Lista så allt kan dra igång / kör konstruktorn
            StartUpMenu();
            Menu();
        }
        public static void StartUpMenu()
        {
            AnsiConsole.Status()
        .Start("Starting ParkingApp2.0", ctx =>
        {
            Thread.Sleep(2000);
            ctx.Status("Loading Configuration Files...");
            Thread.Sleep(2000);
            ctx.Status("Loading Saved Files...");
            Thread.Sleep(2000);
            ctx.Status("Starting Up Program...");
            Thread.Sleep(2000);
        });
        }
        public static void Menu()
        {
            string menu;
            do
            {
                Console.Clear();
                ParkingHouse.Overview();
                AnsiConsole.Write(HeadLine("Prague Parking 2.0", Color.Gold3));
                menu = AnsiConsole.Prompt(new SelectionPrompt<string>()

                 .AddChoices(new[] {"[green]Add vehicle[/]","[yellow]Move vehicle[/]", "[orange4_1]Remove vehicle[/]",
                     "[magenta]Overview[/]", "[DarkGreen]Search[/]", "[Red]Exit Program[/]"
                 }));
                Console.Clear();
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

                            OverViewStarter();
                        }
                        break;
                    case "[DarkGreen]Search[/]":
                        {
                            AnsiConsole.Write(HeadLine("Search", Color.DarkGreen));
                            ReturnToMenuChoice("Search");
                            ParkingHouse.FindVehicle(AskForRegNr());
                            Console.ReadKey();
                        }
                        break;
                    case "[Red]Exit Program[/]":
                        {
                            AnsiConsole.Write(HeadLine("Thanks For Using Prague Parking 2.0", Color.Gold3));
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        break;
                }
            }
            while (menu != "[Red]Exit Program[/]");
        }
        public static int AskForSpotNr()
        {
            try
            {
                Console.Write("Enter Spot Number: ");
                int spotNr = int.Parse(Console.ReadLine());
                return spotNr;
            }
            catch (FormatException)
            {
                Console.WriteLine("You may only use numbers!");
                Console.ReadKey();
                Console.Clear();
                AskForSpotNr();
                return -1;
            }
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
            ReturnToMenuChoice("Enter RegNr");
            Console.Write("Enter RegNr: ");
            string regNr = Console.ReadLine().ToUpper();
            bool checkRegex = ValidateRegNrInput(regNr);
            if (!checkRegex)
            {
                Console.WriteLine("Unvalid RegNr, try removing spaces and special char's");
                Console.ReadKey();
                Console.Clear();
                AskForRegNr();
                return regNr;
            }
            else
                return regNr;
        }
        public static bool AddVehicle()
        {
            AnsiConsole.Write(HeadLine("Add Vehicle", Color.Blue));
            string vehicleType = AskForVehicleType();
            string regNr = AskForRegNr();
            bool checkReg = ParkingHouse.IsRegNrUsed(regNr);
            if (checkReg)
            {
                Console.WriteLine("There is already a vehicle parked with that RegNr");
                Console.ReadKey();
                Console.Clear();
                AddVehicle();
                return false;
            }
            if (vehicleType == "Car")
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
            Console.WriteLine();
            string regNr = AskForRegNr();
            bool checkReg = ParkingHouse.IsRegNrUsed(regNr);
            if (checkReg)
            {
                int newSpot = AskForSpotNr();
                ParkingHouse.MoveVehicle(regNr, newSpot - 1);
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.Clear();
                AnsiConsole.Write(HeadLine("Move Vehicle", Color.Yellow));
                Console.WriteLine("There is no Vehicle with that RegNr here!");
                Console.ReadKey();
                Console.Clear();
                MoveVehicle();
                return false;
            }
        }
        public static bool RemoveVehicle()
        {
            AnsiConsole.Write(HeadLine("Remove vehicle", Color.Orange4_1));
            ReturnToMenuChoice("Remove vehicle");
            string regNr = AskForRegNr();
            bool checkReg = ParkingHouse.IsRegNrUsed(regNr);
            if (!checkReg)
            {
                Console.WriteLine("There is no vehicle with that RegNr at this ParkingLot");
                Console.ReadKey();
                RemoveVehicle();
                return false;
            }
            ParkingHouse.CalculatePrice(regNr);
            ParkingHouse.RemoveVehicle(regNr);

            return true;
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
        public static Rule HeadLine(string header, Color color)
        {
            var rule = new Rule($"[{color}]{header}[/]");
            return rule;
        }
        public static void ReturnToMenuChoice(string input)
        {
            var inputChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(input, "Back to menu"));
            if (inputChoice == "Back to menu")
            {
                Menu();
            }
        }
        public static bool ValidateRegNrInput(string regNr)
        {
            string specialChar = @"^[^\s!.,;:#¤%&/\()=?`´@'£$$€{}[\]]{3,10}$";
            Regex reg = new(specialChar);
            bool regCheck = reg.IsMatch(regNr);

            return regCheck;
        }
        public static void OverViewStarter()
        {
            AnsiConsole.Write(HeadLine("Overview", Color.Orange4_1));
            ParkingHouse.Overview();
            ReturnToMenuChoice("Show ParkingSpot");
            int spotNr = AskForSpotNr();
            ParkingHouse.ShowParkingSpot(spotNr);
            Console.ReadKey();
            Console.Clear();
            OverViewStarter();
        }
    }
}
