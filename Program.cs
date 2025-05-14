namespace ConsoleApp26;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
     
        var students = new List<(int Id, string Name)>
        {
            (1, "Alice"),
            (2, "Bob"),
            (3, "Charlie")
        };

        var submissions = new List<(int StudentId, string AssignmentName)>
        {
            (1, "Math HW1"),
            (1, "Math HW2"),
            (2, "Science HW1")
        };

        var result = from student in students
            join submission in submissions on student.Id equals submission.StudentId into studentSubmissions
            select new
            {
                Name = student.Name,
                SubmissionCount = studentSubmissions.Count()
            } into studentWithCount
            orderby studentWithCount.SubmissionCount descending
            select studentWithCount;
        foreach (var student in result)
        {
            Console.WriteLine($"{student.Name}: {student.SubmissionCount} submissions");
        }
    }
}
