using HotelApp.Application.Abstractions.Repositories;
using HotelApp.Domain;
using Moq;
using Xunit;
using HotelApp.Application.Services;
using TheoryAttribute = Xunit.TheoryAttribute;
using Assert = Xunit.Assert;

namespace HotelApp.Tests
{

    public class BookingServiceTests
    {
        private readonly Mock<IBookingRepository> _bookingRepositoryMock;
        private readonly Application.Services.BookingService _bookingService;

        public BookingServiceTests()
        {
            _bookingRepositoryMock = new Mock<IBookingRepository>();
            _bookingService = new Application.Services.BookingService(_bookingRepositoryMock.Object, null); // Передаем Mock
        }

        [Theory]
        [InlineData(1, "2025-01-01", "2025-01-05", "2025-01-06", "2025-01-10", true)] // Комната доступна
        [InlineData(1, "2025-01-01", "2025-01-05", "2025-01-03", "2025-01-07", false)] // Даты пересекаются
        [InlineData(1, "2025-01-01", "2025-01-05", "2025-01-01", "2025-01-05", false)] // Полное совпадение
        [InlineData(1, "2025-01-01", "2025-01-05", "2024-12-30", "2025-01-02", false)] // Частичное пересечение
        public async Task IsRoomAvailableAsync_ShouldReturnExpectedResult(
            int roomId,
            string startDateStr,
            string endDateStr,
            string bookingStartDateStr,
            string bookingEndDateStr,
            bool expectedResult)
        {
            // Arrange
            var startDate = DateTime.Parse(startDateStr);
            var endDate = DateTime.Parse(endDateStr);
            var bookingStartDate = DateTime.Parse(bookingStartDateStr);
            var bookingEndDate = DateTime.Parse(bookingEndDateStr);

            var existingBookings = new List<Domain.Booking>
        {
            new Booking
            {
                RoomId = roomId,
                CheckInDate = bookingStartDate,
                CheckOutDate = bookingEndDate
            }
        };

            _bookingRepositoryMock
                .Setup(repo => repo.GetBookingsByRoomIdAsync(roomId))
                .ReturnsAsync(existingBookings);

            // Act
            var result = await _bookingService.IsRoomAvailableAsync(roomId, startDate, endDate);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }

}