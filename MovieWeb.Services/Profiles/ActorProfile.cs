using AutoMapper;
using MovieWeb.Domain;
using MovieWeb.Dto.Actors;

namespace MovieWeb.Services.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, GetActorDetailDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(domainModel => domainModel.FirstName + " " + domainModel.LastName));

            CreateMap<CreateActorDto, Actor>();

            CreateMap<Actor, GetActorListDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(domainModel => domainModel.FirstName + " " + domainModel.LastName));

            CreateMap<UpdateActorDto, Actor>();
        }
    }
}
