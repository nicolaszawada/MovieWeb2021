using AutoMapper;
using MovieWeb.Domain;
using MovieWeb.Dto.Movies;

namespace MovieWeb.Services.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, GetMovieDetailDto>();
            CreateMap<Movie, GetMovieDetailWithActorsDto>();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Movie, GetMovieListDto>();
            CreateMap<Tag, GetTagListDto>();
        }
    }
}
