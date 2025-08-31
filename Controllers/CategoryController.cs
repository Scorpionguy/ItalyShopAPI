using ItalyShopAPI.DTOs;
using ItalyShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItalyShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<ProductController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }


        [HttpGet("category")]
        public async Task<ActionResult<CategoryDTO>> GetAll()
        {
            Console.WriteLine("Дошло до category");

            var goods = await _categoryService.GetCategoriesAsync();
            return Ok(goods);

        }


        // путь к этому: api/product/article
        //article - значение артикля товара
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetOne(int id)
        {
            //_logger.LogInformation($"Дошло до category/id, {id}");

            var goods = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(goods);

        }

        [HttpPost("add")]
        public async Task<ActionResult<IEnumerable<CreateCategoryDTO>>> AddGood([FromBody] CreateCategoryDTO newCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _categoryService.AddNewCategory(newCategory, 1);
                return Ok("Новая категория успешно добавлена");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }


        }

    }
}
