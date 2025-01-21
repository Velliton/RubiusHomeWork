using Microsoft.AspNetCore.Mvc;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using HotelApp.Domain;
using HotelApp.Application.Models;
namespace HotelApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController(IServiceService serviceService) : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>


        [HttpGet]
        public Task<IReadOnlyCollection<ServiceDto>> Get()
        {
            return serviceService.GetServices();
        }
        [HttpGet("{id}")]
        public Task<ServiceDto> GetById(long id)
        {
            return serviceService.GetById(id);
        }

        [HttpPost]
        public Task<long> Create(ServiceDto service)
        {
            return serviceService.Create(service);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(long id, [FromBody] ServiceDto serviceDto)
        {
            if (id != serviceDto.ServiceId)
            {
                return BadRequest("Идентификатор клиента в URL не совпадает с данными.");
            }

            await serviceService.Update(serviceDto);
            return NoContent();
        }



    }
}