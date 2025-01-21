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
    public class BookingRepository (MyDbContext dbContext) : IBookingRepository
    {
        public async Task<long> Create(Booking booking)
        {
            dbContext.Bookings.Add(booking);
            await dbContext.SaveChangesAsync();
            return booking.BookingId;
        }

        public async Task Delete(long id)
        {
            await dbContext.Clients.Where(x=>x.ClientId==id).ExecuteDeleteAsync();
            
        }

        public async  Task<Booking> GetById(long id)
        {
            return await dbContext.Bookings.FirstOrDefaultAsync(x => x.BookingId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }

        public async Task<IReadOnlyCollection<Booking>> GetBookings()
        {
            var result = await dbContext.Bookings.ToListAsync();
            return result.AsReadOnly();
        }

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

    }
}
