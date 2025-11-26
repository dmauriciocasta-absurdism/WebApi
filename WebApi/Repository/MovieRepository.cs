using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.DAL.Models;
using WebApi.Repository.IRepository;

namespace WebApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteMovieAsync(int Id)
        {
            var movie = await _context.Movies.FindAsync(Id);
            if (movie == null)
            {
                return false;
            }
            _context.Movies.Remove(movie);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Movie?> GetMovieByIdAsync(int Id)
        {
            return await _context.Movies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.AsNoTracking().OrderBy(c => c.Genre).ToListAsync();
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow;
             _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
