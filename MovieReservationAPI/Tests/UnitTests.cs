using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieReservationAPI.Controllers;
using MovieReservationAPI.Entities;
using MovieReservationAPI.Service;
using Xunit;

namespace MovieReservationAPI.Tests.Controllers
{
    public class UnitTests
    {
        private readonly Mock<IReservationService> _serviceMock;
        private readonly ReservationController _controller;

        public UnitTests()
        {
            _serviceMock = new Mock<IReservationService>();
            _controller = new ReservationController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetById_ValidId_ReturnsOkResult()
        {
            int id = 1;
            var reservation = new Reservation { Id = id };
            _serviceMock.Setup(s => s.GetById(id)).ReturnsAsync(reservation);

            var result = await _controller.GetById(id);

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(reservation, (result.Result as OkObjectResult)?.Value);
        }

        [Fact]
        public async Task GetById_InvalidId_ReturnsNotFoundResult()
        {
            int id = -1;

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            var reservations = new List<Reservation>
            {
                new Reservation { Id = 1 },
                new Reservation { Id = 2 }
            };
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(reservations);

            var result = await _controller.GetAll();

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(reservations, (result.Result as OkObjectResult)?.Value);
        }

        [Fact]
        public async Task Create_ValidReservation_ReturnsOkResult()
        {
            var reservation = new Entities.Reservation
            {
                ReservationDay = "2023-06-01",
                UserId = 2,
                ScheduledId = 2,
                Seats = "3"
            };

            _serviceMock.Setup(s => s.Create(It.IsAny<Reservation>())).ReturnsAsync(reservation);

            var result = await _controller.Create(reservation);

            Assert.IsType<OkObjectResult>(result.Result);
            var createdReservation = (result.Result as OkObjectResult)?.Value as Reservation;
            Assert.NotNull(createdReservation);
            Assert.Equal(reservation.ReservationDay, createdReservation.ReservationDay);
            Assert.Equal(reservation.UserId, createdReservation.UserId);
            Assert.Equal(reservation.ScheduledId, createdReservation.ScheduledId);
            Assert.Equal(reservation.Seats, createdReservation.Seats);
        }
    }
}
