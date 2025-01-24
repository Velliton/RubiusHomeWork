using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Services;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Abstractions.Repositories;
using HotelApp.Domain;
using HotelApp.Application.Services;
using HotelApp.Application.Models;
using AutoMapper;

namespace HotelApp.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="HotelApp.Application.Abstractions.Services.IServiceService" />
    public class ServiceService(IServiceRepository serviceRepository, IMapper mapper) : IServiceService
    {
        /// <summary>
        /// Creates the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        public Task<long> Create(ServiceDto service)
        {
            var entity = mapper.Map<Service>(service); 
            return serviceRepository.Create(entity);
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task Delete(long id)
        {
            return serviceRepository.Delete(id);
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ServiceDto> GetById(long id)
        {
            var result = await serviceRepository.GetById(id);
            return mapper.Map<ServiceDto>(result); 
        }
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<ServiceDto>> GetServices()
        {
            var result = await serviceRepository.GetServices();
            return mapper.Map<IReadOnlyCollection<ServiceDto>>(result);
        }
        /// <summary>
        /// Updates the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        public async Task Update(ServiceDto service)
        {
            var entity = mapper.Map<Service>(service);
            await serviceRepository.Update(entity);
            return;
        }

    }
}
