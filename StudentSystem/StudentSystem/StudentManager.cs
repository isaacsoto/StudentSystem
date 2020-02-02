using System;
using System.Collections.Generic;

namespace StudentSystem
{
    public class StudentManager
    {
        private char[] LineFormatSeparators = { ',' };
        private string DateFomat = "yyyyMMddHHmmss";
        private SortedSet<Student> Students;
        private SortedDictionary<StudentType, SortedSet<Student>> StudentsByType;

        public StudentManager()
        {
            Students = new SortedSet<Student>();
            StudentsByType = new SortedDictionary<StudentType, SortedSet<Student>>();
            InitializeCollectionsValues();
        }

        private void InitializeCollectionsValues() 
        {
            SortedSet<Student> newSet;
            foreach (StudentType type in Enum.GetValues(typeof(StudentType))) {
                newSet = new SortedSet<Student>(new TimeStampComparer());
                StudentsByType.Add(type, newSet);
            }
        }

        public bool AddStudent(Student student)
        {
            return Students.Add(student) && StudentsByType[student.GetStudentType()].Add(student);
        }
        public Student CreateStudentFromLine(string Line)
        {
            string[] parameters = Line.Split(LineFormatSeparators);
            return ProcessStudentLine(parameters);
        }

        private Student ProcessStudentLine(string[] parameters)
        {
            StudentType type = (StudentType) Enum.Parse(typeof(StudentType), parameters[0]);
            string name = parameters[1];
            PersonGender studentGender = (PersonGender) Enum.Parse(typeof(PersonGender), 
                processStudentGender(parameters[2]));
            DateTime timeStamp = DateTime.ParseExact(parameters[3], DateFomat,
                                System.Globalization.CultureInfo.InvariantCulture);
            return CreateStudent(type, name, studentGender, timeStamp);
        }

        private Student CreateStudent(StudentType Type, string Name, PersonGender StudentGender, DateTime TimeStamp)
        {
            Student newStudent = new Student(Type, Name, StudentGender, TimeStamp);
            return newStudent;
        }

        private string processStudentGender(string ParameterGender) 
        {
            String gender = "other";
            if (ParameterGender.Equals("M", StringComparison.InvariantCultureIgnoreCase))
            {
                gender = "Male";
            }
            else if (ParameterGender.Equals("F", StringComparison.InvariantCultureIgnoreCase)) {
                gender = "Female";
            }
            return gender;
        }

        public bool DeleteStudent(Student Student) 
        {
            return Students.Remove(Student) &&
                StudentsByType[Student.GetStudentType()].Remove(Student);
        }

        public bool ContainsStudent(Student Student)
        {
            return Students.Contains(Student) &&
                StudentsByType[Student.GetStudentType()].Contains(Student);
        }

        public string GetListOfStudents()
        {
            string listOfStudents = "";
            foreach (Student student in this.Students) {
                listOfStudents = String.Join(
                    Environment.NewLine,
                    listOfStudents,
                    "",
                    student.ToString());
            }
            if (listOfStudents.Length == 0)
            {
                listOfStudents = "No student data";
            }
            return listOfStudents;
        }

        public string GetListOfStudents(StudentType Type)
        {
            string listOfStudents = "";
            foreach (Student student in this.StudentsByType[Type])
            {
                listOfStudents = String.Join(
                    Environment.NewLine,
                    listOfStudents,
                    "",
                    student.ToString());
            }
            if (listOfStudents.Length == 0)
            {
                listOfStudents = "No results found";
            }
            return listOfStudents;
        }

        public string GetListOfStudents(StudentType Type, PersonGender Gender)
        {
            string listOfStudents = "";
            foreach (Student student in this.StudentsByType[Type])
            {
                if (student.GetGender() == Gender) {
                    listOfStudents = String.Join(
                    Environment.NewLine,
                    listOfStudents,
                    "",
                    student.ToString());
                }
            }
            if (listOfStudents.Length == 0) {
                listOfStudents = "No results found";
            }
            return listOfStudents;
        }

        public string GetListOfStudents(String Name)
        {
            string listOfStudents = "";
            string nameToSeek = Name.ToLower();
            foreach (Student student in this.Students)
            {
                string studentName = student.GetName().ToLower();
                if (studentName.Contains(nameToSeek))
                {
                    listOfStudents = String.Join(
                    Environment.NewLine,
                    listOfStudents,
                    "",
                    student.ToString());
                }
            }
            if (listOfStudents.Length == 0)
            {
                listOfStudents = "No results found";
            }
            return listOfStudents;
        }
    }
}
