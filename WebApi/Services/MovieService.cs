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

       public async Task<bool> IMovieService.CreateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

       public async Task<bool> IMovieService.DeleteMovieAsync(int Id)
        {
            throw new NotImplementedException();
        }

        async Task<MovieDto> IMovieService.GetMovieAsync(int Id)
        {
            var movie = await _movieRepository.GetMovieAsync(Id);
            return _mapper.Map<MovieDto>(movie);
        }

         async Task<ICollection<MovieDto>> IMovieService.GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
            
        }

        Task<bool> IMovieService.UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
