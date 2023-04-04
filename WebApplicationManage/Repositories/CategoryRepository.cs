using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationManage.Data;
using WebApplicationManage.models.Category;
using WebApplicationManage.models.Producer;

namespace WebApplicationManage.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CategoryRepository(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<bool> AddCategory(CategoryDto dto)
        {
            var check = await _context.Categories.AnyAsync(x => x.Name == dto.Name);
            if (check)
            {
                throw new ApplicationException("Category is exsit!!");
            }
            var data = _mapper.Map<Category>(dto);
            _context.Categories.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new ApplicationException("Category Not Exist!!!");
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var data = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryDto>>(data);
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var data = await _context.Categories.FindAsync(id);

            return _mapper.Map<CategoryDto>(data);
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryDto category)
        {
            var data = await _context.Categories.FindAsync(id);
            if (data == null)
            {
                throw new ApplicationException("Category Not exists");
            }
            data.Name = category.Name;
            data.Link = category.Link;
            data.Level = category.Level;
            data.ParentId= category.ParentId;

            _context.Categories.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
