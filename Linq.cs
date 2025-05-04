using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp22;
public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int DepartmentId { get; set; }
    public List<int> EnrolledCourseIds { get; set; } = new();
    public int Age { get; set; }
}
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
    public int DepartmentId { get; set; }
}
class Subject{
    public string Name{get;set;}
    public int DepartmentId {get;set;}
}

class Program
{
    static void Main(string[] args)
    {
        var students = new List<Student>
        {
            new Student { Id = 1, FullName = "Anna Grigoryan", DepartmentId = 1, EnrolledCourseIds = new List<int> { 1 }, Age = 19 },
            new Student { Id = 2, FullName = "Karen Hakobyan", DepartmentId = 1, EnrolledCourseIds = new List<int> { 1 }, Age = 20 },
            new Student { Id = 3, FullName = "Lilit Hovhannisyan", DepartmentId = 1, EnrolledCourseIds = new List<int> {  }, Age = 18 },
            new Student { Id = 4, FullName = "Aram Sargsyan", DepartmentId = 1, EnrolledCourseIds = new List<int> { 3 }, Age = 22 },
            new Student { Id = 5, FullName = "Sona Melikyan", DepartmentId = 1, EnrolledCourseIds = new List<int> { 1 }, Age = 21 },
            new Student { Id = 6, FullName = "Narek Martirosyan", DepartmentId = 1, EnrolledCourseIds = new List<int> {  }, Age = 20 },
            new Student { Id = 7, FullName = "Mariam Vardanyan", DepartmentId = 2, EnrolledCourseIds = new List<int> {  }, Age = 19 }
        };
        var subjects = new List<Subject>
        {
            new Subject { Name = "C#", DepartmentId = 1 },
            new Subject { Name = "Java", DepartmentId = 1 },
        };


        var courses = new List<Course>
        {
            new Course { Id = 1, Title = "101", Credits = 2 },
            new Course { Id = 2, Title = "102", Credits = 3 },
            new Course { Id = 3, Title = "103", Credits = 4 },
        };
        var departments = new List<Department>()
        {
            new Department { Name = "ComputerScience", Id = 1 },
            new Department { Name = "SmartCode", Id = 2},
        };
        var ComputerScienceStudents = from student in students
            where student.DepartmentId ==
                  (from department in departments
                      where department.Name == "ComputerScience"
                      select department.Id).FirstOrDefault()
            select student;
        foreach (var student in ComputerScienceStudents)
        {
            Console.WriteLine($"{student.FullName}, {student.DepartmentId}");
        }

        var coursesWithoutStudents = from course in courses
            where !(from student in students
                from cId in student.EnrolledCourseIds
                select cId).Contains(course.Id)
                select course;
        foreach (var course in coursesWithoutStudents)
        {
            Console.WriteLine($"Course {course.Title}");
        }
        var ComputerScienceSubjects = from subject in subjects where
                subject.DepartmentId ==(from department in departments
                    where department.Name == "ComputerScience"
                        select department.Id).FirstOrDefault()
                                        select subject;
        foreach (var subject in ComputerScienceSubjects)
        {
            Console.WriteLine($"Subject: {subject.Name}");
        }

        var DpartmentwithMembersMoreThan5 = from department in departments
            let studentsCount = (from student in students
                where student.DepartmentId == department.Id
                select student).Count()
            where studentsCount > 5
                select new
            {
                DepartmentName = department.Name,
                StudentsCount = studentsCount
            };
        foreach (var student in DpartmentwithMembersMoreThan5)
        {
            Console.WriteLine($"{student.DepartmentName}, {student.StudentsCount}");
        }

        var YoungestStudentStudentId =
            (from student in students
            orderby student.Age descending
                select student.DepartmentId).FirstOrDefault();
        var DepartmentWithYoungestStudent = (from dept in departments
                                            where dept.Id == YoungestStudentStudentId
                                                select dept.Name).FirstOrDefault();
       
        Console.WriteLine(DepartmentWithYoungestStudent);
        var Department = from d in departments
            let CourseCount = (from c in courses
                where c.DepartmentId == d.Id
                select c).Count()
            orderby CourseCount descending
            select new { d.Name, CourseCount = CourseCount };

        var departmentWithMostCourses = Department.FirstOrDefault();
        Console.WriteLine(departmentWithMostCourses);
                

    }
}