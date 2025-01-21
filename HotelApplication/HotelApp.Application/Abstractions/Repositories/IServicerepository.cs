using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Abstractions.Repositories
{
    public interface IServiceRepository
    {
        Task<IReadOnlyCollection<Service>> GetServices();

        Task<Service> GetById(long id);

        Task<long> Create(Service service);
        Task Delete(long id);

        Task<long> Update(Service service);
    }
}
