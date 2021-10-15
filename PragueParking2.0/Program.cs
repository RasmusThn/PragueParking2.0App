using System;
using System.Collections.Generic;
using System.Threading;
using Spectre.Console;

namespace PragueParking2._0
{
    class Program
    {
        List<string> ParkingList = new List<string>(100);
        static void Main(string[] args)
        {
            StartUpMenu();        
            Menu();
            

        }

        public static void Menu()
        {
            var menu = "";
            do
            {
                menu = AnsiConsole.Prompt(
                 new SelectionPrompt<string>()
                 .AddChoices(new[] {"Add vehicle","Move vehicle", "Remove vehicle","Overview","Exit Program"
                 }));

                switch (menu)
                {
                    case "Add vehicle": { 
                            VehicleType input = VehicleTypeChecker();
                            Console.Write("Enter RegNr: ");
                            string regInput = Console.ReadLine();
                            Vehicle Car1 = new Vehicle(regInput, (int)input);

                        } break;
                    case "Move vehicle": ParkedVehicleBar(); break;
                    case "Remove vehicle": Console.WriteLine("Remove funkar"); break;
                    case "Overview": Overview(); break;
                    case "Exit Program": Console.WriteLine("Exit funkar"); break;
                    default:
                        break;
                }
            }
            while (menu != "Exit Program");

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
            // Create a table
            var table = new Table();

            // Add some columns
            table.AddColumn("Foo");
            table.AddColumn(new TableColumn("Bar").Centered());

            // Add some rows
            table.AddRow("Baz", "[green]Qux[/]");
            table.AddRow(new Markup("[blue]Corgi[/]"), new Panel("Waldo"));

            // Render the table to the console
            AnsiConsole.Write(table);
        }

        public static VehicleType VehicleTypeChecker()
        {
            var inputChoice = AnsiConsole.Prompt(
                new SelectionPrompt<VehicleType>()
                .AddChoices(VehicleType.Car, VehicleType.Mc));           
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
    }
}

