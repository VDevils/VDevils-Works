using System;

// Class representing a flight
public class Flight
{
    public int FlightNumber { get; set; }    // Flight number identifier
    public string Departure { get; set; }    // Departure city
    public string Arrival { get; set; }      // Arrival city
    public int Day { get; set; }             // Day of the flight
    public int Capacity { get; set; } = 20;  // Each plane has a capacity of 20 boxes

    // Constructor to initialize a flight with given details
    public Flight(int flightNumber, string departure, string arrival, int day)
    {
        FlightNumber = flightNumber;
        Departure = departure;
        Arrival = arrival;
        Day = day;
    }

    // Override the ToString method to display flight details in a readable format
    public override string ToString()
    {
        return $"Flight: {FlightNumber}, departure: {Departure}, arrival: {Arrival}, day: {Day}";
    }
}
