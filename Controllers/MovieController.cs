using _NET.Dtos.Movie;
using _NET.models;
using _NET.Services.MovieService;
using Microsoft.AspNetCore.Mvc;
using models;

namespace _NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        //interface
        private readonly IMovieService _movieService;
        // constructor to add services in here
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> Get()
        {
            return Ok(await _movieService.GetAllMovies());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMovieDto>>> GetSingle(int id)
        {
            return Ok(await _movieService.GetMovieById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> AddMovie(AddMovieDto newMovie)
        {
           
            return Ok(await _movieService.AddMovies(newMovie));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> UpdateMovie
            (UpdateMovieDto updatedMovie)
        {
            var response = await _movieService.UpdateMovie(updatedMovie);
            if (response.Data == null) {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMovieDto>>> DeleteMovie(int id)
        {
            var response = await _movieService.DeleteMovieById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
