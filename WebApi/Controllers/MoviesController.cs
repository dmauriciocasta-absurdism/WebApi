using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL.Models.Dtos;
using WebApi.Services.IServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<MovieDto>>> GetMoviesAsync()
        {
            var moviesDto = await _movieService.GetMoviesAsync();
            return Ok(moviesDto);
        }

        [HttpGet("{id:int}", Name = "GetMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
        {
            var movieDto = await _movieService.GetMovieAsync(id);
            return Ok(movieDto);
        }


    }
}
