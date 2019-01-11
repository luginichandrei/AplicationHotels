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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Hotel>> Get(int? id)
        {
            if (id.HasValue)
            {
                return Ok(new List<Hotel>() { service.GetById(id.Value) });
            }else
            {
                return Ok(service.GetAll());
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]Hotel value)
        {
            return Ok(service.Create(value));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Hotel value)
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