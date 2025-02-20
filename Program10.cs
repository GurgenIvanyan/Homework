using System;

public class Course
{
    public string CourseName;
    public string InstructorName;
    public int MaxStudents;

    public Course(string courseName, string instructorName, int maxStudents)
    {
        CourseName = courseName;
        InstructorName = instructorName;
        MaxStudents = maxStudents;
    }

    public void ShowCourseDetails()
    {
        Console.WriteLine($"Course Name: {CourseName}  InstructorName: {InstructorName}  Max Students: {MaxStudents}");
    }
}

class Program
{
    public static void Main()
    {
        Course course1 = new Course("C#", "Hayk", 25);
        Course course2 = new Course("C++", "Arthur", 20);
        course1.ShowCourseDetails();
        course2.ShowCourseDetails();
        
    }
}