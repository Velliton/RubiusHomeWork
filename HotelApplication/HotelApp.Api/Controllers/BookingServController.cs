using Microsoft.AspNetCore.Mvc;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using HotelApp.Domain;
using HotelApp.Application.Models;
namespace HotelApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingServController(IBookingServService bookingServService) : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>


        [HttpGet]
        public Task<IReadOnlyCollection<BookingServiceDto>> Get()
        {
            return bookingServService.GetBookingServices();
        }
        [HttpGet("{id}")]
        public Task<BookingServiceDto> GetById(long id)
        {
            return bookingServService.GetById(id);
        }

        [HttpPost]
        public Task<long> Create(BookingServiceDto bookingServ)
        {
            return bookingServService.Create(bookingServ);

        }


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