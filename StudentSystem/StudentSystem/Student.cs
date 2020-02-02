using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    class Student
    {
        private StudentType Type;
        private String Name;
        private PersonGender Gender; 
        private DateTime TimeStamp;

        public Student(StudentType Type, String Name, PersonGender Gender, DateTime TimeStamp) {
            this.Type = Type;
            this.Name = Name;
            this.Gender = Gender;
            this.TimeStamp = TimeStamp;
        }
    }
}
