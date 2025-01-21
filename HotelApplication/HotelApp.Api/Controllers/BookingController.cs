using Microsoft.AspNetCore.Mvc;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using HotelApp.Domain;
using HotelApp.Application.Models;
namespace HotelApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController(IBookingService bookingService) : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>


        [HttpGet]
        public Task<IReadOnlyCollection<BookingDto>> Get()
        {
            return bookingService.GetBookings();
        }
        [HttpGet("{id}")]
        public Task<BookingDto> GetById(long id)
        {
            return bookingService.GetById(id);
        }

        [HttpPost]
        public Task<long> Create(BookingDto booking)
        {
            return bookingService.Create(booking);

        }

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