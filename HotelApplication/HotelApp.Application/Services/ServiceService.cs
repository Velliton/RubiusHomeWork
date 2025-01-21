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
    public class ServiceService(IServiceRepository serviceRepository, IMapper mapper) : IServiceService
    {
        public Task<long> Create(ServiceDto service)
        {
            var entity = mapper.Map<Service>(service); 
            return serviceRepository.Create(entity);
        }

        public Task Delete(long id)
        {
            return serviceRepository.Delete(id);
        }

        public async Task<ServiceDto> GetById(long id)
        {
            var result = await serviceRepository.GetById(id);
            return mapper.Map<ServiceDto>(result); 
        }

        public async Task<IReadOnlyCollection<ServiceDto>> GetServices()
        {
            var result = await serviceRepository.GetServices();
            return mapper.Map<IReadOnlyCollection<ServiceDto>>(result);
        }

        public async Task Update(ServiceDto service)
        {
            var entity = mapper.Map<Service>(service);
            await serviceRepository.Update(entity);
            return;
        }

    }
}
