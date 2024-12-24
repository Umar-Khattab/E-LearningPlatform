using E_LearningPlatform.Models;
using E_LearningPlatform.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BaseRepository<User> _repository;

        public UserController(BaseRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _repository.Find(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _repository.Add(user);
            _repository.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _repository.Update(user);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _repository.Find(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            _repository.Delete(user);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}

