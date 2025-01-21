using Microsoft.AspNetCore.Mvc;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using HotelApp.Domain;
using HotelApp.Application.Models;
namespace HotelApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>


        [HttpGet]
        public Task<IReadOnlyCollection<CategoryDto>> Get()
        {
            return categoryService.GetCategories();
        }
        [HttpGet("{id}")]
        public Task<CategoryDto> GetById(long id)
        {
            return categoryService.GetById(id);
        }

        [HttpPost]
        public Task<long> Create(CategoryDto category)
        {
            return categoryService.Create(category);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(long id, [FromBody] CategoryDto categoryDto)
        {
            if (id != categoryDto.CategoryId)
            {
                return BadRequest("Идентификатор клиента в URL не совпадает с данными.");
            }

            await categoryService.Update(categoryDto);
            return NoContent();
        }


    }
}