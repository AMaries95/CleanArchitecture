using System.Collections.Generic;
using CleanArchitecture.ApplicationCore.ViewModels;

namespace CleanArchitecture.ApplicationCore.Interfaces
{
    public interface ICourseService
    {
        CourseViewModel GetCourses();
    }
}