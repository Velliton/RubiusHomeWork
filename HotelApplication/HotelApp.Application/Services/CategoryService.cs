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
    /// <seealso cref="HotelApp.Application.Abstractions.Services.ICategoryService" />
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        /// <summary>Creates the specified category.</summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<long> Create(CategoryDto category)
        {
            var entity = mapper.Map<Category>(category); 
            return categoryRepository.Create(entity);
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task Delete(long id)
        {
            return categoryRepository.Delete(id);
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CategoryDto> GetById(long id)
        {
            var result = await categoryRepository.GetById(id);
            return mapper.Map<CategoryDto>(result); 
        }
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<CategoryDto>> GetCategories()
        {
            var result = await categoryRepository.GetCategories();
            return mapper.Map<IReadOnlyCollection<CategoryDto>>(result);
        }
        /// <summary>
        /// Updates the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        public async Task Update(CategoryDto category)
        {
            var entity = mapper.Map<Category>(category);
            await categoryRepository.Update(entity);
            return;
        }
    }
}
