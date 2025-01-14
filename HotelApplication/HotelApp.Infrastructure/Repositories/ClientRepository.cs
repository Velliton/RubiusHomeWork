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
    public class ClientRepository (MyDbContext dbContext) : IClientRepository
    {
        public async Task<long> Create(Client client)
        {
            dbContext.Clients.Add(client);
            await dbContext.SaveChangesAsync();
            return client.ClientId;
        }

        public async Task Delete(long id)
        {
            await dbContext.Clients.Where(x=>x.ClientId==id).ExecuteDeleteAsync();
            
        }

        public async  Task<Client> GetById(long id)
        {
            return await dbContext.Clients.FirstOrDefaultAsync(x => x.ClientId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }

        public async Task<IReadOnlyCollection<Client>> GetClients()
        {
            var result = await dbContext.Clients.ToListAsync();
            return result.AsReadOnly();
        }
    }
}
