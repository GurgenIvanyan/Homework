namespace Tasks74;

class Student
{
    private string[] subjects=new string[10];
    private int[] grades = new int[10];
    private int count = 0;

    public int this[string subject]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (subjects[i] == subject)
                {
                    return grades[i];
                }
            }

            return -1;
        }
        set
        {
            for (int i = 0; i < count; i++)
            {
                if (subjects[i] == subject)
                {
                    grades[i] = value;
                    return;
                }
            }

            if (count < subjects.Length)
            {
                subjects[count] = subject;
                grades[count] = value;
                count++;
            }
        }
        
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student students = new Student();
        students["Math"] = 90;
        students["Algebra"] = 92;
        students["History"] = 99;
        Console.WriteLine(students["Math"]);
        Console.WriteLine(students["Algebra"]);
        Console.WriteLine(students["English"]);
    }
}