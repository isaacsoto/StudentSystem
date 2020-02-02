using System;

namespace StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            StudentManager studentManager = new StudentManager();
            while ((line = Console.ReadLine()) != null)
            {
                Student newStudent = studentManager.CreateStudentFromLine(line);
                studentManager.AddStudent(newStudent);
            }
            Console.WriteLine(studentManager.GetListOfStudents("Luke"));
        }
    }
}
