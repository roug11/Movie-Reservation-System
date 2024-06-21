using MovieReservationAPI.Entities;

namespace MovieReservationAPI.Repository
{
    public interface IReservationRepository
    {
        Task<Reservation> GetById(int id);
        Task<List<Reservation>> GetAll();
        Task<Reservation> Create(Reservation reservation);
    }
}
