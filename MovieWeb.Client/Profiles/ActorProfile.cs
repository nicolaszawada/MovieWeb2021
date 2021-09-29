using AutoMapper;
using MovieWeb.Client.Models.Actor;
using MovieWeb.Dto.Actors;

namespace MovieWeb.Client.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<GetActorListDto, ActorListViewModel>();
            CreateMap<GetActorDetailDto, ActorDetailViewModel>();
            CreateMap<ActorCreateViewModel, CreateActorDto>();
            CreateMap<GetActorDetailDto, ActorDeleteViewModel>();
        }
    }
}
