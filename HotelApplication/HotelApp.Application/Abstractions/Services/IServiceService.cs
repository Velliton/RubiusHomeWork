using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServiceService
    {
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<ServiceDto>> GetServices();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ServiceDto> GetById(long id);
        /// <summary>
        /// Creates the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        Task<long> Create(ServiceDto service);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(long id);
        /// <summary>
        /// Updates the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        Task Update(ServiceDto service);
    }
}
