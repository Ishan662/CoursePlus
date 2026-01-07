using CoursePlus.Application.DTOs;
using CoursePlus.Application.Interfaces.Courses;
using CoursePlus.Application.Mappings;
using CoursePlus.Domain.EntitiesNew;

namespace CoursePlus.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task AddCourseAsync(CreateCourseDTO createCourseDTO)
        {
            var course = createCourseDTO.ToEntity();
            course.CreatedBy = 1;
            course.CreatedOn = DateTime.Now;

            await _courseRepository.AddCourseAsync(course);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            if (course == null)
                throw new KeyNotFoundException($"Course with ID {courseId} not found.");

            await _courseRepository.DeleteCourseAsync(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            return courses.Select(c => c.ToDto());
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int courseId)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            return course?.ToDto();
        }

        public async Task<bool> IsTitleDuplicateAsync(string title)
        {
            return await _courseRepository.IsTitleDuplicateAsync(title);
        }

        public async Task UpdateCourseAsync(int courseId, UpdateCourseDTO updateCourseDTO)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            if (course == null)
                throw new KeyNotFoundException($"Course with ID {courseId} not found.");

            updateCourseDTO.UpdateEntity(course);
            await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task UpdateDescriptionAsync(int courseId, string description)
        {
            await _courseRepository.UpdateDescriptionAsync(courseId, description);
        }
    }
}
