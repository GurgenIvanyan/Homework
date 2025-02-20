using System;

public class WorkoutSession
{
    public string ExeciseType;
    public int Duration;

    public WorkoutSession(string execiseType, int duration)
    {
        ExeciseType = execiseType;
        Duration = duration; 
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Execise Type: {ExeciseType} , Duration: {Duration}");
    }
}

class Program
{
    public static void Main()
    {
        WorkoutSession workoutsession1 = new WorkoutSession("running", 45);
        WorkoutSession workoutsession2 = new WorkoutSession("cycling", 35);
        WorkoutSession workoutsession3 = new WorkoutSession("yoga", 50);
        workoutsession1.ShowInfo();
        workoutsession2.ShowInfo();
        workoutsession3.ShowInfo();
    }
}