using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLayer.Controllers
{
    [Route("api/[controller]")]
    public class RezervationsController : Controller
    {
        private readonly ILogger<RezervationsController> _logger;
        private IRezervationService service;

        public RezervationsController(IRezervationService service, ILogger<RezervationsController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("BookedDay")]
        public IEnumerable<BookedDays> BookedDay(DateTime start, DateTime end, int roomId)
        {
            _logger.LogInformation("Index page says hello");
            return service.GetBookedDay(start, end, roomId);
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Rezervation> Get()
        {
            return service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Rezervation Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Rezervation value)
        {
            service.Create(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Rezervation value)
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