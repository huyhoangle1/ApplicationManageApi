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
using WebApplicationManage.models.Category;
using WebApplicationManage.models.Customer;

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
            data.Price_ship = 30000;
            _context.Orders.Add(data);

            await _context.SaveChangesAsync();
            // save orderDetail
            int totalAmount = 0;

            foreach (var product in dto.Products)
            {
                var productId = product.ProductId;
                var orderDetail = new OrderDetail
                {
                    OrderId = data.Id,
                    ProductId = productId,
                    Count = product.Count,
                    Price = (float)GetProductPrice(product.ProductId) * product.Count,
                    Status = true
                };
                var a = await _context.Products.FindAsync(productId);
                if (a != null)
                {
                    totalAmount += (int)a.Price * product.Count;
                }
                if (product.Count > (int)a.Number)
                {
                    throw new ApplicationException("Quantity not enough");
                }
                a.Number -= product.Count;
                a.Number_buy += product.Count;

                _context.Products.Update(a);

                _context.OrderDetails.Add(orderDetail);
            }

            data.Money = totalAmount - 30000;
            _context.Orders.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<OrderAll>> GetOrderByCustomerId(int id)
        {
            var orders = await _context.Orders.Where(x => x.Customerid == id).ToListAsync();

            if (orders == null)
            {
                throw new ApplicationException("Order Not exsit!!!");
            }
            return _mapper.Map<List<OrderAll>>(orders);
        }

        public async Task<List<OrderAll>> GetAllOrder()
        {
            var data = await _context.Orders.ToListAsync();
            return _mapper.Map<List<OrderAll>>(data);
        }

        private decimal GetProductPrice(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            return product?.Price ?? 0;
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
