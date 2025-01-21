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
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        public Task<long> Create(CategoryDto category)
        {
            var entity = mapper.Map<Category>(category); 
            return categoryRepository.Create(entity);
        }

        public Task Delete(long id)
        {
            return categoryRepository.Delete(id);
        }

        public async Task<CategoryDto> GetById(long id)
        {
            var result = await categoryRepository.GetById(id);
            return mapper.Map<CategoryDto>(result); 
        }

        public async Task<IReadOnlyCollection<CategoryDto>> GetCategories()
        {
            var result = await categoryRepository.GetCategories();
            return mapper.Map<IReadOnlyCollection<CategoryDto>>(result);
        }

        public async Task Update(CategoryDto category)
        {
            var entity = mapper.Map<Category>(category);
            await categoryRepository.Update(entity);
            return;
        }
    }
}
