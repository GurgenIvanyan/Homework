using System;
using System.Collections.Generic;
namespace Filter;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
public static class ListExtensions
{
    public static List<T> Filter<T>(this List<T> list, Func<T, bool> predicate)
    {
        List<T> result = new List<T>();
        foreach (var item in list)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student("John", 25),
            new Student("Jane", 18),
            new Student("Julie", 19),
            new Student("Bob", 20)
        };
        

        var FilteredStudents = students.Filter(x => x.Age <= 20);
        foreach (var student in FilteredStudents)
        {
            Console.WriteLine($"{student.Name}, {student.Age}");
        }
    }
}

