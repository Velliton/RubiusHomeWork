using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Abstractions.Repositories
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyCollection<Category>> GetCategories();

        Task<Category> GetById(long id);

        Task<long> Create(Category category);
        Task Delete(long id);

        Task Update(Category category);
    }
}
