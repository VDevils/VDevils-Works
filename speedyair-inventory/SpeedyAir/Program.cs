using System;
using System.Collections.Generic;

// Main entry point of the application
class Program
{
    static void Main(string[] args)
    {
        // Create an instance of FlightScheduler
        var scheduler = new FlightScheduler();

        // Load the predefined flight schedule
        scheduler.LoadFlightSchedule();

        // Display the flight schedule on the console
        scheduler.DisplayFlightSchedule();

        // Load orders from the JSON file
        var orders = scheduler.LoadOrders("orders.json");

        // Generate and display flight itineraries based on the orders
        Console.WriteLine("\nFlight Itineraries:");
        scheduler.GenerateItineraries(orders);
    }
}

