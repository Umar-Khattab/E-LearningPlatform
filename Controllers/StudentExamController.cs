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
    public class StudentExamController : ControllerBase
    {
        private readonly IBaseRepository<StudentExam> _repository;

        //public StudentExamController(IBaseRepository<StudentExam> repository)
        //{
        //    _repository = repository;
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<StudentExam>> GetStudentExams()
        //{
        //    return Ok(_repository.GetAll());
        //}

        //[HttpGet("{id}")]
        //public ActionResult<StudentExam> GetStudentExam(int id)
        //{
        //    var studentExam = _repository.Find(se => se.Id == id);
        //    if (studentExam == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(studentExam);
        //}

        //[HttpPost]
        //public ActionResult<StudentExam> PostStudentExam(StudentExam studentExam)
        //{
        //    _repository.Add(studentExam);
        //    _repository.SaveChanges();
        //    return CreatedAtAction(nameof(GetStudentExam), new { id = studentExam.Id }, studentExam);
        //}

        //[HttpPut("{id}")]
        //public IActionResult PutStudentExam(int id, StudentExam studentExam)
        //{
        //    if (id != studentExam.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _repository.Update(studentExam);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteStudentExam(int id)
        //{
        //    var studentExam = _repository.Find(se => se.Id == id);
        //    if (studentExam == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.Delete(studentExam);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}
    }
}

