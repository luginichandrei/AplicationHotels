using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
        [ProducesResponseType(200, Type = typeof(List<BookedDays>))]
        public IActionResult BookedDays(DateTime start, DateTime end, int roomId)
        {
            try
            {
                _logger.LogInformation("Fetching all the BookedDays from the storage");

                var bookedDays = service.GetBookedDays(start, end, roomId);

                _logger.LogInformation($"Returning {bookedDays.Count()} BookedDays.");

                return Ok(bookedDays);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "");
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get(int? id)
        {
            if (id.HasValue)
            {
                return Ok(service.GetById(id.Value));
            }
            else
            {
                return Ok(service.GetAll());
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]Rezervation value)
        {
            return Ok(service.Create(value));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Rezervation value)
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