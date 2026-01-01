using CoursePlus.Application.Interfaces.Courses;
using CoursePlus.Domain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CoursePlusContext _dbContext;

        public CourseRepository(CoursePlusContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _dbContext.Courses.ToListAsync();
        }
    }
}
