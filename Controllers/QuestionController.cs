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
    public class QuestionController : ControllerBase
    {
        private readonly IBaseRepository<Question> _repository;

        //public QuestionController(IBaseRepository<Question> repository)
        //{
        //    _repository = repository;
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<Question>> GetQuestions()
        //{
        //    return Ok(_repository.GetAll());
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Question> GetQuestion(int id)
        //{
        //    var question = _repository.Find(q => q.QuestionId == id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(question);
        //}

        //[HttpPost]
        //public ActionResult<Question> PostQuestion(Question question)
        //{
        //    _repository.Add(question);
        //    _repository.SaveChanges();
        //    return CreatedAtAction(nameof(GetQuestion), new { id = question.QuestionId }, question);
        //}

        //[HttpPut("{id}")]
        //public IActionResult PutQuestion(int id, Question question)
        //{
        //    if (id != question.QuestionId)
        //    {
        //        return BadRequest();
        //    }

        //    _repository.Update(question);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteQuestion(int id)
        //{
        //    var question = _repository.Find(q => q.QuestionId == id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.Delete(question);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}
    }
}

