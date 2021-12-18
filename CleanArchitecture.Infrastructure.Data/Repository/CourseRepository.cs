using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Infrastructure.Data.Context;

namespace CleanArchitecture.Infrastructure.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private LearningDbContext _dbcontext;

        public CourseRepository(LearningDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dbcontext.Courses;
        }
    }
}
