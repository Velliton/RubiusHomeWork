using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    public interface IBookingService
    {
        /// <summary>
        /// Интерфейс сервиса для работы с бронированиями.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<BookingDto>> GetBookings();

        Task<BookingDto> GetById(long id);

        Task<long> Create(BookingDto booking);
        Task Delete(long id);

        Task Update(BookingDto booking);
    }
}
