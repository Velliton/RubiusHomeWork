using Microsoft.AspNetCore.Mvc;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using HotelApp.Domain;
using HotelApp.Application.Models;
namespace HotelApp.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class BookingController(IBookingService bookingService) : ControllerBase
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IReadOnlyCollection<BookingDto>> Get()
        {
            return bookingService.GetBookings();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<BookingDto> GetById(long id)
        {
            return bookingService.GetById(id);
        }
        /// <summary>
        /// Creates the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> Create(BookingDto booking)
        {
            return bookingService.Create(booking);
        }
        /// <summary>
        /// Updates the booking.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookingDto">The booking dto.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(long id, [FromBody] BookingDto bookingDto)
        {
            if (id != bookingDto.BookingId)
            {
                return BadRequest("Идентификатор клиента в URL не совпадает с данными.");
            }
            await bookingService.Update(bookingDto);
            return NoContent();
        }


    }
}