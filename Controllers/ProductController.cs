using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItalyShopAPI.Services;
using ItalyShopAPI.Models;
using System.Threading.Tasks;
using ItalyShopAPI.DTOs;

namespace ItalyShopAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IGoodsService _goodsService;  
        private readonly ILogService _logService;

        public ProductController(ILogger<ProductController> logger, IGoodsService goodsService, ILogService logService)
        {
            _logger = logger;
            _goodsService = goodsService;
            _logService = logService;
        }


        //[HttpGet(Name = "GetProduct")]
        //public ActionResult<Product> Get()
        //{
        //    Console.WriteLine("Дошло до гета");

        //    var products = Enumerable.Range(1, 3).Select(index => new Product
        //    {
        //        id = index,
        //        category = categories[Random.Shared.Next(categories.Length)],
        //        name = names[Random.Shared.Next(names.Length)],
        //        price = Random.Shared.Next(1, 10000)
        //    })
        //    .ToArray();
        //    return Ok(products);

        //}


        // путь к эому методу: api/product/catalog
        //ВОЗМОЖНО ПРОДУКТ С БОЛЬШОЙ БУКВЫ !!!!!!!!!!!
        [HttpGet("catalog")]
        public async Task<ActionResult<GoodDTO>> GetAll()
        {
            Console.WriteLine("Дошло до catalog");
            
            var goods = await _goodsService.GetAllAsync();
            return Ok(goods);

        }


        // путь к этому: api/product/article
        //article - значение артикля товара
        [HttpGet("{article}")]
        public async Task<ActionResult<IEnumerable<GoodDTO>>> GetOne(int article)
        {
            _logger.LogInformation($"Дошло до product/id, {article}");
            
            var goods = await _goodsService.GetGoodByIdAsync(article);
            return Ok(goods);

        }

        [HttpPost("add")]
        public async Task<ActionResult<IEnumerable<GoodDTO>>> AddGood([FromBody]CreateGoodDTO newGood)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _goodsService.AddGoodAsync(newGood, 1);
                await _logService.AddLog($"Успешно добавлен {newGood.Model}, {newGood.GName}", "Добавление", 1 /*айди сотрудника, позже сделать почеловечески*/);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении данных " + ex);
                return BadRequest(ModelState);
            }

            

        }


    }
}
