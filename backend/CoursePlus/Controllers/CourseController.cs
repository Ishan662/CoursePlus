using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursePlus.Application.Interfaces.Courses;

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

        public ICourseService Service { get; }
    }
}
