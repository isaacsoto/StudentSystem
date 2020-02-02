using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    class StudentManager
    {
        private char[] LineFormatSeparators = { ',' };
        private string DateFomat = "yyyyMMddHHmmss";
        private SortedSet<Student> students;

        public StudentManager()
        {
            students = new SortedSet<Student>();
        }

        public bool AddStudent(Student student)
        {
            return students.Add(student);
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

        public string GetListOfStudents()
        {
            string listOfStudents = "";
            foreach (Student student in this.students) {
                listOfStudents = String.Join(
                    Environment.NewLine,
                    listOfStudents,
                    "",
                    student.ToString());
            }
            return listOfStudents;
        }
    }
}
