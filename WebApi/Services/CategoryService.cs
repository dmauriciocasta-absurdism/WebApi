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

        public async Task<CategoryDto> ICategoryService.CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
         var categoryExists =   await _categoryRepository.CategoryExistByNameAsync(categoryCreateDto.Name);
            if (categoryExists)
            {
                throw new InvalidOperationException($"Category already exists'{categoryCreateDto.Name}'");
            }

            var category = _mapper.Map<Category>(categoryCreateDto);
           var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Error creating category");
            }
        }

        public async Task<bool> ICategoryService.DeleteCategoryAsync(int Id)
        {
            await GetCategoryByIdAsync(id);

            var isDeleted = await _categoryRepository.DeleteCategoryAsync(id);

            if (!isDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la categoría.");
            }

            return isDeleted;
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()//lista de categorias
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<ICollection<CategoryDto>>(categories);
            
        }

       public  async Task<CategoryDto> ICategoryService.GetCategoryAsync(int Id)
        {
            var category = await _categoryRepository.GetCategoryAsync(Id);
            return _mapper.Map<CategoryDto>(category);
        }

     public async   Task<bool> ICategoryService.UpdateCategoryAsingnc(Category category)
        {
        
            var existingCategory = await GetCategoryByIdAsync(id);

            var nameExists = await _categoryRepository.CategoryExistsByNameAsync(dto.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{dto.Name}'");
            }


            _mapper.Map(dto, existingCategory);

 
            var isUpdated = await _categoryRepository.UpdateCategoryAsync(existingCategory);

            if (!isUpdated)
            {
                throw new Exception("Ocurrió un error al actualizar la categoría.");
            }

            return _mapper.Map<CategoryDto>(existingCategory);
        }
    }
}
