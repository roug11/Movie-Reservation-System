using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Context;
using MovieReservationAPI.Entities;

namespace MovieReservationAPI.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        public ApplicationDBContext _db { get; set; }
        public ReservationRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<Reservation> Create(Reservation reservation)
        {
            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();
            return reservation;
        }

        public async Task<List<Reservation>> GetAll()
        {
           var getAllReservations= await _db.Reservations.ToListAsync();
            return getAllReservations;
        }

        public async Task<Reservation> GetById(int id)
        {
            var reservation=await _db.Reservations.FirstOrDefaultAsync(r => r.Id==id);
            return reservation;
        }
    }
}
