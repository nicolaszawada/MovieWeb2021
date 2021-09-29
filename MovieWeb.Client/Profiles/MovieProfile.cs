using AutoMapper;
using MovieWeb.Client.Models.Movie;
using MovieWeb.Dto.Movies;

namespace MovieWeb.Client.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<GetMovieDetailWithActorsDto, EditMovieViewModel>();
            CreateMap<GetMovieListDto, MovieListViewModel>();
            CreateMap<MovieCreateViewModel, CreateMovieDto>();
            CreateMap<GetTagListDto, TagListViewModel>();
        }
    }
}
