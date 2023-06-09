﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplicationManage.Data;
using WebApplicationManage.models.Producer;
using WebApplicationManage.models.User;

namespace WebApplicationManage.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProducerRepository(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<bool> AddProducer(ProducerDto dto, int userId)
        {
            var check = await _context.Producers.AnyAsync(x => x.Name == dto.Name);
            if (check)
            {
                throw new ApplicationException("Producer is exsit!!");
            }
            var data = _mapper.Map<Producer>(dto);
            data.UserId = userId; // Thiết lập giá trị cho trường UserId
            _context.Producers.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProducerAsync(int id)
        {
            var producter = await _context.Producers.FindAsync(id);
            if(producter == null)
            {
                throw new ApplicationException("Producter Not Exist!!!");
            }
            _context.Producers.Remove(producter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProducerDto> GetProducerById(int id)
        {
            var data = await _context.Producers.FindAsync(id);

            return _mapper.Map<ProducerDto>(data);
        }
        public async Task<List<ProducerDto>> GetProducersAsync()
        {
            var data = await _context.Producers.ToListAsync();
            return _mapper.Map<List<ProducerDto>>(data);    
        }

        public async Task<bool> UpdateProducerAsync(int id, ProducerDto producer)
        {
            var data = await _context.Producers.FindAsync(id);
            if(data == null)
            {
                throw new ApplicationException("Producer Not exists");
            }
            data.Name = producer.Name;
            data.Code = producer.Code;
            data.Modified = DateTime.Now;
            data.Keyword = producer.Keyword;

            _context.Producers.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
