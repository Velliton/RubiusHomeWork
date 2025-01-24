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
    public interface IBookingRepository
    {
        /// <summary>
        /// Gets the bookings.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<Booking>> GetBookings();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Booking> GetById(long id);
        /// <summary>
        /// Creates the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        Task<long> Create(Booking booking);
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
        Task Update(Booking booking);
        /// <summary>
        /// Gets the bookings by room identifier asynchronous.
        /// </summary>
        /// <param name="roomId">The room identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<Booking>> GetBookingsByRoomIdAsync(int roomId);

    }
}
