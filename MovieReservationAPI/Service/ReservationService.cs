using MovieReservationAPI.Entities;
using MovieReservationAPI.Repository;

namespace MovieReservationAPI.Service
{
    public class ReservationService : IReservationService
    {
        public IReservationRepository _repository { get; set;}
        public ReservationService(IReservationRepository repository)
        {
            _repository= repository;
        }

        public async Task<Reservation> GetById(int id)=> await _repository.GetById(id);

        public async Task<List<Reservation>> GetAll() => await _repository.GetAll();
       

        public async Task<Reservation> Create(Reservation reservation)
        {
            var newReservation = new Reservation();
            {
                newReservation.ReservationDay = reservation.ReservationDay;
                newReservation.UserId = reservation.UserId;
                newReservation.ScheduledId = reservation.ScheduledId;
                newReservation.Seats = reservation.Seats;
            };
            await _repository.Create(newReservation);
            return newReservation;
        }
    }
}
