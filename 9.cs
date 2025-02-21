namespace Task9_21;

class Program
{
    public static void ConvertTo(ref int totalseconds,out int sec, ref int minutes, out int hours)
    {
        hours = totalseconds / 3600;
        minutes = (totalseconds % 3600) / 60;
        sec= totalseconds % 60;

    }
    static void Main(string[] args)
    {
        int totalseconds = int.Parse(Console.ReadLine());
        int minutes = 0;
        int hours;
        int sec = 0;
            ConvertTo(ref totalseconds,out sec,ref minutes,out hours);
            Console.WriteLine($"HOURS: {hours}");
            Console.WriteLine($"MINUTES: {minutes}");
            Console.WriteLine($"SECONDS: {sec}");
    }
}