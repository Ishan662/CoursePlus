using CoursePlus.Application.DTOs;
using CoursePlus.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Application.Interfaces.Courses
{
    internal interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> GetCourseByIdAsync(int courseId);
        Task<bool> IsTitleDuplicateAsync(string title);
        Task AddCourseAsync(CreateCourseDTO createCourseDTO);
        Task UpdateCourseAsync(int courseId, UpdateCourseDTO updateCourseDTO);
        Task DeleteCourseAsync(int courseId);
        Task UpdateDescriptionAsync(int courseId, string description);


    }
}
