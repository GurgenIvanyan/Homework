namespace Tasks73;

class TimePeriod
{
    public int TotalSeconds { get; set; }

    public string FormattedTime
    {
        get
        {
            double hours = TotalSeconds / 3600;
            double minutes = (TotalSeconds % 3600)/60;
            double seconds = TotalSeconds % 60;
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
        set
        {
            if (TotalSeconds < 0)
            {
                throw new Exception("the total seconds cannot be negative");
            }
        }
    }
    

    
    public TimePeriod(int totalSeconds)
    {
        TotalSeconds = totalSeconds;
    }

    public override string ToString()
    {
        return FormattedTime;
    }
}

class Program
{
    static void Main(string[] args)
    {
        TimePeriod timePeriod = new TimePeriod(7460);
        Console.WriteLine(timePeriod.ToString());
    }
}