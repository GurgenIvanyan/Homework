using System;

public class FileDownload
{
    public FileDownload()
    {
        Console.WriteLine("Download started");
    }

    ~FileDownload()
    {
        Console.WriteLine("Download completed");
    }
}

public class Program
{
    static void StartDownload()
    {
        FileDownload download = new FileDownload();
    }

    public static void Main()
    {
        StartDownload();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    
        
    }
