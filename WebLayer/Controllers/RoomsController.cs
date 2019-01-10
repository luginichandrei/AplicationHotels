using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

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