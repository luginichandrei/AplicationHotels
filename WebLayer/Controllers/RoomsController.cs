using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLayer.Controllers
{
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private IRoomService service;

        public RoomsController(IRoomService service)
        {
            this.service = service;
        }

        // GET: api/<controller>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult Get(int id)
        {
            return Ok(new List<Room>() { service.GetById(id) });
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult Get()
        {
            var rooms = new List<Room>();
            rooms.AddRange(service.GetAll());
            return Ok(rooms);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]Room value)
        {
            return Ok(service.Create(value));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Room value)
        {
            return Ok(service.Update(value));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(service.Delete(id));
        }
    }
}