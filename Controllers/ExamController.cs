using E_LearningPlatform.Interfaces;
using E_LearningPlatform.Models;
using E_LearningPlatform.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ExamController(IBaseRepository<Exam> repository) : ControllerBase
    {
        private readonly IBaseRepository<Exam> _repository = repository;

        //[HttpGet]
        //public ActionResult<IEnumerable<Exam>> GetExams()
        //{
        //    return Ok(_repository.GetAll());
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Exam> GetExam(int id)
        //{
        //    var exam = _repository.Find(e => e.ExamId == id);
        //    if (exam == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(exam);
        //}

        //[HttpPost]
        //public ActionResult<Exam> PostExam(Exam exam)
        //{
        //    _repository.Add(exam);
        //    _repository.SaveChanges();
        //    return CreatedAtAction(nameof(GetExam), new { id = exam.ExamId }, exam);
        //}

        //[HttpPut("{id}")]
        //public IActionResult PutExam(int id, Exam exam)
        //{
        //    if (id != exam.ExamId)
        //    {
        //        return BadRequest();
        //    }

        //    _repository.Update(exam);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteExam(int id)
        //{
        //    var exam = _repository.Find(e => e.ExamId == id);
        //    if (exam == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.Delete(exam);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}
    }
}
