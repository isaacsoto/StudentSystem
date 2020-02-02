using System;
using System.Collections.Generic;

namespace StudentSystem
{
    class TimeStampComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            int result = (-1)*(x.GetTimeStamp().CompareTo(y.GetTimeStamp()));
            if (result == 0) {
                result = x.CompareTo(y);
            }
            return result;
        }
    }

    class Student : IComparable
    {
        private StudentType Type;
        private String Name;
        private PersonGender Gender; 
        private DateTime TimeStamp;

        public Student(StudentType Type, String Name, PersonGender Gender, DateTime TimeStamp)
        {
            this.Type = Type;
            this.Name = Name;
            this.Gender = Gender;
            this.TimeStamp = TimeStamp;
        }

        override public string ToString()
        {
            string result = String.Join(
                    Environment.NewLine,
                    "Type of Student: " + this.Type.ToString("G"),
                    "Name: " + this.Name,
                    "Gender: " + this.Gender.ToString("G"),
                    "Last Modification: " + this.TimeStamp.ToString());
            return result;
        }

        public int CompareTo(Object Obj) 
        {
            int result;
            if (Obj == null) {
                throw new ArgumentException("Object is not a Valid");
            }
            if (Obj is Student) {
                Student otherStudent = Obj as Student;
                result = this.Name.CompareTo(otherStudent.Name);
                if (result == 0) {
                    result = this.Type.CompareTo(otherStudent.Type);
                    if (result == 0) {
                        result = this.Gender.CompareTo(otherStudent.Gender);
                    }
                }
            } else {
                throw new ArgumentException("Object is not a Student");
            }
            return result;
        }

        public StudentType GetStudentType() 
        {
            return Type;
        }

        public string GetName()
        {
            return Name;
        }
        public PersonGender GetGender()
        {
            return Gender;
        }

        public DateTime GetTimeStamp()
        {
            return TimeStamp;
        }
    }
}
