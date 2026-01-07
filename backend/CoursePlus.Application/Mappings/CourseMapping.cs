using CoursePlus.Application.DTOs;
using CoursePlus.Domain.EntitiesNew;

namespace CoursePlus.Application.Mappings
{
    public static class CourseMappings
    {
        // Course → CourseDTO
        public static CourseDTO ToDto(this Course course)
        {
            return new CourseDTO
            {
                CourseId = course.CourseId,   // match entity property
                Title = course.Title,
                Description = course.Description
            };
        }

        // CreateCourseDTO → Course
        public static Course ToEntity(this CreateCourseDTO dto)
        {
            return new Course
            {
                Title = dto.Title!,
                Description = dto.Description
            };
        }

        // UpdateCourseDTO → Course (update existing entity)
        public static void UpdateEntity(this UpdateCourseDTO dto, Course course)
        {
            if (dto.Title != null)
                course.Title = dto.Title;

            if (dto.Description != null)
                course.Description = dto.Description;
        }

        // CourseUpdateDescriptionDTO → Course (only description)
        public static void UpdateDescription(
            this CourseUpdateDescriptionDTO dto,
            Course course)
        {
            course.Description = dto.Description;
        }
    }
}
