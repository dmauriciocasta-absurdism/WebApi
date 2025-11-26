using AutoMapper;
using WebApi.DAL.Models;
using WebApi.DAL.Models.Dtos;
using WebApi.Repository.IRepository;
using WebApi.Services.IServices;

namespace WebApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        Task<bool> IMovieService.CreateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMovieService.DeleteMovieAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<Movie?> IMovieService.GetMovieByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<MovieDto>> IMovieService.GetMoviesAsync()
        {
            var movies = _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
            
        }

        Task<bool> IMovieService.UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
