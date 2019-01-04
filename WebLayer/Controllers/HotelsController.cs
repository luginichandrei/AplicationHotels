using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLayer.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly HotelService service;

        public HotelsController(HotelService service)
        {
            this.service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}