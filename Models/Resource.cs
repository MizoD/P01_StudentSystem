using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    enum ResourceT{ VIDEO, PRESENTATION, DOCUMENT, OTHERS  }
    class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public ResourceT ResourceType { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
