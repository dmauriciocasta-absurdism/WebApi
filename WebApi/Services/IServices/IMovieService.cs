using WebApi.DAL.Models;
using WebApi.DAL.Models.Dtos;

namespace WebApi.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();

        Task<MovieDto?> GetMovieAsync(int Id);

        Task<bool> CreateMovieAsync(MovieCreateDto movieDto);

        Task<bool> UpdateMovieAsync(int Id, MovieUpdateDto movieDto);

        Task<bool> DeleteMovieAsync(int Id);

        Task<bool> MovieExistsByNameAsync(string Name);

    }
}
