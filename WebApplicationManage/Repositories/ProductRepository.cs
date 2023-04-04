using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationManage.Data;
using WebApplicationManage.models.Producer;
using WebApplicationManage.models.Product;

namespace WebApplicationManage.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public ProductRepository (DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<bool> AddProduct(ProductDto dto)
        {
           var check = await _context.Products.AnyAsync(x => x.Name== dto.Name);
            if (check)
            {
                throw new ApplicationException("Product is esxit!!");
            }
            var data = _mapper.Map<Product>(dto);
            _context.Products.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new ApplicationException("Product Not Exist!!!");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var data = await _context.Products.FindAsync(id);

            return _mapper.Map<ProductDto>(data);
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var data = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(data);
        }

        public async Task<bool> UpdateProductAsync(int id, ProductDto product)
        {
            var data = await _context.Products.FindAsync(id);
            if (data == null)
            {
                throw new ApplicationException("Product Not exists");
            }
            data.Name = product.Name;
            data.CatId = product.CatId;
            data.Avatar= product.Avatar;
            data.Image = product.Image;
            data.SortDesc = product.SortDesc;
            data.Detail = product.Detail;
            data.Producer = product.Producer;
            data.Number = product.Number;
            data.Number_buy= product.Number_buy;
            data.Price_sale= product.Price_sale;
            data.Price= product.Price;
            data.Sale= product.Sale;
            data.Modified = DateTime.Now;

            _context.Products.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
