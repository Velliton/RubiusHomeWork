using Microsoft.AspNetCore.Mvc;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using HotelApp.Domain;
using HotelApp.Application.Models;
namespace HotelApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController(IRoomService roomService) : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>


        [HttpGet]
        public Task<IReadOnlyCollection<RoomDto>> Get()
        {
            return roomService.GetRooms();
        }
        [HttpGet("{id}")]
        public Task<RoomDto> GetById(long id)
        {
            return roomService.GetById(id);
        }

        [HttpPost]
        public Task<long> Create(RoomDto room)
        {
            return roomService.Create(room);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(long id, [FromBody] RoomDto roomDto)
        {
            if (id != roomDto.RoomId)
            {
                return BadRequest("Идентификатор клиента в URL не совпадает с данными.");
            }

            await roomService.Update(roomDto);
            return NoContent();
        }


    }
}