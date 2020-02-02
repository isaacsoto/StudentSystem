using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Tests
{
    [TestClass()]
    public class StudentTests
    {
        string DateFomat = "yyyyMMddHHmmss";
        Student Student;
        [TestMethod()]
        public void ToStringTest()
        {
            Student = new Student(StudentType.High, "Luke", PersonGender.Male,
                DateTime.ParseExact("20130129080903", DateFomat,
                System.Globalization.CultureInfo.InvariantCulture));
            string expected = String.Join(
                    Environment.NewLine,
                    "Type of Student: High",
                    "Name: Luke",
                    "Gender: Male",
                    "Last Modification: " + Student.GetTimeStamp().ToString());
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Student = new Student(StudentType.High, "Luke", PersonGender.Male,
                DateTime.ParseExact("20130129080903", DateFomat,
                System.Globalization.CultureInfo.InvariantCulture));
            Student newStudent = new Student(StudentType.High, "Anakin", PersonGender.Male,
                DateTime.ParseExact("20130129080903", DateFomat,
                System.Globalization.CultureInfo.InvariantCulture));
            int firstResult = Student.CompareTo(newStudent);
            int secondResult = newStudent.CompareTo(Student);
            bool firstComparison = firstResult < 0;
            bool secondComparison = secondResult < 0;
            Assert.IsFalse(firstComparison);
            Assert.IsTrue(secondComparison);
        }
    }
}