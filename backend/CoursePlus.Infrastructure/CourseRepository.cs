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

        public async Task AddCourseAsync(Course course)
        {
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
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

        public async Task<Course?> GetCourseByIdAsync(int CourseId)
        {
            return await _dbContext.Courses.FindAsync(CourseId);
        }

        public async Task<bool> IsTitleDuplicateAsync(string Title)
        {
            return await _dbContext.Courses.AnyAsync(c => c.Title == Title);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDescriptionAsync(int CourseId, string Description)
        {
            var course = await _dbContext.Courses.FindAsync(CourseId);
            if (course == null) throw new KeyNotFoundException("Course Not Found");

            course.Description = Description;
            await _dbContext.SaveChangesAsync();
        }

        Task<IEnumerable<Course>> ICourseRepository.GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
