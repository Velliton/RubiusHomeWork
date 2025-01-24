using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<RoomDto>> GetRooms();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<RoomDto> GetById(long id);
        /// <summary>
        /// Creates the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        Task<long> Create(RoomDto room);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(long id);
        /// <summary>
        /// Updates the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        Task Update(RoomDto room);
    }
}
