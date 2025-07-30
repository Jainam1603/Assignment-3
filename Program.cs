/*
 Assignment 3 - Vehicle Management System
Author: Yadav Jainam
Date: 2025-07-29
Description: This program implements a vehicle management system that allows users to add, display, remove, and list vehicles of different types (Car, Truck, Motorcycle, Bus). Each vehicle has properties like make, year, base price, tax, and VIN. The program uses inheritance to define specific behaviors for each vehicle type.
*/






using System;
using System.Collections.Generic;

public static class Program
{
    // Master list to hold all vehicle objects
    static List<Vehicle> vehicles = new List<Vehicle>();

    public static void Main()
    {
        // Main loop: Displays menu and handles input
        while (true)
        {
            Console.Clear();
            UI.Display("Main Menu");
            UI.Display("\n<A>dd \n<D>isplay \n<R>emove \n<L>ist \n<X> Exit");


            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.A: AddVehicle(); break;
                case ConsoleKey.D: DisplayByType(); break;
                case ConsoleKey.R: RemoveVehicle(); break;
                case ConsoleKey.L: ListAll(); break;
                case ConsoleKey.X:
                    if (UI.Prompt("Are you sure (Y/N)?").ToUpper() == "Y") return;
                    break;
                default: UI.Display("Invalid input."); break;
            }
            Console.ReadKey(); // Pause for user to see message
        }
    }

    // Adds a new vehicle based on user input
    static void AddVehicle()
    {
        UI.Display("Vehicle Types: Car, Truck, Motorcycle, Bus");
        string type = UI.Prompt("Enter type: ").ToLower();

        string make = UI.Prompt("Make: ");
        int year = UI.PromptInt("Year: ", 1900, DateTime.Now.Year);

        // Create the correct vehicle type
        switch (type)
        {
            case "car":
                vehicles.Add(new Car(make, year,
                    UI.PromptDecimal("Base Price (15000-120000): ", 15000, 120000),
                    UI.PromptDecimal("Tax % (8-13): ", 8, 13),
                    UI.PromptDecimal("Freight (1000-5000): ", 1000, 5000)));
                break;

            case "truck":
                vehicles.Add(new Truck(make, year,
                    UI.PromptDecimal("Base Price (75000-100000): ", 75000, 100000),
                    UI.PromptDecimal("Tax % (8-13): ", 8, 13),
                    UI.PromptInt("Cargo Capacity (50000-80000): ", 50000, 80000)));
                break;

            case "motorcycle":
                vehicles.Add(new Motorcycle(make, year,
                    UI.PromptDecimal("Base Price (25000-45000): ", 25000, 45000),
                    UI.PromptDecimal("Tax % (8-13): ", 8, 13),
                    UI.PromptBool("Has sidecar")));
                break;

            case "bus":
                vehicles.Add(new Bus(make, year,
                    UI.PromptDecimal("Base Price (90000-180000): ", 90000, 180000),
                    UI.PromptDecimal("Tax % (8-13): ", 8, 13),
                    UI.PromptInt("Passenger Capacity (15-60): ", 15, 60)));
                break;

            default:
                UI.Display("Invalid vehicle type.");
                break;
        }
    }

    // Display vehicles of a given type
    static void DisplayByType()
    {
        string type = UI.Prompt("Enter vehicle type: ");
        int i = 1;
        UI.Display("Make | VIN | Year | Price");
        foreach (var v in vehicles)
        {
            if (v.VehicleType.Equals(type, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{i++}: {v.Make} | {v.VIN} | {v.YearManufactured} | {v.SellingPrice:C}");
        }
        Console.WriteLine("\nEnd of data\n");
    }

    // Remove a vehicle by VIN
    static void RemoveVehicle()
    {
        string vin = UI.Prompt("Enter VIN: ");
        var v = vehicles.Find(x => x.VIN == vin);
        if (v != null)
        {
            vehicles.Remove(v);
            UI.Display("Removed.");
        }
        else UI.Display("VIN not found.");
    }

    // List all vehicles
    static void ListAll()
    {
        int i = 1;
        foreach (var v in vehicles)
        {
            Console.WriteLine($"{i++}: {v.VehicleType} | {v.Make} | {v.VIN} | {v.YearManufactured} | {v.SellingPrice:C}");
        }
        Console.WriteLine("\nEnd of data\n");
    }
}
