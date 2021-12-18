using System.Collections.Generic;
using CleanArchitecture.ApplicationCore.Interfaces;
using CleanArchitecture.ApplicationCore.ViewModels;
using CleanArchitecture.Domain.Commands;
using CleanArchitecture.Domain.Core.Bus;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.ApplicationCore.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler mediatorHandler)
        {
            _courseRepository = courseRepository;
            _mediatorHandler = mediatorHandler;
        }

        public void CreateCourse(CourseViewModel courseViewModel)
        {
            var createCourseCommand = new CreateCourseCommand(
                courseViewModel.Name, 
                courseViewModel.Description, 
                courseViewModel.ImageUrl);

            _mediatorHandler.SendCommand(createCourseCommand);
        }

        public CourseViewModel GetCourses()
        {
            return new CourseViewModel()
            {
                Courses = _courseRepository.GetCourses()
            };
        }
    }
}