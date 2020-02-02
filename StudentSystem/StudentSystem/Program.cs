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
                string result = studentManager.CreateStudentFromLine(line).ToString();
                Console.WriteLine(result);
            }
        }
    }
}
