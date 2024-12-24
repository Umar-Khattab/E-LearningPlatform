using E_LearningPlatform.Models;
using E_LearningPlatform.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly BaseRepository<StudentExam> _repository;

        public StudentExamController(BaseRepository<StudentExam> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentExam>>> GetStudentExams()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentExam>> GetStudentExam(int id)
        {
            var studentExam = _repository.Find(se => se.Id == id);
            if (studentExam == null)
            {
                return NotFound();
            }
            return Ok(studentExam);
        }

        [HttpPost]
        public async Task<ActionResult<StudentExam>> PostStudentExam(StudentExam studentExam)
        {
            _repository.Add(studentExam);
            return CreatedAtAction(nameof(GetStudentExam), new { id = studentExam.Id }, studentExam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentExam(int id, StudentExam studentExam)
        {
            if (id != studentExam.Id)
            {
                return BadRequest();
            }

            _repository.Update(studentExam);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentExam(int id)
        {
            var studentExam = _repository.Find(se => se.Id == id);
            if (studentExam == null)
            {
                return NotFound();
            }

            _repository.Delete(studentExam);
            return NoContent();
        }
    }
}

