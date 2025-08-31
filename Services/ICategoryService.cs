using ItalyShopAPI.DTOs;
using ItalyShopAPI.Models;

namespace ItalyShopAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task AddNewCategory(CreateCategoryDTO categoryDTO, int employeeId);
    }
}
