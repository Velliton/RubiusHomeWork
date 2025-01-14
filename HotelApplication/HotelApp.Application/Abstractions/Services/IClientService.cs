using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    public interface IClientService
    {
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<ClientDto>> GetClients();

        Task<ClientDto> GetById(long id);

        Task<long> Create(ClientDto client);
        Task Delete(long id);
    }
}
