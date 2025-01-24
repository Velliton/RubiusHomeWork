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
    /// <seealso cref="HotelApp.Application.Abstractions.Repositories.IBookingServRepository" />
    public class BookingServRepository(MyDbContext dbContext) : IBookingServRepository
    {
        /// <summary>
        /// Creates the specified booking serv.
        /// </summary>
        /// <param name="bookingServ">The booking serv.</param>
        /// <returns></returns>
        public async Task<long> Create(BookingService bookingServ)
        {
            dbContext.BookingServices.Add(bookingServ);
            await dbContext.SaveChangesAsync();
            return bookingServ.BookingServiceId;
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(long id)
        {
            await dbContext.BookingServices.Where(x=>x.BookingServiceId == id).ExecuteDeleteAsync();
            
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Продукт с идентификатором {id} не найден</exception>
        public async  Task<BookingService> GetById(long id)
        {
            return await dbContext.BookingServices.FirstOrDefaultAsync(x => x.BookingServiceId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }
        /// <summary>
        /// Gets the booking services.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<BookingService>> GetBookingServices()
        {
            var result = await dbContext.BookingServices.ToListAsync();
            return result.AsReadOnly();
        }
        /// <summary>
        /// Updates the specified booking service.
        /// </summary>
        /// <param name="bookingService">The booking service.</param>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Категория с идентификатором {bookingService.BookingServiceId} не найдена</exception>
        public async Task Update(BookingService bookingService)
        {
            var existingEntity = await dbContext.BookingServices
                .FirstOrDefaultAsync(x => x.BookingServiceId == bookingService.BookingServiceId)
                 ?? throw new NotFoundException($"Категория с идентификатором {bookingService.BookingServiceId} не найдена");


            existingEntity.BookingId = bookingService.BookingId;
            existingEntity.ServiceId = bookingService.ServiceId;
            existingEntity.Quantity = bookingService.Quantity;

            await dbContext.SaveChangesAsync();
        }


    }
}
