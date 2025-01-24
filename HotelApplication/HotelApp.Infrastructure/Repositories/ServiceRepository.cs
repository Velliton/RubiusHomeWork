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
    /// <seealso cref="HotelApp.Application.Abstractions.Repositories.IServiceRepository" />
    public class ServiceRepository (MyDbContext dbContext) : IServiceRepository
    {
        /// <summary>
        /// Creates the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        public async Task<long> Create(Service service)
        {
            dbContext.Services.Add(service);
            await dbContext.SaveChangesAsync();
            return service.ServiceId;
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(long id)
        {
            await dbContext.Services.Where(x=>x.ServiceId==id).ExecuteDeleteAsync();
            
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Продукт с идентификатором {id} не найден</exception>
        public async  Task<Service> GetById(long id)
        {
            return await dbContext.Services.FirstOrDefaultAsync(x => x.ServiceId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<Service>> GetServices()
        {
            var result = await dbContext.Services.ToListAsync();
            return result.AsReadOnly();
        }
        /// <summary>
        /// Updates the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Услуга с идентификатором {service.ServiceId} не найдена</exception>
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
