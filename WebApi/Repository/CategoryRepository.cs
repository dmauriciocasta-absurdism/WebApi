using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.DAL.Models;
using WebApi.Repository.IRepository;

namespace WebApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CategoryExistByIdAsync(int Id)
        {
          return await _context.Categories.AsNoTracking().AnyAsync(c => c.id == Id);
            
        }

        public async Task<bool> CategoryExistByNameAsync(string Name)
        {
            return await _context.Categories.AsNoTracking().AnyAsync(c => c.Name == Name);
        }

        public async Task<bool> CreateCategoryAsingnc(Category category)
        {
           category.CreatedDate = DateTime.UtcNow;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsingnc(int Id)
        {
            var category = await _context.Categories.FindAsync(Id);
            if (category == null)
            {
                return false;
            }   
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryAsync(int Id)
        {
            return  await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.id ==Id);
            
        }

        public async Task<bool> UpdateCategoryAsingnc(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;
             _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
