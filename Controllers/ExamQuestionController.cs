using E_LearningPlatform.Models;
using E_LearningPlatform.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsQuestionController : ControllerBase
    {
        private readonly BaseRepository<ExamsQuestion> _repository;

        public ExamsQuestionController(BaseRepository<ExamsQuestion> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamsQuestion>>> GetExamsQuestions()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamsQuestion>> GetExamsQuestion(int id)
        {
            var examsQuestion = _repository.Find(eq => eq.Id == id);
            if (examsQuestion == null)
            {
                return NotFound();
            }
            return Ok(examsQuestion);
        }

        [HttpPost]
        public async Task<ActionResult<ExamsQuestion>> PostExamsQuestion(ExamsQuestion examsQuestion)
        {
            _repository.Add(examsQuestion);
            return CreatedAtAction(nameof(GetExamsQuestion), new { id = examsQuestion.Id }, examsQuestion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamsQuestion(int id, ExamsQuestion examsQuestion)
        {
            if (id != examsQuestion.Id)
            {
                return BadRequest();
            }

            _repository.Update(examsQuestion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamsQuestion(int id)
        {
            var examsQuestion = _repository.Find(eq => eq.Id == id);
            if (examsQuestion == null)
            {
                return NotFound();
            }

            _repository.Delete(examsQuestion);
            return NoContent();
        }
    }
}
