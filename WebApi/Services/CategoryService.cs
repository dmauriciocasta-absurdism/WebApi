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

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()//lista de categorias
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<ICollection<CategoryDto>>(categories);
            
        }

         async Task<CategoryDto> ICategoryService.GetCategoryAsync(int Id)
        {
            var category = await _categoryRepository.GetCategoryAsync(Id);
            return _mapper.Map<CategoryDto>(category);
        }

        Task<bool> ICategoryService.UpdateCategoryAsingnc(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
