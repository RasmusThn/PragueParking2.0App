using System;
using System.Collections.Generic;
using System.Threading;
using Spectre.Console;

namespace PragueParking2._0
{
    class Program
    {
        public static List<string> ParkingList = new List<string>(100);
        static void Main(string[] args)
        {
            foreach (var parkSpot in ParkingList)                     // ????
            {
                parkSpot.Insert(0," ");
            }
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
                 }));

                switch (menu)
                {
                    case "[green]Add vehicle[/]":
                        {
                            AnsiConsole.Write(HeadLine("Add Vehicle", Color.Blue));                           
                            VehicleType input = VehicleTypeChecker();
                            Console.Write("Enter RegNr: ");
                            string regInput = Console.ReadLine();
                            Vehicle Car1 = new Vehicle(regInput, (int)input);
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
        public static Rule HeadLine(string header, Color color)
        {
            var rule = new Rule($"[{color}]{header}[/]");
            return rule;

        }
    }
}

