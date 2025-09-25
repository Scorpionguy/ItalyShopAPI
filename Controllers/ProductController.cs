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

        // путь к эому методу: api/product/catalog
        //ВОЗМОЖНО ПРОДУКТ С БОЛЬШОЙ БУКВЫ !!!!!!!!!!!
        [HttpGet("catalog")]
        public async Task<ActionResult<GoodDTO>> GetAll()
        {
            Console.WriteLine("Дошло до catalog");
            
            try
            {

                var goods = await _goodsService.GetAllAsync();
                return Ok(goods);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при показе данных " + ex);
                return BadRequest(ex.Message);
            }
        }


        // путь к этому: api/product/article
        //article - значение артикля товара
        [HttpGet("{article}")]
        public async Task<ActionResult<IEnumerable<GoodDTO>>> GetOne(int article)
        {
            try
            {

                _logger.LogInformation($"Дошло до product/id, {article}");

                var goods = await _goodsService.GetGoodByIdAsync(article);
                return Ok(goods);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при просмотре товара" + ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<IEnumerable<GoodDTO>>> AddGood([FromBody]CreateGoodDTO newGood)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");
            try
            {
                await _goodsService.AddGoodAsync(newGood, 1);
                await _logService.AddLog($"Успешно добавлен {newGood.Model}, {newGood.GName}", "Добавление", 1 /*айди сотрудника, позже сделать почеловечески*/);
                return Ok("Товар успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении данных " + ex);
                return BadRequest(ex.Message);
            }

            

        }


    }
}
