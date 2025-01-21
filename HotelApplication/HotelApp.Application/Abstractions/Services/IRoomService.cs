using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    public interface IRoomService
    {
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<RoomDto>> GetRooms();

        Task<RoomDto> GetById(long id);

        Task<long> Create(RoomDto room);
        Task Delete(long id);

        Task Update(RoomDto room);
    }
}
