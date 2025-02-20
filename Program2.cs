using System;

public class FlightTicket
{
    public string PassengerName;
    public int FlightNumber;
    public int SeatNumber;

    public FlightTicket(string passengerName, int flightNumber, int seatNumber)
    {
        PassengerName = passengerName;
        FlightNumber = flightNumber;
        SeatNumber = seatNumber;
    }

    public void PrintTicket()
    {
        Console.WriteLine($"Passenger: {PassengerName}, Flight: {FlightNumber}, Seat: {SeatNumber}" );
    }
}

public class Program
{
    public static void Main()
    {
        FlightTicket ticket1 = new FlightTicket("Ivan ", 10, 15);
       FlightTicket ticket2 = new FlightTicket("Garik", 12, 20);
       FlightTicket ticket3 = new FlightTicket("Hayk", 10, 14);
       ticket1.PrintTicket();
       ticket2.PrintTicket();
       ticket3.PrintTicket();
    }
}