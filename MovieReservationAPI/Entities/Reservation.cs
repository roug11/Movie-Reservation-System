using System.ComponentModel.DataAnnotations;

namespace MovieReservationAPI.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int ScheduledId { get; set; }
        public int UserId { get; set; }
        public string Seats { get; set; }
        public string ReservationDay { get; set; }
        public double TotalAmount { get; set; }
        public bool Paid { get; set; }
    }
}
