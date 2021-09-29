using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieWeb.Dto.Actors;
using MovieWeb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication17.Controllers
{
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly ILogger<ActorsController> _logger;

        public ActorsController(IActorService actorService, ILogger<ActorsController> logger)
        {
            _actorService = actorService;
            _logger = logger;
        }

        /// <summary>
        /// Get list of actors 
        /// </summary>
        /// <returns>List of GetActorListDto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetActorListDto>>> Get()
        {
            _logger.LogInformation("Hello From Get Actors");

            var actors = await _actorService.GetAsync();

            return Ok(actors);
        }

        /// <summary>
        /// Get specific actor
        /// </summary>
        /// <param name="id">The database identifier</param>
        /// <returns>An GetActorDetailDto</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetActorDetailDto>> Get([FromRoute] int id)
        {
            var actor = await _actorService.GetAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateActorDto actor)
        {
            if (!TryValidateModel(actor))
            {
                return BadRequest(ModelState);
            }

            var createdActor = await _actorService.CreateAsync(actor);

            return CreatedAtAction(nameof(Get), new { Id = createdActor.Id }, createdActor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateActorDto actorDto)
        {
            if (!TryValidateModel(actorDto))
            {
                return BadRequest(ModelState);
            }

            var actorDetail = await _actorService.UpdateAsync(id, actorDto);

            if (actorDetail == null)
            {
                return NotFound();
            }

            return Ok(actorDetail);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _actorService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
