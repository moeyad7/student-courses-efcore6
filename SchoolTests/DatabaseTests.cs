using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolData;
using SchoolDomain;
using System.Diagnostics;

namespace PubAppTest
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertStudentIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<SchoolContext>();
            builder.UseNpgsql(
        "User ID =postgres;Password=mhmh2621ea;Server=myserver,localhost;Port=5432;Database=SchoolTestData;Pooling=true;Timeout=15;SSL Mode=Disable;");


            using (var context = new SchoolContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var student = new Student { Name = "a", GPA = 3.5};

                context.Students.Add(student);
                context.SaveChanges();

                Assert.AreNotEqual(0, student.StudentId);

            }
        }
    }
}