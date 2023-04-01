using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using WebApplicationManage.Data;
using WebApplicationManage.models.Customer;

namespace WebApplicationManage.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CustomerRepository(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new ApplicationException("Customer Not Exsit!");
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerDto> GetCustomerId(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new ApplicationException("Customer Not exsit!!!");
            }
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetCustomerList()
        {
            var data = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDto>>(data);
        }

        public async Task<CustomerDto> LoginCustomer(LoginCustomerDto dto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Email== dto.Email);
            if (customer == null || !BCrypt.Net.BCrypt.Verify(dto.Password, customer.Password))
            {
                throw new ApplicationException("Email or Password is not correct");
            }
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<bool> RegisterCustomer(RegisterCustomerDto dto)
        {
            var exist = await _context.Customers.AnyAsync(x => x.Email== dto.Email);
            if (exist)
            {
                throw new ApplicationException("Email is exist!!!");
            }
            var customer = _mapper.Map<Customer>(dto);
            _context.Customers.Add(customer);
            string toAddress = dto.Email;
            string subject = "Đăng ký thành công";
            string body = "Chào mừng bạn đến với trang web của chúng tôi!";

            // Cấu hình SmtpClient
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:PassWord"]),
                EnableSsl = true
            };

            // Tạo message và gửi
            var fromAddress = new MailAddress(_configuration["Mail:UserName"], "Web");
            string a = fromAddress.ToString();
            var message = new MailMessage(a, toAddress, subject, body);
            await smtpClient.SendMailAsync(message);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerAsync(int id, CustomerDto customer)
        {
            var user = await _context.Customers.FindAsync(id);
            if(user == null) { 
                throw new ApplicationException("Customer Not exsit");
            }
            user.FullName = customer.FullName;
            user.Email = customer.Email;
            user.Address = customer.Address;
            user.Phone = customer.Phone;

            _context.Customers.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
