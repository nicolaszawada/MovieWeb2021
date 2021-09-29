using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Client.Models.Actor;
using MovieWeb.Client.Models.Movie;
using MovieWeb.Dto.Actors;
using MovieWeb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWeb.Client.ViewComponents
{
    public class ActorListViewComponent : ViewComponent
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public ActorListViewComponent(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? movieId = null, bool editable = true, bool showPhoto= false)
        {
            IEnumerable<GetActorListDto> actors;

            if (movieId.HasValue)
            {
                actors = await _actorService.GetActorsFromMovie(movieId);
            }
            else
            {
                actors = await _actorService.GetAsync();
            }

            var actorsVm = _mapper.Map<IEnumerable<ActorListViewModel>>(actors);

            var vm = new ActorListViewComponentViewModel()
            {
                Actors = actorsVm,
                Editable = editable,
                ShowPhoto = showPhoto
            };

            return View(vm);
        }
    }
}
