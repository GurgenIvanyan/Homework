using System;
using System.Collections.Generic;
namespace StudentOverload
{
    class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Student student && student.Id == Id)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;  
        }
    }

    class Group
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public static bool operator true(Group group)
        {
            return group.Students.Count > 0;
        }

        public static bool operator false(Group group)
        {
            return group.Students.Count == 0;
        }

       
        public static Group operator +(Group group1, Group group2)
        { 
            var newGroup = new Group();
            newGroup.Students = group1.Students.Concat(group2.Students).Distinct().ToList();
            return newGroup;
        }

        public bool Contains(Student student)
        {
            return Students.Contains(student);
        }

        public static Group operator -(Group group1, Group group2)
        {
            var newGroup = new Group();
            foreach (var student in group1.Students) 
            {
                if (!group2.Students.Contains(student))
                {
                    newGroup.Students.Add(student);
                }
            }
            return newGroup;
        }

        public void PrintStudents()
        {
            foreach (var student in Students)
            {
                Console.WriteLine(student.Name);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group();
            Group group2 = new Group();
            group1.Students.AddRange(new[]
            {
                new Student("John", 1),
                new Student("Jane", 2),
                new Student("Jack", 3),
            });
            group2.Students.AddRange(new[]
            {
                new Student("John", 1),
                new Student("Ani", 5),
                new Student("Anna", 6),
            });
            
            var group3 = group1 + group2; 
            Console.WriteLine("Members of group3");
            group3.PrintStudents();  
            var group4 = group1 - group2;
            Console.WriteLine("Members of group4");
            group4.PrintStudents();
        }
    }
}
