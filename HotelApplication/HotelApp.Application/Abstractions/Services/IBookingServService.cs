using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    public interface IBookingServService
    {
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<BookingServiceDto>> GetBookingServices();

        Task<BookingServiceDto> GetById(long id);

        Task<long> Create(BookingServiceDto bookingServ);
        Task Delete(long id);

        Task Update(BookingServiceDto bookingServ);
    }
}
