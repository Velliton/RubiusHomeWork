using Microsoft.AspNetCore.Mvc;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using HotelApp.Domain;
using HotelApp.Application.Models;
namespace HotelApp.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class RoomController(IRoomService roomService) : ControllerBase
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IReadOnlyCollection<RoomDto>> Get()
        {
            return roomService.GetRooms();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<RoomDto> GetById(long id)
        {
            return roomService.GetById(id);
        }
        /// <summary>
        /// Creates the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> Create(RoomDto room)
        {
            return roomService.Create(room);

        }
        /// <summary>
        /// Updates the room.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roomDto">The room dto.</param>
        /// <returns></returns>
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