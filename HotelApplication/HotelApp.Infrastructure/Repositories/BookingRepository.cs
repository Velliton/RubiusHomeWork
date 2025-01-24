using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Abstractions.Repositories;
using HotelApp.Domain;
using Microsoft.EntityFrameworkCore;
using HotelApp.Application.Exceptions;
namespace HotelApp.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="HotelApp.Application.Abstractions.Repositories.IBookingRepository" />
    public class BookingRepository (MyDbContext dbContext) : IBookingRepository
    {
        /// <summary>
        /// Creates the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        public async Task<long> Create(Booking booking)
        {
            dbContext.Bookings.Add(booking);
            await dbContext.SaveChangesAsync();
            return booking.BookingId;
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(long id)
        {
            await dbContext.Clients.Where(x=>x.ClientId==id).ExecuteDeleteAsync();
            
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Продукт с идентификатором {id} не найден</exception>
        public async  Task<Booking> GetById(long id)
        {
            return await dbContext.Bookings.FirstOrDefaultAsync(x => x.BookingId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }
        /// <summary>
        /// Gets the bookings.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<Booking>> GetBookings()
        {
            var result = await dbContext.Bookings.ToListAsync();
            return result.AsReadOnly();
        }
        /// <summary>
        /// Updates the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Бронирование с идентификатором {booking.BookingId} не найдено</exception>
        public async Task Update(Booking booking)
        {
            var existingBooking = await dbContext.Bookings
                .FirstOrDefaultAsync(x => x.BookingId == booking.BookingId)
                ?? throw new NotFoundException($"Бронирование с идентификатором {booking.BookingId} не найдено");

            existingBooking.CheckInDate = booking.CheckInDate;
            existingBooking.CheckOutDate = booking.CheckOutDate;
            existingBooking.ClientId = booking.ClientId;
            existingBooking.RoomId = booking.RoomId;
            existingBooking.TotalPrice = booking.TotalPrice;

            await dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Gets the bookings by room identifier asynchronous.
        /// </summary>
        /// <param name="roomId">The room identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Booking>> GetBookingsByRoomIdAsync(int roomId)
        {
            return await dbContext.Bookings.Where(b => b.RoomId == roomId).ToListAsync();
        }
    }
}
