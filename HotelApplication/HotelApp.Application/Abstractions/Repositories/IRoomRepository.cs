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
        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<Room>> GetRooms();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Room> GetById(long id);
        /// <summary>
        /// Creates the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        Task<long> Create(Room room);
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
        Task Update(Room room);
    }
}
