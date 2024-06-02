using Microsoft.AspNetCore.Mvc;

namespace Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        [HttpGet("hello")]
        public IActionResult GetHello()
        {
            return Ok("Hello, world!");
        }

    }
}
