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
    public class AnswerController : ControllerBase
    {
        private readonly IBaseRepository<Answer> _repository;

        //public AnswerController(IBaseRepository<Answer> repository)
        //{
        //    _repository = repository;
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<Answer>> GetAnswers()
        //{
        //    return Ok(_repository.GetAll());
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Answer> GetAnswer(int id)
        //{
        //    var answer = _repository.Find(a => a.ID == id);
        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(answer);
        //}

        //[HttpPost]
        //public ActionResult<Answer> PostAnswer(Answer answer)
        //{
        //    _repository.Add(answer);
        //    _repository.SaveChanges();
        //    return CreatedAtAction(nameof(GetAnswer), new { id = answer.ID }, answer);
        //}

        //[HttpPut("{id}")]
        //public IActionResult PutAnswer(int id, Answer answer)
        //{
        //    if (id != answer.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _repository.Update(answer);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteAnswer(int id)
        //{
        //    var answer = _repository.Find(a => a.ID == id);
        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.Delete(answer);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}
    }
}
