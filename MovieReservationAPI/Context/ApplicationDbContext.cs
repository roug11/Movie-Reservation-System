using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Entities;

namespace MovieReservationAPI.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
