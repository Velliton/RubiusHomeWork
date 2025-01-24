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
    /// <seealso cref="HotelApp.Application.Abstractions.Services.IClientService" />
    public class ClientService(IClientRepository clientRepository, IMapper mapper) : IClientService
    {
        /// <summary>
        /// Creates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        public Task<long> Create(ClientDto client)
        {
            var entity = mapper.Map<Client>(client); 
            return clientRepository.Create(entity);
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task Delete(long id)
        {
            return clientRepository.Delete(id);
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ClientDto> GetById(long id)
        {
            var result = await clientRepository.GetById(id);
            return mapper.Map<ClientDto>(result); 
        }
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<ClientDto>> GetClients()
        {
            var result = await clientRepository.GetClients();
            return mapper.Map<IReadOnlyCollection<ClientDto>>(result);
        }
        /// <summary>
        /// Updates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        public async Task Update (ClientDto client)
        {
            var entity = mapper.Map<Client>(client);
            await clientRepository.Update(entity);
            return;
        }
    }
}
