using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLayer.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult Delete(int id)
        {
            return Ok(new List<User>() { service.Delete(id) });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult Get(int id)
        {
            return Ok(new List<User>() { service.GetById(id) });
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult Get()
        {
            var users = new List<User>();
            users.AddRange(service.GetAll());
            return Ok(users);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult Name(string name)
        {
            return Ok(new List<User>() { service.FindByName(name) });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult Update(int id, [FromBody]User value)
        {
            return Ok(new List<User>() { service.Update(value) });
        }
    }
}