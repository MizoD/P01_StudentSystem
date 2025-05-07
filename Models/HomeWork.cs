using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    enum ContentType
    {
        APPLICATION, PDF, ZIP
    }
    class HomeWork
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; } = string.Empty;

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
