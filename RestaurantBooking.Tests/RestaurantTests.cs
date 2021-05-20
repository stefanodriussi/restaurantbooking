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
    }
}
