using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationManage.models.Product;
using WebApplicationManage.Repositories;

namespace WebApplicationManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetProductAsync()
        {
            var data = await _repo.GetProductsAsync();

            return Ok(data);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductById(int id)
        {
            var data = await _repo.GetProductById(id);

            if (data == null)
            {
                return BadRequest("Product is not exist.");
            }

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto product)
        {
            var result = await _repo.UpdateProductAsync(id, product);

            if (!result)
            {
                return BadRequest("Errors.");
            }

            return Ok("Updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _repo.DeleteProductAsync(id);

            if (!result)
            {
                return BadRequest("Errors.");
            }

            return Ok("Deleted.");
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(ProductDto dto)
        {
            //var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
            //int producerId = int.Parse(userId);
            var result = await _repo.AddProduct(dto);

            if (result)
            {
                return Ok(new
                {
                    message = "Product is created."
                });
            }

            return BadRequest("Something is error.");
        }

    }
}
