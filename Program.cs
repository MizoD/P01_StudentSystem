using P01_StudentSystem.Data;
using P01_StudentSystem.Models;
using System;

namespace P01_StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
{
    using var context = new StudentSystemContext();

    Console.WriteLine("Enter student name:");
    string studentName = Console.ReadLine();

    Console.WriteLine("Enter phone number (optional):");
    string phone = Console.ReadLine();

    var student = new Student
    {
        Name = studentName,
        PhoneNumber = string.IsNullOrWhiteSpace(phone) ? null : phone,
        RegisteredOn = DateTime.Now
    };

    context.Students.Add(student);
    context.SaveChanges();

    Console.WriteLine("Enter course name:");
    string courseName = Console.ReadLine();

    var course = context.Courses.FirstOrDefault(c => c.Name == courseName);
    if (course == null)
    {
        course = new Course { Name = courseName };
        context.Courses.Add(course);
        context.SaveChanges();
    }

    var studentCourse = new StudentCourse
    {
        StudentId = student.StudentId,
        CourseId = course.CourseId
    };

    context.StudentCourses.Add(studentCourse);
    context.SaveChanges();

    Console.WriteLine($"Student '{student.Name}' enrolled in course '{course.Name}' successfully.");
}
    }
}
