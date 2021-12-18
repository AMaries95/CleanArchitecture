using System.Collections.Generic;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.ApplicationCore.ViewModels
{
    public class CourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
