using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class TicketBookingSystem
{
    private static List<int> tickets = Enumerable.Range(1, 100).ToList();
    private static object lockObject = new object();
    private static SemaphoreSlim semaphore = new SemaphoreSlim(4); 

    static void Main()
    {
        Console.WriteLine("Ticket booked please wait...\n");

       
        List<Thread> threads = new List<Thread>();
        for (int i = 1; i <= 10; i++)
        {
            int userId = i;
            Thread thread = new Thread(() => BookTickets(userId));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("\n all tickets are booked.\n։");
    }

    private static void BookTickets(int userId)
    {
      
        semaphore.Wait();
        try
        {
            while (true)
            {
                int ticketNumber = -1;

                
                lock (lockObject)
                {
                    if (tickets.Count > 0)
                    {
                        ticketNumber = tickets[0];
                        tickets.RemoveAt(0);
                    }
                    else
                    {
                        break; 
                    }
                }

                if (ticketNumber != -1)
                {
                    Console.WriteLine($"user {userId} booked{ticketNumber}։");
                    Thread.Sleep(50); 
               }
            }
        }
        finally
        {
            semaphore.Release();
        }
    }
}