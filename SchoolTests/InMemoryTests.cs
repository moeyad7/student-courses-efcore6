using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SchoolData;
using SchoolDomain;
// using SchoolConsole;

namespace SchoolTests
{
    [TestClass]
    public class InMemoryTests
    {
        [TestMethod]
        public void CanInsertStudentIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<SchoolContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            using (var context = new SchoolContext(builder.Options))
            {
                var student = new Student { Name = "a", GPA = 3.5 };

                context.Students.Add(student);
                context.SaveChanges();

                Assert.AreNotEqual(0, student.StudentId);
            }
        }

        [TestMethod]
        public void CanDeleteStudentFromDatabase(){
            var builder = new DbContextOptionsBuilder<SchoolContext>();

            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            using (var context = new SchoolContext(builder.Options))
            {
                var student = new Student { StudentId=7,Name = "a", GPA = 3.5 };

                context.Students.Add(student);
                context.SaveChanges();

                context.Students.Remove(student);
                context.SaveChanges();

                var deletedStudent = context.Students.Find(student.StudentId);
                Assert.IsNull(deletedStudent);

            }
        }
        [TestMethod]
        public void CanUpdateStudentFromDatabase(){
            var builder = new DbContextOptionsBuilder<SchoolContext>();

            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            using (var context = new SchoolContext(builder.Options))
            {
                var student = new Student { StudentId=7,Name = "a", GPA = 3.5 };

                context.Students.Add(student);
                context.SaveChanges();

                student.Name = "b";
                context.Students.Update(student);
                context.SaveChanges();

                var updatedStudent = context.Students.Find(student.StudentId);
                Assert.AreEqual("b", updatedStudent.Name);

            }
        }

    }
}