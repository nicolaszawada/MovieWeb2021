using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Client.Models.Actor;
using MovieWeb.Dto.Actors;
using MovieWeb.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MovieWeb.Client.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ActorController(IActorService actorService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _actorService = actorService;
            _mapper = mapper;
            _hostingEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var actors = await _actorService.GetAsync();

            var vms = _mapper.Map<IEnumerable<ActorListViewModel>>(actors);

            return View(vms);
        }

        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorService.GetAsync(id);

            var vm = _mapper.Map<ActorDetailViewModel>(actor);

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ActorCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }
            var createDto = _mapper.Map<CreateActorDto>(model);

            if (model.Photo != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                var pathName = Path.Combine(_hostingEnvironment.WebRootPath, "pics");
                var fileNameWithPath = Path.Combine(pathName, uniqueFileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.Photo.CopyTo(stream);
                }

                createDto.Photo = "/pics/" + uniqueFileName;
            }

            await _actorService.CreateAsync(createDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetAsync(id);

            // Validate
            if (actor == null)
            {
                return View("NotFound");
            }

            var vm = _mapper.Map<ActorDeleteViewModel>(actor);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _actorService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
