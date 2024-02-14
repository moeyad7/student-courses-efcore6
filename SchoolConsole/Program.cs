using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolDomain;

SchoolContext _context = new SchoolContext();


void AverageAgeOfStudents(){
    var avgAge = _context.Students.Average(s => s.Age);

    Console.WriteLine(avgAge);
}

void CoursesWithNoStudents()
{
    var courses = _context.Courses.Include(c => c.Enrollments).ToList();

    foreach (var course in courses)
    {
        if (course.Enrollments.Count == 0)
        {
            Console.WriteLine($"Course {course.Title} has no students");
        }
    }
}

void StudentHighestGradeInCourse(string courseTitle)
{
    var course = _context.Courses
        .Where(c => c.Title.Equals(courseTitle))
        .Include(c => c.Enrollments)
        .ThenInclude(e => e.Student)
        .FirstOrDefault();

    var maxGPA = 0.0;

    foreach (var e in course.Enrollments)
    {
        if (e.Student.GPA > maxGPA)
        {
            maxGPA = e.Student.GPA;
        }
    }

    Console.WriteLine(maxGPA);
}

void CountOfStudentForEachCourse()
{

    var e = _context.Courses.Include(c => c.Enrollments).ToList();

    foreach (var course in e)
    {
        Console.WriteLine($"Course: {course.Title}, Number of Students: {course.Enrollments.Count}");
    }
}

void StudentsOlderThan18()
{
    var students = _context.Students.Where(s => s.Age > 1).ToList();

    foreach (var student in students)
    {
        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
    }
}

void RetrieveAllCoursesForAStudent(int studentId)
{
    var enrollments = _context.Enrollments
            .Where(e => e.StudentId == studentId)
            .Select(e => new
            {
                CourseTitle = e.Course.Title,
                StudentName = e.Student.Name
            })
            .ToList();

    if (enrollments.Any())
    {
        var studentName = enrollments.First().StudentName;
        Console.WriteLine($"Courses enrolled by {studentName} (Student ID: {studentId}):");
        foreach (var enrollment in enrollments)
        {
            Console.WriteLine($"- {enrollment.CourseTitle}");
        }
    }
    else
    {
        Console.WriteLine($"Student with ID {studentId} is not enrolled in any courses.");
    }

}

void RetrieveAllStudentsInCourse(int courseId)
{
    var enrollments = _context.Enrollments
    .Where(e => e.CourseId == courseId)
    .Select(e => new { e.Course.Title, e.Student.Name })
    .ToList();

    if (enrollments.Any())
    {
        var courseName = enrollments.First().Title;
        Console.WriteLine($"Students enrolled in {courseName} (Course ID: {courseId}):");
        foreach (var enrollment in enrollments)
        {
            Console.WriteLine($"- {enrollment.Name}");
        }
    }
    else
    {
        Console.WriteLine($"Course with ID {courseId} doesn't have any students.");
    }

}

void AddEnrollment()
{
    Enrollment e = new Enrollment { EnrollmentId = 6, CourseId = 4, StudentId = 5, EnrollmentDate = DateTime.UtcNow };

    _context.Enrollments.Add(e);

    _context.SaveChanges();

}

void AddCourse()
{
    Course c = new Course { CourseId = 5, Title = "Biology" };

    _context.Courses.Add(c);

    _context.SaveChanges();

}

void AddStudent()
{
    Student s = new Student { StudentId = 5, Name = "Mohamed Eyad", Age = 21, GPA = 1.4 };

    _context.Students.Add(s);

    _context.SaveChanges();

}