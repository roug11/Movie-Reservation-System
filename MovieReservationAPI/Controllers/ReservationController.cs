using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Entities;
using MovieReservationAPI.Service;

namespace MovieReservationAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public IReservationService _service { get; set; }
        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetById(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            var getReservation=await _service.GetById(id);
            return Ok(getReservation);
        }

        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> GetAll()
        {
            var getAllReservation=await _service.GetAll();
            return Ok(getAllReservation);
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> Create(Reservation reservation)
        {
            var newReservation=await _service.Create(reservation);
            return Ok(newReservation);
        }

    }
}
