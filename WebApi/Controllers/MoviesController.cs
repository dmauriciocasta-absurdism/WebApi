using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL.Models.Dtos;
using WebApi.Services;
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

        [HttpPost(Name = "CreateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]


        public async Task<ActionResult<MovieDto>> CreateMovieAsync([FromBody] MovieCreateDto movieCreateDto)
        {
            {
                if (!ModelState.IsValid) ;
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    var createdMovie await _movieService.CreateMovieAsync(MovieCreateDto);
                    return CreatedAtRoute("GetCategoryAsync", new { id = createdMovie.Id }, createdMovie);
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("already exists"))
                {
                    return Conflict(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating Movie");
                }
            }


    }
}
