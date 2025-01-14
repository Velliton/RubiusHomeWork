using Microsoft.AspNetCore.Mvc;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using HotelApp.Domain;
using HotelApp.Application.Models;
namespace HotelApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController(IClientService clientService) : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>


        [HttpGet]
        public Task<IReadOnlyCollection<ClientDto>> Get()
        {
            return clientService.GetClients();
        }
        [HttpGet("{id}")]
        public Task<ClientDto> GetById(long id)
        {
            return clientService.GetById(id);
        }

        [HttpPost]
        public Task<long> Create(ClientDto client)
        {
            return clientService.Create(client);

        }

    }
}