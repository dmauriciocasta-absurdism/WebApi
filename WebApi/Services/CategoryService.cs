using AutoMapper;
using WebApi.DAL.Models;
using WebApi.DAL.Models.Dtos;
using WebApi.Repository.IRepository;
using WebApi.Services.IServices;

namespace WebApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        Task<bool> ICategoryService.CategoryExistByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryService.CategoryExistByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryService.CreateCategoryAsingnc(Category category)
        {
            
        }

        Task<bool> ICategoryService.DeleteCategoryAsingnc(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<ICollection<CategoryDto>>(categories);
            
        }

        Task<Category?> ICategoryService.GetCategoryByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryService.UpdateCategoryAsingnc(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
