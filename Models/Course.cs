﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal Price { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
