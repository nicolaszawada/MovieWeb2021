using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieWeb.Dto.Developer;

namespace WebApplication17.Controllers
{
    [ApiController]
    [Route("api/hello")]
    public class HelloController : ControllerBase
    {
        // services.Configure<GetDeveloperDetailDto>(Configuration.GetSection("Developer"));

        private readonly GetDeveloperDetailDto _developerConfig;

        public HelloController(IOptions<GetDeveloperDetailDto> config)
        {
            _developerConfig = config.Value;
        }

        [HttpGet("world")]
        public ActionResult<string> World()
        {
            return "Hello World";
        }

        [HttpGet("developer")]
        public ActionResult<GetDeveloperDetailDto> HelloDeveloper()
        {
            return Ok(_developerConfig);
        }
    }
}
