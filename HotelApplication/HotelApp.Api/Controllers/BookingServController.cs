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
    public class BookingServController(IBookingServService bookingServService) : ControllerBase
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IReadOnlyCollection<BookingServiceDto>> Get()
        {
            return bookingServService.GetBookingServices();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<BookingServiceDto> GetById(long id)
        {
            return bookingServService.GetById(id);
        }
        /// <summary>
        /// Creates the specified booking serv.
        /// </summary>
        /// <param name="bookingServ">The booking serv.</param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> Create(BookingServiceDto bookingServ)
        {
            return bookingServService.Create(bookingServ);

        }

        /// <summary>
        /// Updates the booking serv.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookingServiceDto">The booking service dto.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookingServ(long id, [FromBody] BookingServiceDto bookingServiceDto)
        {
            if (id != bookingServiceDto.BookingServiceId)
            {
                return BadRequest("Идентификатор клиента в URL не совпадает с данными.");
            }

            await bookingServService.Update(bookingServiceDto);
            return NoContent();
        }

    }
}