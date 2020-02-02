using System;
using System.IO;

namespace StudentSystem
{
    class SystemStarter
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                string path = args[0];
                if (File.Exists(path))
                {
                    using (StreamReader streamReader = File.OpenText(path))
                    {
                        string line;
                        StudentManager studentManager = new StudentManager();
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            Student newStudent = studentManager.CreateStudentFromLine(line);
                            studentManager.AddStudent(newStudent);
                        }
                        string firstFilter = args[1];
                        if (firstFilter.Contains("name"))
                        {
                            Console.WriteLine(studentManager.GetListOfStudents(firstFilter.Replace("name=", "")));
                        }
                        else if (firstFilter.Contains("type"))
                        {
                            if (args.Length < 4)
                            {
                                firstFilter = firstFilter.Replace("type=", "");
                                StudentType seekedType = (StudentType)Enum.Parse(typeof(StudentType),
                                    firstFilter, true);
                                if (args.Length == 3)
                                {
                                    string secondFilter = args[2];
                                    if (secondFilter.Contains("gender"))
                                    {
                                        secondFilter = secondFilter.Replace("gender=", "");
                                        PersonGender seekedGender = (PersonGender)Enum.Parse(typeof(PersonGender),
                                        secondFilter, true);
                                        Console.WriteLine(studentManager.GetListOfStudents(seekedType, seekedGender));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid arguments.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(studentManager.GetListOfStudents(seekedType));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Number of arguments exceeded.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter some valid input.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter some valid file path.");
                }
            }
            else
            {
                Console.WriteLine("Please enter some valid input.");
            }
        }
    }
}

