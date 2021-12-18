using System.Collections.Generic;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
    }
}