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
    public class ServiceRepository (MyDbContext dbContext) : IServiceRepository
    {
        public async Task<long> Create(Service service)
        {
            dbContext.Services.Add(service);
            await dbContext.SaveChangesAsync();
            return service.ServiceId;
        }

        public async Task Delete(long id)
        {
            await dbContext.Services.Where(x=>x.ServiceId==id).ExecuteDeleteAsync();
            
        }

        public async  Task<Service> GetById(long id)
        {
            return await dbContext.Services.FirstOrDefaultAsync(x => x.ServiceId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }

        public async Task<IReadOnlyCollection<Service>> GetServices()
        {
            var result = await dbContext.Services.ToListAsync();
            return result.AsReadOnly();
        }

        public async Task Update(Service service)
        {
            var existingService = await dbContext.Services
                .FirstOrDefaultAsync(x => x.ServiceId == service.ServiceId)
                ?? throw new NotFoundException($"Услуга с идентификатором {service.ServiceId} не найдена");

            existingService.ServiceName = service.ServiceName;
            existingService.Price = service.Price;

            await dbContext.SaveChangesAsync();
        }
    }
}
