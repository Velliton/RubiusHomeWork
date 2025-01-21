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
    public class RoomService(IRoomRepository roomRepository, IMapper mapper) : IRoomService
    {
        public Task<long> Create(RoomDto room)
        {
            var entity = mapper.Map<Room>(room); 
            return roomRepository.Create(entity);
        }

        public Task Delete(long id)
        {
            return roomRepository.Delete(id);
        }

        public async Task<RoomDto> GetById(long id)
        {
            var result = await roomRepository.GetById(id);
            return mapper.Map<RoomDto>(result); 
        }

        public async Task<IReadOnlyCollection<RoomDto>> GetRooms()
        {
            var result = await roomRepository.GetRooms();
            return mapper.Map<IReadOnlyCollection<RoomDto>>(result);
        }

        public async Task Update(RoomDto room)
        {
            var entity = mapper.Map<Room>(room);
            await roomRepository.Update(entity);
            return;
        }
    }
}
