using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursePlus.Application.Interfaces.Courses;
using CoursePlus.Application.DTOs;

namespace CoursePlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        public CourseController(ICourseService Service )
        {
            this._service = Service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var courses = await _service.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(CourseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CourseDTO>> GetCourse(int id)
        {
            var course = await _service.GetCourseByIdAsync(id);
            return course == null ? NotFound() : Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCourseDTO), StatusCodes.Status200OK)]

    }
}
