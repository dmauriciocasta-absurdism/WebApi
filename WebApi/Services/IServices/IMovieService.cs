using WebApi.DAL.Models;
using WebApi.DAL.Models.Dtos;

namespace WebApi.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();

        Task<MovieDto?> GetMovieByIdAsync(int Id);

        Task<bool> CreateMovieAsync(Movie movie);

        Task<bool> UpdateMovieAsync(Movie movie);

        Task<bool> DeleteMovieAsync(int Id);
    }
}
