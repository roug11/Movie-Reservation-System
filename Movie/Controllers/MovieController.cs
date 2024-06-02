using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        [HttpGet("hello")]
        public IActionResult GetHello()
        {
            return Ok("Hello, world!");
        }

    }
}
