using E_LearningPlatform.Models;
using E_LearningPlatform.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly BaseRepository<Answer> _repository;

        public AnswerController(BaseRepository<Answer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            var answer = _repository.Find(a => a.ResultId == id);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
            _repository.Add(answer);
            return CreatedAtAction(nameof(GetAnswer), new { id = answer.ResultId }, answer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {
            if (id != answer.ResultId)
            {
                return BadRequest();
            }

            _repository.Update(answer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = _repository.Find(a => a.ResultId == id);
            if (answer == null)
            {
                return NotFound();
            }

            _repository.Delete(answer);
            return NoContent();
        }
    }
}
