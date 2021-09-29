using Microsoft.AspNetCore.Mvc;
using MovieWeb.Dto.Movies;
using MovieWeb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication17.Attributes;

namespace WebApplication17.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMovieListDto>>> Get()
        {
            var movies = await _movieService.GetAsync();

            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetMovieDetailDto>> Get(int id)
        {
            var movie = await _movieService.GetAsync(id);

            return Ok(movie);
        }

        [HttpGet("{id:int}")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.moviewithactors+json")]
        public async Task<ActionResult<GetMovieDetailWithActorsDto>> GetWithActors(int id)
        {
            var movie = await _movieService.GetWithActorsAsync(id);

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<GetMovieDetailDto>> Create(CreateMovieDto dto)
        {
            if (!TryValidateModel(ModelState))
            {
                return BadRequest(ModelState);
            }

            var movie = await _movieService.CreateAsync(dto);

            return Ok(movie);
        }

        [HttpPost("{id:int}/actors")]
        public async Task<ActionResult> AddActorToMovie(int id, [FromBody] AddActorToMovieDto dto)
        {
            if (!TryValidateModel(dto))
            {
                return BadRequest(dto);
            }

            var succeeded = await _movieService.AddActorAsync(id, dto.ActorId);

            if (succeeded)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
