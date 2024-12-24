using E_LearningPlatform.Models;
using E_LearningPlatform.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly BaseRepository<Exam> _repository;

        public ExamController(BaseRepository<Exam> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            var exam = _repository.Find(e => e.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            _repository.Add(exam);
            return CreatedAtAction(nameof(GetExam), new { id = exam.ExamId }, exam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
            if (id != exam.ExamId)
            {
                return BadRequest();
            }

            _repository.Update(exam);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = _repository.Find(e => e.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            _repository.Delete(exam);
            return NoContent();
        }
    }
}
