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
    public class RoomsController : Controller
    {
        private IRoomService service;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(IRoomService service, ILogger<RoomsController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult Create([FromBody]Room value)
        {
            return Ok(new List<Room>() { service.Create(value) });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult Delete(int id)
        {
            return Ok(new List<Room>() { service.Delete(id) });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult Get(int id)
        {
            return Ok(new List<Room>() { service.GetById(id) });
        }

        [HttpGet("GetByHotelId/{id}")]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult GetByHotelId(int id)
        {
            var rooms = new List<Room>();
            rooms.AddRange(service.FindByHotelId(id));
            return Ok(rooms);
        }

        [HttpGet("{roomNumber}/{hotelId}")]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult GetByRoomNumber(int roomNumber, int hotelId)
        {
            return Ok(new List<Room>() { service.FindByNumber(roomNumber, hotelId) });
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult Get()
        {
            var rooms = new List<Room>();
            rooms.AddRange(service.GetAll());
            return Ok(rooms);
        }

        [HttpGet("{start}/{end}/{hotelId}")]
        [Route("RoomsRating")]
        [ProducesResponseType(typeof(IEnumerable<TopRoom>), 200)]
        public IActionResult RoomsRating(DateTime start, DateTime end, int hotelId)
        {
            try
            {
                var rooms = new List<TopRoom>();

                _logger.LogInformation("Fetching all the RoomsRating from the storage");

                rooms.AddRange(service.GetRoomRating(start, end, hotelId));

                _logger.LogInformation($"Returning {rooms.Count()} BookedDays.");
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult Update(int id, [FromBody]Room value)
        {
            return Ok(new List<Room>() { service.Update(value) });
        }
    }
}