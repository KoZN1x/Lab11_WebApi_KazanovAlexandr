using Lab11_KazanovAlexandr.Data;
using Lab11_KazanovAlexandr.Models;
using Lab11_KazanovAlexandr.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Lab11_KazanovAlexandr.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service) 
        {
            _service = service;
        }

        /// <summary>
        /// Creates user
        /// </summary>
        // POST: User/Create
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
            _service.AddUser(user);
            return Ok(_service.GetAllUsers());
        }

        /// <summary>
        /// Get full list of users
        /// </summary>
        // Get: User/Read
        [HttpGet]
        [Route("Read")]
        public IEnumerable<User> Read()
        {
            return _service.GetAllUsers();
        }

        /// <summary>
        /// Updates user information
        /// </summary>
        // PUT: User/Update/{id}
        [HttpPut]
        [Route("Update/{id:int}")]
        public IActionResult Update([FromRoute] int id, AddUserViewModel updateUser)
        {
            var user = _service.GetUser(id);
            if (user != null)
            {
                _service.UpdateUser(user, updateUser);
                return Ok(_service.GetAllUsers());
            }
            return NotFound();
        }

        /// <summary>
        /// Deletes user
        /// </summary>
        // DELETE: User/Delete/{id}
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var user = _service.GetUser(id);
            if (user != null)
            {
                _service.DeleteUser(user);  
                return Ok(_service.GetAllUsers());
            }
            return NotFound();
        }
    }
}
