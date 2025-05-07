using P01_StudentSystem.Data;
using P01_StudentSystem.Models;
using System;

namespace P01_StudentSystem
{
    internal class Program
    {
        public static void Seed(StudentSystemContext context)
        {
            if (context.Students.Any()) return;
            var students = new List<Student>
        {
            new Student { StudentId = 1, Name = "Ahmed Omar", PhoneNumber = "123456789", RegisteredOn = DateTime.Now },
            new Student { StudentId = 2, Name = "Abdelrahman", PhoneNumber = "123456789", RegisteredOn = DateTime.Now, Birthday = new DateTime(1998, 11, 7) },
        };

            var courses = new List<Course>
        {
            new Course { CourseId = 1, Name = "Java" },
            new Course { CourseId = 2, Name = "C Sharp" }
        };
            var studentCourses = new List<StudentCourse>
        {
            new StudentCourse { StudentId = 1, CourseId = 1 },
            new StudentCourse { StudentId = 1, CourseId = 2 },
            new StudentCourse { StudentId = 2, CourseId = 2 }
        };

            var resources = new List<Resource>
        {
            new Resource { ResourceId = 1, Name = "Udemy", Url = "http://udemy.com", CourseId = 1 },
            new Resource { ResourceId = 2, Name = "Eraa Soft", Url = "http://eraasoft.com", CourseId = 2 }
        };
            var homework = new List<HomeWork>
        {
            new HomeWork
            {
                HomeworkId = 1,
                Content = "files/java.pdf",
                ContentType = ContentType.PDF,
                SubmissionTime = DateTime.Now,
                StudentId = 1,
                CourseId = 1
            },
            new HomeWork
            {
                HomeworkId = 2,
                Content = "files/csharp.zip",
                ContentType = ContentType.ZIP,
                SubmissionTime = DateTime.Now,
                StudentId = 2,
                CourseId = 2
            }
        };
            context.Students.AddRange(students);
            context.Courses.AddRange(courses);
            context.StudentCourses.AddRange(studentCourses);
            context.Resources.AddRange(resources);
            context.HomeWorks.AddRange(homework);

            context.SaveChanges();
        }
        static void Main(string[] args)
        {
            using var context = new StudentSystemContext();

            Console.WriteLine("Seeding the database...");
            Seed(context);
            Console.WriteLine("Seeding data completed");

            Console.WriteLine("Listing students and their courses:");

            var students = context.Students;

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}");
                foreach (var c in student.StudentCourses)
                {
                    Console.WriteLine($"  is taking {c.Course.Name} Course");
                }
            }
        }
    }
}
