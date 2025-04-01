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

        public CoursesController()
        {
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Course>> GetCourses()
        //{
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Course> GetCourse(int id)
        //{
        //}

        //[HttpPost]
        //public ActionResult<Course> PostCourse(Course course)
        //{
        //}

        //[HttpPut("{id}")]
        //public IActionResult PutCourse(int id, Course course)
        //{
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteCourse(int id)
        //{
        //}
    }
}
