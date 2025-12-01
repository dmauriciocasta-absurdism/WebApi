using WebApi.DAL.Models;

namespace WebApi.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<CategoryDto>>GetCategoriesAsync();//retorna las categorias
        Task<Category?>GetCategoryByIdAsync(int Id);//retorna una categoria por id

        Task<bool> CategoryExistByIdAsync(int Id);//verifica si la categoria existe por id

        Task<bool> CategoryExistByNameAsync(string Name);//verifica si la categoria existe por nombre

        Task<bool> CreateCategoryAsync(CategoryCreateDto categoryDto);//crea una categoria

        Task<bool> UpdateCategoryAsingnc(Category category, int Id);//actualiza una categoria
        Task<bool> DeleteCategoryAsingnc(int Id);//elimina una categoria
    }
}
