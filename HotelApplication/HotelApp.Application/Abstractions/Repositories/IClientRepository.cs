using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Abstractions.Repositories
{
    public interface IClientRepository
    {
        Task<IReadOnlyCollection<Client>> GetClients();

        Task<Client> GetById(long id);

        Task<long> Create(Client client);
        Task Delete(long id);
    }
}
