using CoursePlus.Application.DTOs;
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
        private readonly IChoiceService _service;

        public ChoiceController(IChoiceService service)
        {
            this._service = service;
        }

        [HttpGet("{questionId}")]
        public async Task<ActionResult<IEnumerable<ChoiceDTO>>> GetChoices(int questionId)
        {
            return Ok(await _service.GetAllChoicesAsync(questionId));
        }

        [HttpGet("{questionId}/{id}")]
        public async Task<ActionResult<ChoiceDTO>> GetChoice(int questionId, int id)
        {
            var choice = await _service.GetChoiceByIdAsync(id);
            return choice == null ? NotFound() : Ok(choice);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateChoice([FromBody] CreateChoiceDTO dto)
        {
            await _service.AddChoiceAsync(dto);
            return Created(); 
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateChoice(int id, [FromBody] UpdateChoiceDTO dto)
        {
            await _service.UpdateChoiceAsync(id, dto);
            return NoContent();
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUserChoice(int id, [FromBody] UpdateUserChoice dto)
        {
            await _service.UpdateUserChoiceAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteChoice(int id)
        {
            await _service.DeleteChoiceAsync(id);
            return NoContent();
        }
    }
}
