using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationManage.Data;
using WebApplicationManage.models.Producer;
using WebApplicationManage.models.User;
using WebApplicationManage.Repositories;

namespace WebApplicationManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerRepository _repo;
        private readonly IMapper _mapper;

        public ProducerController(IProducerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetProducers()
        {
            var data = await _repo.GetProducersAsync();

            return Ok(data);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetProducerById(int id)
        {
            var data = await _repo.GetProducerById(id);

            if (data == null)
            {
                return BadRequest("Producer is not exist.");
            }

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducer(int id, ProducerDto producer)
        {
            var result = await _repo.UpdateProducerAsync(id, producer);

            if (!result)
            {
                return BadRequest("Errors.");
            }

            return Ok("Updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            var result = await _repo.DeleteProducerAsync(id);

            if (!result)
            {
                return BadRequest("Errors.");
            }

            return Ok("Deleted.");
        }

        [Authorize]
        [HttpPost("addProducer")]
        public async Task<IActionResult> AddProducer(ProducerDto dto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
            int producerId = int.Parse(userId);
            var result = await _repo.AddProducer(dto, producerId);

            if (result)
            {
                return Ok(new
                {
                    message = "Producer is created."
                });
            }

            return BadRequest("Something is error.");
        }

    }
}
