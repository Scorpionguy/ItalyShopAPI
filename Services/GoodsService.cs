using ItalyShopAPI.Data;
using ItalyShopAPI.DTOs;
using ItalyShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItalyShopAPI.Services
{
    public class GoodsService : IGoodsService
    {
        private readonly ItalyShopDbContext _dbContext;
        public GoodsService(ItalyShopDbContext db)
        {
            _dbContext = db;
        }


        async public Task<IEnumerable<GoodDTO>> GetAllAsync()
        {
            var goods = await _dbContext.Goods
            .Include(g => g.category)
            .Select(g => new GoodDTO
            {
                Article = g.article,
                Name = g.gName,
                Model = g.model,
                Price = g.price,
                IsNew = g.isNew,
                Image = g.image,
                CategoryName = g.category != null ? g.category.title : null
            }).ToListAsync();
            foreach(var good in goods)
            {
                Console.WriteLine(good.Name);
            }
            return goods;
        }
       
        async public Task<GoodDTO> GetGoodByIdAsync(int article)
        {
            var goodById = await _dbContext.Goods
                .Include(g => g.category)
                .Where(g => g.article == article)
                .Select(g => new GoodDTO
            {
                Article = g.article,
                Name = g.gName,
                Model = g.model,
                Price = g.price,
                IsNew = g.isNew,
                Image = g.image,
                CategoryName = g.category.title
            }).FirstOrDefaultAsync();

            Console.WriteLine(goodById);
            if (goodById != null)
            {
                return goodById!;
            }

            return new GoodDTO() {Name = "Товар не найден" };
        }

        async public Task AddGoodAsync(CreateGoodDTO good, int empId)
        {
            await _dbContext.Goods.AddAsync(new Good()
            {
                gName = good.GName,
                model = good.Model,
                price = good.Price,
                isNew = good.IsNew,
                image = good.Image,
                categoryFk = good.CategoryFk
            });
            //не понимаю в чем суть, надо будет посмотреть на данные которые будет передавать Денчик.
        }

    }
}
