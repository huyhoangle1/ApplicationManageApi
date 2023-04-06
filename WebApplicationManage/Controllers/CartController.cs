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

        [HttpGet("orderList")]
        public async Task<IActionResult> GetAllOrderLists()
        {
            var data = await _repo.GetAllOrder();

            return Ok(data);
        }

        [HttpGet("Order/{id}")]

        public async Task<IActionResult> GetOrderByCus(int id)
        {
            var data = await _repo.GetOrderByCustomerId(id);

            if (data == null)
            {
                return BadRequest("Order is not exist.");
            }

            return Ok(data);
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
