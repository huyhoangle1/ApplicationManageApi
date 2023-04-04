
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationManage.models.Category;
using WebApplicationManage.Repositories;

namespace WebApplicationManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CatagoryController(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetCatagoryAsync()
        {
            var data = await _repo.GetCategoriesAsync();

            return Ok(data);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetProducerById(int id)
        {
            var data = await _repo.GetCategoryById(id);

            if (data == null)
            {
                return BadRequest("Category is not exist.");
            }

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto category)
        {
            var result = await _repo.UpdateCategoryAsync(id, category);

            if (!result)
            {
                return BadRequest("Errors.");
            }

            return Ok("Updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _repo.DeleteCategoryAsync(id);

            if (!result)
            {
                return BadRequest("Errors.");
            }

            return Ok("Deleted.");
        }

        [HttpPost("addCategory")]
        public async Task<IActionResult> AddProducer(CategoryDto dto)
        {
           // var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
          //  int producerId = int.Parse(userId);
            var result = await _repo.AddCategory(dto);

            if (result)
            {
                return Ok(new
                {
                    message = "Success."
                });
            }

            return BadRequest("Something is error.");
        }

    }
}
