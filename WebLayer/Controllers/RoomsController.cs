using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
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
            var rooms = new List<TopRoom>();
            rooms.AddRange(service.GetRoomRating(start, end, hotelId));
            return Ok(rooms);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public IActionResult Update(int id, [FromBody]Room value)
        {
            return Ok(new List<Room>() { service.Update(value) });
        }
    }
}