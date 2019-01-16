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
        private readonly ILogger<HotelsController> _logger;
        private IHotelService service;

        public HotelsController(IHotelService service, ILogger<HotelsController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Hotel>), 200)]
        public IActionResult Create([FromBody]Hotel value)
        {
            return Ok(new List<Hotel>() { service.Create(value) });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Hotel>), 200)]
        public IActionResult Delete(int id)
        {
            return Ok(new List<Hotel>() { service.Delete(id) });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<Hotel>), 200)]
        public IActionResult Get(int id)
        {
            return Ok(new List<Hotel>() { service.GetById(id) });
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(IEnumerable<Hotel>), 200)]
        public IActionResult Name(string name)
        {
            return Ok(new List<Hotel>() { service.FindByName(name) });
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Hotel>), 200)]
        public IActionResult Get()
        {
            var hotels = new List<Hotel>();
            hotels.AddRange(service.GetAll());
            return Ok(hotels);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Hotel>), 200)]
        public IActionResult Update(int id, [FromBody]Hotel value)
        {
            return Ok(new List<Hotel>() { service.Update(value) });
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View("~/Views/Index.cshtml");
        }
    }
}