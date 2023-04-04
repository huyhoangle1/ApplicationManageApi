using WebApplicationManage.models.Category;

namespace WebApplicationManage.Repositories
{
    public interface ICategoryRepository
    {
        public Task<Boolean> AddCategory(CategoryDto dto);
        public Task<List<CategoryDto>> GetCategoriesAsync();
        public Task<CategoryDto> GetCategoryById(int id);
        public Task<Boolean> UpdateCategoryAsync(int id, CategoryDto category);
        public Task<Boolean> DeleteCategoryAsync(int id);
    }
}
