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

        public Task AddCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetAllCoursesAsync()
        {
            return _dbContext.Courses.ToListAsync();
        }

        public Task<Course?> GetCourseByIdAsync(int CourseId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsTitleDuplicateAsync(string Title)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDescriptionAsync(int CourseId, string Description)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Course>> ICourseRepository.GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
