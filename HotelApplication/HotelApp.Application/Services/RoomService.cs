using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Services;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Abstractions.Repositories;
using HotelApp.Domain;
using HotelApp.Application.Services;
using HotelApp.Application.Models;
using AutoMapper;

namespace HotelApp.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="HotelApp.Application.Abstractions.Services.IRoomService" />
    public class RoomService(IRoomRepository roomRepository, IMapper mapper) : IRoomService
    {
        /// <summary>
        /// Creates the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        public Task<long> Create(RoomDto room)
        {
            var entity = mapper.Map<Room>(room); 
            return roomRepository.Create(entity);
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task Delete(long id)
        {
            return roomRepository.Delete(id);
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<RoomDto> GetById(long id)
        {
            var result = await roomRepository.GetById(id);
            return mapper.Map<RoomDto>(result); 
        }
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<RoomDto>> GetRooms()
        {
            var result = await roomRepository.GetRooms();
            return mapper.Map<IReadOnlyCollection<RoomDto>>(result);
        }
        /// <summary>
        /// Updates the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        public async Task Update(RoomDto room)
        {
            var entity = mapper.Map<Room>(room);
            await roomRepository.Update(entity);
            return;
        }
    }
}
