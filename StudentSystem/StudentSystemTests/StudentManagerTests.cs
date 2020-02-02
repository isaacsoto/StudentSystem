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
    public class StudentManagerTests
    {
        StudentManager Manager;
        Student Student;
        string DateFomat = "yyyyMMddHHmmss";
        [TestMethod()]
        public void AddStudentTest()
        {
            Manager = new StudentManager();
            Student = new Student(StudentType.High, "Luke", PersonGender.Male,
                DateTime.ParseExact("20130129080903", DateFomat,
                System.Globalization.CultureInfo.InvariantCulture));
            Assert.IsTrue(Manager.AddStudent(Student));
            Assert.IsTrue(Manager.ContainsStudent(Student));
        }

        [TestMethod()]
        public void CreateStudentFromLineTest()
        {
            Manager = new StudentManager();
            Student = Manager.CreateStudentFromLine("High,Luke,M,20130129080903");
            Student newStudent = new Student(StudentType.High, "Luke", PersonGender.Male,
                DateTime.ParseExact("20130129080903", DateFomat,
                System.Globalization.CultureInfo.InvariantCulture));   
            Assert.AreEqual(newStudent, Student);
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {

            Manager = new StudentManager();
            Student = new Student(StudentType.High, "Luke", PersonGender.Male,
                DateTime.ParseExact("20130129080903", DateFomat,
                System.Globalization.CultureInfo.InvariantCulture));
            Assert.IsTrue(Manager.AddStudent(Student));
            Assert.IsTrue(Manager.ContainsStudent(Student));
            Assert.IsTrue(Manager.DeleteStudent(Student));
            Assert.IsFalse(Manager.ContainsStudent(Student));
        }

        [TestMethod()]
        public void ContainsStudentTest()
        {
            Manager = new StudentManager();
            Student = new Student(StudentType.High, "Luke", PersonGender.Male,
                DateTime.ParseExact("20130129080903", DateFomat,
                System.Globalization.CultureInfo.InvariantCulture));
            Assert.IsTrue(Manager.AddStudent(Student));
            Assert.IsTrue(Manager.ContainsStudent(Student));
        }
    }
}