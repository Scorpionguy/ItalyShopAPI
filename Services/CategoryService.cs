using ItalyShopAPI.Data;
using ItalyShopAPI.DTOs;
using ItalyShopAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ItalyShopAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ItalyShopDbContext _dbContext;
        public CategoryService(ItalyShopDbContext db)
        {
            _dbContext = db;
        }
        async public Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            List<CategoryDTO> categories = await _dbContext.Categories
                .Select(g => new CategoryDTO()
            {
                Id = g.idCategory,
                Title = g.title
            }).ToListAsync();
            return categories;
        }

        async public Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _dbContext.Categories
                .Where(c => c.idCategory == id)
                .Select(c => new CategoryDTO
                {
                    Id = c.idCategory,
                    Title = c.title
                })
                .FirstOrDefaultAsync();

            if(category != null)
            {
                return category;
            }
            return new CategoryDTO() {Title = "Категория не найдена" };
        }

        async public Task AddNewCategory(CreateCategoryDTO categoryDTO, int employeeId)
        {
            await _dbContext.Categories.AddAsync(new Category()
            {
                title = categoryDTO.Title,
            });
        } 
    }
}
