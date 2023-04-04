using WebApplicationManage.models.Product;

namespace WebApplicationManage.Repositories
{
    public interface IProductRepository
    {
        public Task<Boolean> AddProduct(ProductDto dto);
        public Task<List<ProductDto>> GetProductsAsync();
        public Task<ProductDto> GetProductById(int id);
        public Task<Boolean> UpdateProductAsync(int id, ProductDto product);
        public Task<Boolean> DeleteProductAsync(int id);
    }
}
