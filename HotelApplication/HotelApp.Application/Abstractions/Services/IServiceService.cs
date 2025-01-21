using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    public interface IServiceService
    {
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<ServiceDto>> GetServices();

        Task<ServiceDto> GetById(long id);

        Task<long> Create(ServiceDto service);
        Task Delete(long id);

        Task Update(ServiceDto service);
    }
}
