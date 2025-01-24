using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Abstractions.Repositories
{

    /// <summary>
    /// 
    /// </summary>
    public interface IServiceRepository
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<Service>> GetServices();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Service> GetById(long id);
        /// <summary>
        /// Creates the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        Task<long> Create(Service service);
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
        Task Update(Service service);
    }
}
