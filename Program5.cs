using System;

public class SmartWatch
{
    public string OwnerName;
    public int StepCount;

    public SmartWatch(string ownerName, int stepCount)
    {
        OwnerName = ownerName;
        StepCount = stepCount;
    }

    public int AddStep(int step)
    {
        return StepCount += step;
    }

    public void ShowStep()
    {
        Console.WriteLine($"total steps are: {StepCount}");
    }
}

class Program
{
    public static void Main()
    {
        SmartWatch smartwatch = new SmartWatch("John Doe",456);
        int step = 240;
        smartwatch.AddStep(step);
        smartwatch.ShowStep();
    }
}