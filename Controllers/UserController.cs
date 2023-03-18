using Lab11_KazanovAlexandr.Data;
using Lab11_KazanovAlexandr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Lab11_KazanovAlexandr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context) 
        {
            _context = context;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(AddUserViewModel addUser)
        {
            var user = new User()
            {
                Name = addUser.Name,
                Email = addUser.Email,
                Password = addUser.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("Read")]
        public IEnumerable<User> Read()
        {
            return _context.Users.ToList();
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public IActionResult Update([FromRoute] int id, AddUserViewModel updateUser)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.Name = updateUser.Name;
                user.Email = updateUser.Email;
                user.Password = updateUser.Password;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
