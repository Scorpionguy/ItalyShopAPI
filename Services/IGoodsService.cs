using ItalyShopAPI.DTOs;
using ItalyShopAPI.Models;

namespace ItalyShopAPI.Services
{
    public interface IGoodsService
    {
        Task<IEnumerable<GoodDTO>> GetAllAsync();
        Task<GoodDTO> GetGoodByIdAsync(int article);
        Task AddGoodAsync(CreateGoodDTO good, int empId);
    }
}
