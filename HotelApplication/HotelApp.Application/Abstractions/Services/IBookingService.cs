using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Интерфейс сервиса для работы с бронированиями.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<BookingDto>> GetBookings();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<BookingDto> GetById(long id);
        /// <summary>
        /// Creates the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        Task<long> Create(BookingDto booking);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(long id);
        /// <summary>
        /// Updates the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        Task Update(BookingDto booking);
    }
}
