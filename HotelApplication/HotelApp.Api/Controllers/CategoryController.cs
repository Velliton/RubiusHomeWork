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
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IReadOnlyCollection<CategoryDto>> Get()
        {
            return categoryService.GetCategories();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<CategoryDto> GetById(long id)
        {
            return categoryService.GetById(id);
        }
        /// <summary>
        /// Creates the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> Create(CategoryDto category)
        {
            return categoryService.Create(category);

        }
        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="categoryDto">The category dto.</param>
        /// <returns></returns>
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