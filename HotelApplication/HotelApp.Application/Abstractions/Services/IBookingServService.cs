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
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<BookingServiceDto> GetById(long id);
        /// <summary>
        /// Creates the specified booking serv.
        /// </summary>
        /// <param name="bookingServ">The booking serv.</param>
        /// <returns></returns>
        Task<long> Create(BookingServiceDto bookingServ);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(long id);
        /// <summary>
        /// Updates the specified booking serv.
        /// </summary>
        /// <param name="bookingServ">The booking serv.</param>
        /// <returns></returns>
        Task Update(BookingServiceDto bookingServ);
    }
}
