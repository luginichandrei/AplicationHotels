using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : Controller
    {
        private IHotelService service;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(IHotelService service, ILogger<HotelsController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            var hotels = service.GetAll();
            _logger.LogInformation("Run method Get");
            return hotels;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Hotel value)
        {
            service.Create(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Hotel value)
        {
            service.Update(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}