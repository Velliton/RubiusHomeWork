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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="HotelApp.Application.Abstractions.Repositories.IRoomRepository" />
    public class RoomRepository (MyDbContext dbContext) : IRoomRepository
    {
        /// <summary>
        /// Creates the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        public async Task<long> Create(Room room)
        {
            dbContext.Rooms.Add(room);
            await dbContext.SaveChangesAsync();
            return room.RoomId;
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(long id)
        {
            await dbContext.Rooms.Where(x=>x.RoomId == id).ExecuteDeleteAsync();
            
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Продукт с идентификатором {id} не найден</exception>
        public async  Task<Room> GetById(long id)
        {
            return await dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }
        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<Room>> GetRooms()
        {
            var result = await dbContext.Rooms.ToListAsync();
            return result.AsReadOnly();
        }
        /// <summary>
        /// Updates the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <exception cref="HotelApp.Application.Exceptions.NotFoundException">Комната с идентификатором {room.RoomId} не найдена</exception>
        public async Task Update(Room room)
        {
            var existingRoom = await dbContext.Rooms
                .FirstOrDefaultAsync(x => x.RoomId == room.RoomId)
                ?? throw new NotFoundException($"Комната с идентификатором {room.RoomId} не найдена");

            existingRoom.RoomNumber = room.RoomNumber;
            existingRoom.CategoryId = room.CategoryId;
            existingRoom.Description = room.Description;

            await dbContext.SaveChangesAsync();
        }



    }
}
