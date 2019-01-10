using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

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

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get(int? id)
        {
            if (id.HasValue)
            {
                return Ok(service.GetById(id.Value));
            }else
            {
                return Ok(service.GetAll());
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]User value)
        {
            var userAdd = service.Create(value);
            return Ok(userAdd);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]User value)
        {
            var userUpdate = service.Update(value);
            return Ok(userUpdate);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userDelete = service.Delete(id);
            return Ok(userDelete);
        }
    }
}
