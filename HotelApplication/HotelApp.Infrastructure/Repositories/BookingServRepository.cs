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
    public class BookingServRepository(MyDbContext dbContext) : IBookingServRepository
    {
        public async Task<long> Create(BookingService bookingServ)
        {
            dbContext.BookingServices.Add(bookingServ);
            await dbContext.SaveChangesAsync();
            return bookingServ.BookingServiceId;
        }

        public async Task Delete(long id)
        {
            await dbContext.BookingServices.Where(x=>x.BookingServiceId == id).ExecuteDeleteAsync();
            
        }

        public async  Task<BookingService> GetById(long id)
        {
            return await dbContext.BookingServices.FirstOrDefaultAsync(x => x.BookingServiceId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }

        public async Task<IReadOnlyCollection<BookingService>> GetBookingServices()
        {
            var result = await dbContext.BookingServices.ToListAsync();
            return result.AsReadOnly();
        }

        public async Task Update(BookingService bookingService)
        {
            var existingEntity = await dbContext.BookingServices
                .FirstOrDefaultAsync(x => x.BookingServiceId == bookingService.BookingServiceId)
                 ?? throw new NotFoundException($"Категория с идентификатором {bookingService.BookingServiceId} не найдена");


            // Обновляем свойства
            existingEntity.BookingId = bookingService.BookingId;
            existingEntity.ServiceId = bookingService.ServiceId;
            existingEntity.Quantity = bookingService.Quantity;

            await dbContext.SaveChangesAsync();
        }


    }
}
