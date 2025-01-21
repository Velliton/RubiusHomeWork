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
    public class RoomRepository (MyDbContext dbContext) : IRoomRepository
    {
        public async Task<long> Create(Room room)
        {
            dbContext.Rooms.Add(room);
            await dbContext.SaveChangesAsync();
            return room.RoomId;
        }

        public async Task Delete(long id)
        {
            await dbContext.Rooms.Where(x=>x.RoomId == id).ExecuteDeleteAsync();
            
        }

        public async  Task<Room> GetById(long id)
        {
            return await dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }

        public async Task<IReadOnlyCollection<Room>> GetRooms()
        {
            var result = await dbContext.Rooms.ToListAsync();
            return result.AsReadOnly();
        }

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
