using AutoMapper;
using WebApi.DAL.Models;
using WebApi.DAL.Models.Dtos;
using WebApi.Repository;
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

       public async Task<MovieDto> IMovieService.CreateMovieAsync(MovieCreateDto movieCreateDto)
        {
         var movieExists =  await _movieRepository.MovieExistsByNameAsync(movieCreateDto.name);
            if (movieExists)
            {
                throw new InvalidOperationException($"Movie already exists'{movieCreateDto.Name}'");
            }

            var movie = _mapper.Map<Movie>(movieCreateDto);
            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("Creating movie failed on save");
            }
        }

       public async Task<bool> IMovieService.DeleteMovieAsync(int Id)
        {
            await GetMovieByIdAsync(id);

            var isDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!isDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la Película");
            }

            return isDeleted;
        }

       public async Task<MovieDto> IMovieService.GetMovieAsync(int Id)
        {
            var movie = await _movieRepository.GetMovieAsync(Id);
            return _mapper.Map<MovieDto>(movie);
        }

         async Task<ICollection<MovieDto>> IMovieService.GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
            
        }

       public async Task<MovieDto> IMovieService.UpdateMovieAsync(MovieCreateUpdateDto Dto, int id )
        {
            
            var existingCategory = await GetCategoryByIdAsync(id);

            var nameExists = await _movieRepository.MovieExistsByNameAsync(dto.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre de '{dto.Name}'");
            }

           
            _mapper.Map(dto, existingMovie);

          
            var isUpdated = await _movieRepository.UpdateMovieAsync(existingMovie);

            if (!isUpdated)
            {
                throw new Exception("Ocurrió un error al actualizar la Película.");
            }

            
            return _mapper.Map<MovieDto>(existingMovie);
        }
    }
}
