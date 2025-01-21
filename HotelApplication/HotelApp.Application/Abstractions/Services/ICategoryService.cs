using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Models;

namespace HotelApp.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<CategoryDto>> GetCategories();

        Task<CategoryDto> GetById(long id);

        Task<long> Create(CategoryDto category);
        Task Delete(long id);

        Task Update(CategoryDto category);
    }
}
