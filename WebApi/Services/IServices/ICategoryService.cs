using WebApi.DAL.Models;
using WebApi.DAL.Models.Dtos;

namespace WebApi.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto?> GetCategoryAsync(int Id);

        Task<bool> CategoryExistByIdAsync(int Id);

        Task<bool> CategoryExistByNameAsync(string Name);

        Task<bool> CreateCategoryAsingnc(Category category);

        Task<bool> UpdateCategoryAsingnc(Category category);
        Task<bool> DeleteCategoryAsingnc(int Id);
    }
}
