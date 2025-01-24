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
    public class ClientsController(IClientService clientService) : ControllerBase
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IReadOnlyCollection<ClientDto>> Get()
        {
            return clientService.GetClients();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<ClientDto> GetById(long id)
        {
            return clientService.GetById(id);
        }
        /// <summary>
        /// Creates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> Create(ClientDto client)
        {
            return clientService.Create(client);

        }
        /// <summary>
        /// Updates the client.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="clientDto">The client dto.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(long id, [FromBody] ClientDto clientDto)
        {
            if (id != clientDto.ClientId)
            {
                return BadRequest("Идентификатор клиента в URL не совпадает с данными.");
            }

            await clientService.Update(clientDto);
            return NoContent();
        }
    }
}