using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationManage.models.Category;
using WebApplicationManage.models.Order;
using WebApplicationManage.Repositories;

namespace WebApplicationManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public CartController(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("addCategory")]
        public async Task<IActionResult> AddProducer(OrderDto dto)
        {
            var result = await _repo.AddOrder(dto);

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
