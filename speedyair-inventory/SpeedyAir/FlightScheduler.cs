using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

// Class responsible for scheduling and managing flights and orders
public class FlightScheduler
{
    // List to store all the flights
    public List<Flight> Flights { get; set; } = new List<Flight>();

    // Method to load the predefined flight schedule
    public void LoadFlightSchedule()
    {
        // Adding flights for day 1
        Flights.Add(new Flight(1, "YUL", "YYZ", 1));  // Montreal to Toronto
        Flights.Add(new Flight(2, "YUL", "YYC", 1));  // Montreal to Calgary
        Flights.Add(new Flight(3, "YUL", "YVR", 1));  // Montreal to Vancouver
        
        // Adding flights for day 2
        Flights.Add(new Flight(4, "YUL", "YYZ", 2));  // Montreal to Toronto
        Flights.Add(new Flight(5, "YUL", "YYC", 2));  // Montreal to Calgary
        Flights.Add(new Flight(6, "YUL", "YVR", 2));  // Montreal to Vancouver
    }

    // Method to display the flight schedule on the console
    public void DisplayFlightSchedule()
    {
        Console.WriteLine("Flight Schedule:");
        foreach (var flight in Flights)
        {
            Console.WriteLine(flight);
        }
    }

    // Method to load orders from a JSON file
    public List<Order> LoadOrders(string filePath)
    {
        // Read the JSON file and deserialize it into a list of orders
        var orders = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(filePath));
        return orders;
    }

    // Method to generate flight itineraries based on the loaded orders
    public void GenerateItineraries(List<Order> orders)
    {
        List<Order> unscheduledOrders = new List<Order>(); // List to keep track of orders that couldn't be scheduled

        // Iterate through each order
        foreach (var order in orders)
        {
            bool scheduled = false;  // Flag to check if the order has been scheduled

            // Try to find a flight that can carry the order
            foreach (var flight in Flights)
            {
                // Check if the flight has enough capacity and matches the order's destination
                if (flight.Arrival == order.Destination && flight.Capacity > 0)
                {
                    // Schedule the order on the flight
                    Console.WriteLine($"order: {order.OrderId}, flightNumber: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
                    flight.Capacity--;  // Decrease the capacity of the flight
                    scheduled = true;   // Mark the order as scheduled
                    break;
                }
            }

            // If the order couldn't be scheduled, add it to the unscheduled list
            if (!scheduled)
            {
                unscheduledOrders.Add(order);
            }
        }

        // Display unscheduled orders
        foreach (var unscheduledOrder in unscheduledOrders)
        {
            Console.WriteLine($"order: {unscheduledOrder.OrderId}, flightNumber: not scheduled");
        }
    }
}
