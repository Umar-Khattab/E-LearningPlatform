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
    public class CoursesController : ControllerBase
    {
        private readonly IBaseRepository<Course> _repository;

        public CoursesController(IBaseRepository<Course> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = _repository.Find(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> PostCourse(Course course)
        {
            _repository.Add(course);
            _repository.SaveChanges();
            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _repository.Update(course);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = _repository.Find(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            _repository.Delete(course);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
