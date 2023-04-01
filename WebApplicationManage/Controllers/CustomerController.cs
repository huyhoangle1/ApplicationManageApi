using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplicationManage.models.Customer;
using WebApplicationManage.models.User;
using WebApplicationManage.Repositories;

namespace WebApplicationManage.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CustomerController : ControllerBase
        {
            private readonly ICustomerRepository _repo;
            private readonly IMapper _mapper;

            public CustomerController(ICustomerRepository repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;
            }


            [HttpGet("")]
            public async Task<IActionResult> GetCustomer()
            {
                var data = await _repo.GetCustomerList();

                return Ok(data);
            }

        [HttpPost("login")]
                public async Task<IActionResult> Login(LoginCustomerDto dto)
                {
                    var result = await _repo.LoginCustomer(dto);

                    var user = await _repo.GetCustomerId(result.Id);

                    return Ok(_mapper.Map<CustomerDto>(user));
                }


        [HttpGet("{id}")]

            public async Task<IActionResult> GetCustomerById(int id)
            {
                var data = await _repo.GetCustomerId(id);

                if (data == null)
                {
                    return BadRequest("Customer is not exist.");
                }

                return Ok(data);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customer)
            {
                var result = await _repo.UpdateCustomerAsync(id, customer);

                if (!result)
                {
                    return BadRequest("Errors.");
                }

                return Ok("Updated.");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProducer(int id)
            {
                var result = await _repo.DeleteCustomerAsync(id);

                if (!result)
                {
                    return BadRequest("Errors.");
                }

                return Ok("Deleted.");
            }

            [HttpPost("register")]
            public async Task<IActionResult> RegisterCustomer(RegisterCustomerDto dto)
            {
                var result = await _repo.RegisterCustomer(dto);

                if (result)
                {
                    return Ok(new
                    {
                        message = "Create Account Success."
                    });
                }

                return BadRequest("Something is error.");
            }

        }
    }

