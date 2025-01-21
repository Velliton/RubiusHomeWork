using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Abstractions.Repositories
{
    public interface IRoomRepository
    {
        Task<IReadOnlyCollection<Room>> GetRooms();

        Task<Room> GetById(long id);

        Task<long> Create(Room room);
        Task Delete(long id);

        Task Update(Room room);
    }
}
