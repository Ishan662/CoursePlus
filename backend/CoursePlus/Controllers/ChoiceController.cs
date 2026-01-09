using CoursePlus.Application.Interfaces.QuestionsChoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoiceService service;

        public ChoiceController(IChoiceService service)
        {
            this.service = service;
        }
    }
}
