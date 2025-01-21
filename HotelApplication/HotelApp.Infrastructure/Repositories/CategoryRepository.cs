using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Abstractions.Repositories;
using HotelApp.Domain;
using Microsoft.EntityFrameworkCore;
using HotelApp.Application.Exceptions;
namespace HotelApp.Infrastructure.Repositories
{
    public class CategoryRepository (MyDbContext dbContext) : ICategoryRepository
    {
        public async Task<long> Create(Category category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task Delete(long id)
        {
            await dbContext.Categories.Where(x=>x.CategoryId==id).ExecuteDeleteAsync();
            
        }

        public async  Task<Category> GetById(long id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id)
                ?? throw new NotFoundException($"Продукт с идентификатором {id} не найден");
    
        }

        public async Task<IReadOnlyCollection<Category>> GetCategories()
        {
            var result = await dbContext.Categories.ToListAsync();
            return result.AsReadOnly();
        }

        public async Task Update(Category category)
        {
            var existingCategory = await dbContext.Categories
                .FirstOrDefaultAsync(x => x.CategoryId == category.CategoryId)
                ?? throw new NotFoundException($"Категория с идентификатором {category.CategoryId} не найдена");

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.PricePerNight = category.PricePerNight;
            existingCategory.Rooms = category.Rooms;
            await dbContext.SaveChangesAsync();
        }
    }
}
