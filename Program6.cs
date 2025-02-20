using System;

public class Movie
{
    private int _rating;

    public int Rating
    {
        get { return _rating; }
        set
        {
            if (value >= 1 && value <= 5)
            {
                _rating = value;
            }
            else
            {
                Console.WriteLine("Invalid rating");
            }
        }
    }

    public Movie(int rating)
    {
        Rating = rating;
    }

    public void ShowRating()
    {
        Console.WriteLine($"Rating: {Rating}");
    }
}

class Program
{
    public static void Main()
    {
        Movie movie1 = new Movie(1);
        movie1.ShowRating();
        Movie movie2 = new Movie(7);
        movie2.ShowRating();
    }
}