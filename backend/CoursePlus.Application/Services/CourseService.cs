using AutoMapper;
using CoursePlus.Application.DTOs;
using CoursePlus.Application.Interfaces.Courses;
using CoursePlus.Domain.EntitiesNew;

namespace CoursePlus.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository;
            this._mapper = mapper;
        }
        public async Task AddCourseAsync(CreateCourseDTO createCourseDTO)
        {
            var course = _mapper.Map<Course>(createCourseDTO);
            course.CreatedBy = 1;
            course.CreatedOn = DateTime.Now;

             await _courseRepository.AddCourseAsync(course);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            if (course == null) throw new KeyNotFoundException($"Course with ID: {courseId} not found.");

            await _courseRepository.DeleteCourseAsync(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);

        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int courseId)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            return course == null? null : _mapper.Map<CourseDTO>(course);
        }

        public async Task<bool> IsTitleDuplicateAsync(string title)
        {
            return await _courseRepository.IsTitleDuplicateAsync(title);
        }

        public async Task UpdateCourseAsync(int courseId, UpdateCourseDTO updateCourseDTO)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            if (course == null) throw new KeyNotFoundException($"Course with ID {courseId} not found.");

            _mapper.Map(updateCourseDTO, course);
            await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task UpdateDescriptionAsync(int courseId, string description)
        {
            await _courseRepository.UpdateDescriptionAsync(courseId, description);
        }
    }
}
