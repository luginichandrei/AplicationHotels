using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : Controller
    {
        //[SwaggerOperation(OperationId= "GetJokes")]
        [HttpGet("", Name = "GetJokes")]
        [ProducesResponseType(typeof(Joke[]), 200)]
        public IActionResult Get()
        {
            var jokes = new Joke[]
            {
        new Joke()
        {
            Question = "What do you call a boomerang that won't come back?",
            Answer = "A stick"
        },
        new Joke()
        {
            Question = "What horse never comes out in the daytime?",
            Answer = "A night mare"
        }
            };

            return Ok(jokes);
        }
    }
}