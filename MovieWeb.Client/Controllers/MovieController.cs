using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Client.Models.Movie;
using MovieWeb.Dto.Movies;
using MovieWeb.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Client.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly IActorService _actorService;

        public MovieController(IMovieService movieService, IMapper mapper, IActorService actorService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _actorService = actorService;
        }

        public async Task<IActionResult> Index([FromQuery] MovieIndexViewModel vm)
        {
            var movies = await _movieService.GetAsync(vm?.Filter);

            var movieVms = _mapper.Map<IEnumerable<MovieListViewModel>>(movies);
            return View(new MovieIndexViewModel() { Filter = vm?.Filter, Movies = movieVms }); ;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MovieCreateViewModel model)
        {
            var dto = _mapper.Map<CreateMovieDto>(model);

            await _movieService.CreateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetWithActorsAsync(id);
            var actors = await _actorService.GetAsync();

            var vm = _mapper.Map<EditMovieViewModel>(movie);
            vm.AllAddActors = actors.Where(x => !movie.Actors.Any(z => z.Id == x.Id)).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(x.Name, x.Id.ToString()));
            vm.AllRemoveActors = actors.Where(x => movie.Actors.Any(z => z.Id == x.Id)).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(x.Name, x.Id.ToString()));

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddActor([FromRoute] int id, [FromForm] string selectedActorId)
        {
            await _movieService.AddActorAsync(id, int.Parse(selectedActorId));
            return RedirectToAction("Edit", new { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveActor([FromRoute] int id, [FromForm] string selectedActorId)
        {
            await _movieService.RemoveActorAsync(id, int.Parse(selectedActorId));
            return RedirectToAction("Edit", new { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] EditMovieViewModel model)
        {
            return RedirectToAction("Index", "Actor");
        }

        [HttpPost]
        public async Task<IActionResult> AddTag(int id, [FromForm] string newTag)
        {
            await _movieService.AddTagAsync(id, newTag);
            return RedirectToAction("Edit", new { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTag(int id, [FromForm] int tagId)
        {
            await _movieService.DeleteTagAsync(id, tagId);
            return RedirectToAction("Edit", new { Id = id });
        }
    }
}
