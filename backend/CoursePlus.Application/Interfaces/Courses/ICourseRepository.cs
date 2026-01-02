using CoursePlus.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Application.Interfaces.Courses
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();

        Task<IEnumerable<Course>> GetAllCoursesAsync();

        Task<Course?> GetCourseByIdAsync(int CourseId);

        Task<bool> IsTitleDuplicateAsync(string Title);

        Task AddCourseAsync(Course course);

        Task UpdateCourseAsync(Course course);

        Task DeleteCourseAsync(Course course);

        Task UpdateDescriptionAsync(int CourseId, string Description);

    }
}
