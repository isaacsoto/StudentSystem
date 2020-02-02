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
        public Student CreateStudentFromLine(string Line)
        {
            string[] parameters = Line.Split(LineFormatSeparators);
            return ProcessStudentLine(parameters);

        }

        private Student ProcessStudentLine(string[] parameters)
        {
            string name = parameters[1];
            DateTime timeStamp = DateTime.ParseExact(parameters[3], DateFomat,
                                System.Globalization.CultureInfo.InvariantCulture);

            return null;
        }

        private Student CreateStudent(StudentType Type, string Name, PersonGender StudentGender, DateTime TimeStamp)
        {
            Student newStudent = new Student(Type, Name, StudentGender, TimeStamp);
            return newStudent;
        }
    }
}
