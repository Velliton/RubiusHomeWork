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
    public class ClientService(IClientRepository clientRepository, IMapper mapper) : IClientService
    {
        public Task<long> Create(ClientDto client)
        {
            var entity = mapper.Map<Client>(client); 
            return clientRepository.Create(entity);
        }

        public Task Delete(long id)
        {
            return clientRepository.Delete(id);
        }

        public async Task<ClientDto> GetById(long id)
        {
            var result = await clientRepository.GetById(id);
            return mapper.Map<ClientDto>(result); 
        }

        public async Task<IReadOnlyCollection<ClientDto>> GetClients()
        {
            var result = await clientRepository.GetClients();
            return mapper.Map<IReadOnlyCollection<ClientDto>>(result);
        }

        public async Task Update (ClientDto client)
        {
            var entity = mapper.Map<Client>(client);
            await clientRepository.Update(entity);
            return;
        }


    }
}
