using MovieReservationAPI.Entities;

namespace MovieReservationAPI.Service
{
    public interface IReservationService
    {
        Task<Reservation> GetById(int id);
        Task<List<Reservation>> GetAll();
        Task<Reservation> Create(Reservation reservation);
    }
}
