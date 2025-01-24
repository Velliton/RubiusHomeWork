using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Abstractions.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookingServRepository
    {
        /// <summary>
        /// Gets the booking services.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<BookingService>> GetBookingServices();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<BookingService> GetById(long id);
        /// <summary>
        /// Creates the specified booking serv.
        /// </summary>
        /// <param name="bookingServ">The booking serv.</param>
        /// <returns></returns>
        Task<long> Create(BookingService bookingServ);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(long id);
        /// <summary>
        /// Updates the specified booking service.
        /// </summary>
        /// <param name="bookingService">The booking service.</param>
        /// <returns></returns>
        Task Update(BookingService bookingService);
    }
}
