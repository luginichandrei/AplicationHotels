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

        [HttpGet("{start}/{end}/{roomId}")]
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

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Rezervation>), 200)]
        public IActionResult Create([FromBody]Rezervation value)
        {
            return Ok(new List<Rezervation>() { service.Create(value) });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Rezervation>), 200)]
        public IActionResult Delete(int id)
        {
            return Ok(new List<Rezervation>() { service.Delete(id) });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Rezervation>), 200)]
        public IActionResult Get(int id)
        {
            return Ok(new List<Rezervation>() { service.GetById(id) });
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Rezervation>), 200)]
        public IActionResult Get()
        {
            var rezervations = new List<Rezervation>();
            rezervations.AddRange(service.GetAll());
            return Ok(rezervations);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Rezervation>), 200)]
        public IActionResult Update(int id, [FromBody]Rezervation value)
        {
            return Ok(new List<Rezervation>() { service.Update(value) });
        }
    }
}