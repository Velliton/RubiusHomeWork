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
    public interface IClientRepository
    {
        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<Client>> GetClients();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Client> GetById(long id);
        /// <summary>
        /// Creates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        Task<long> Create(Client client);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(long id);
        /// <summary>
        /// Updates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        Task Update(Client client);
    }
}
