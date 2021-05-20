using System;
using Xunit;
using System.Linq;

namespace RestaurantBooking.Tests
{
    public class RestaurantTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(6)]
        public void Reservation_with_enough_seats_should_return_a_valid_receipt(int requestedSeats)
        {
            // Arrange
            var restaurant = new Restaurant("Bettola", "Brigant", new[] { new Table(1, 1), new Table(2, 5) });

            // Act
            var reservation = restaurant.BookTable("Mario Rossi", "44324432", requestedSeats);

            // Assert
            Assert.NotNull(reservation);
            Assert.True(reservation.Tables.Sum(t => t.Seats) >= requestedSeats);
        }

        [Fact]
        public void Reservation_with_not_enough_seats_available_should_throw_exception()
        {
            // Arrange
            var restaurant = new Restaurant("Bettola", "Brigant", new[] { new Table(1, 1) });

            // Act & Assert
            Assert.Throws<NotEnoughTablesException>(() => restaurant.BookTable("Mario Rossi", "34234", 2));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Reservation_with_invalid_nuber_of_seats_requested_should_throw_exception(int requestedSeats)
        {
            // Arrange
            var restaurant = new Restaurant("Bettola", "Brigant", new[] { new Table(1, 1) });

            // Act & Assert
            Assert.Throws<ArgumentException>(() => restaurant.BookTable("Mario Rossi", "34234", requestedSeats));
        }
    }
}
