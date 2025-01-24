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
    /// <seealso cref="HotelApp.Application.Abstractions.Repositories.IClientRepository" />
    public class ClientRepository (MyDbContext dbContext) : IClientRepository
    {
        /// <summary>
        /// Creates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        public async Task<long> Create(Client client)
        {
            dbContext.Clients.Add(client);
            await dbContext.SaveChangesAsync();
            return client.ClientId;
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(long id)
        {
            await dbContext.Clients.Where(x=>x.ClientId==id).ExecuteDeleteAsync();
            
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Продукт с идентификатором {id} не найден</exception>
        public async  Task<Client> GetById(long id)
        {
            return await dbContext.Clients.FirstOrDefaultAsync(x => x.ClientId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }
        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<Client>> GetClients()
        {
            var result = await dbContext.Clients.ToListAsync();
            return result.AsReadOnly();
        }
        /// <summary>
        /// Updates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Клиент с идентификатором {client.ClientId} не найден</exception>
        public async Task Update(Client client) 
        {
            var existingClient = await dbContext.Clients
                .FirstOrDefaultAsync(x=> x.ClientId == client.ClientId)
                ?? throw new NotFoundException($"Клиент с идентификатором {client.ClientId} не найден");
            existingClient.FullName = client.FullName;
            existingClient.Email = client.Email;
            existingClient.Phone = client.Phone;

            await dbContext.SaveChangesAsync();
        }

    }
}
