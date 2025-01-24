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
    public class ServiceController(IServiceService serviceService) : ControllerBase
    {

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IReadOnlyCollection<ServiceDto>> Get()
        {
            return serviceService.GetServices();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<ServiceDto> GetById(long id)
        {
            return serviceService.GetById(id);
        }
        /// <summary>
        /// Creates the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> Create(ServiceDto service)
        {
            return serviceService.Create(service);
        }
        /// <summary>
        /// Updates the service.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="serviceDto">The service dto.</param>
        /// <returns></returns>
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