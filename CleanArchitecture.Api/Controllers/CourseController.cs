using CleanArchitecture.ApplicationCore.Interfaces;
using CleanArchitecture.ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CourseViewModel courseViewModel)
        {
            _courseService.CreateCourse(courseViewModel);

            return Ok(courseViewModel);
        }
    }
}
