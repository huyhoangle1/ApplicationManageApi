using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using WebApplicationManage.Data;
using WebApplicationManage.models.Order;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;

namespace WebApplicationManage.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public OrderRepository(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<bool> AddOrder(OrderDto dto)
        {
            var check =await _context.Customers.AnyAsync(x => x.Email == dto.Email);
            if (!check)
            {
                var customer = _mapper.Map<Customer>(dto);
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }
            var id = (await _context.Customers.FirstOrDefaultAsync(x => x.Email == dto.Email))?.Id;
            var data = _mapper.Map<Order>(dto);
            data.Customerid = (int)id;
            data.OrderCode = RandomCode();
            _context.Orders.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        private string RandomCode()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            /* 
             example 1
             var orderCode = new StringBuilder(6);
             for (int i = 0; i < 6; i++)
             {
                 orderCode.Append(chars[random.Next(chars.Length)]);
             }
             return orderCode.ToString(); */
            //example 2
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }
    }
}
