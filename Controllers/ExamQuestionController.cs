using E_LearningPlatform.Interfaces;
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
        private readonly IBaseRepository<ExamsQuestion> _repository;

        public ExamsQuestionController(IBaseRepository<ExamsQuestion> repository)
        {
            _repository = repository;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<ExamsQuestion>> GetExamsQuestions()
        //{
        //    return Ok(_repository.GetAll());
        //}

        //[HttpGet("{id}")]
        //public ActionResult<ExamsQuestion> GetExamsQuestion(int id)
        //{
        //    var examsQuestion = _repository.Find(eq => eq.Id == id);
        //    if (examsQuestion == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(examsQuestion);
        //}

        //[HttpPost]
        //public ActionResult<ExamsQuestion> PostExamsQuestion(ExamsQuestion examsQuestion)
        //{
        //    _repository.Add(examsQuestion);
        //    _repository.SaveChanges();
        //    return CreatedAtAction(nameof(GetExamsQuestion), new { id = examsQuestion.Id }, examsQuestion);
        //}

        //[HttpPut("{id}")]
        //public IActionResult PutExamsQuestion(int id, ExamsQuestion examsQuestion)
        //{
        //    if (id != examsQuestion.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _repository.Update(examsQuestion);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteExamsQuestion(int id)
        //{
        //    var examsQuestion = _repository.Find(eq => eq.Id == id);
        //    if (examsQuestion == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.Delete(examsQuestion);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}
    }
}
