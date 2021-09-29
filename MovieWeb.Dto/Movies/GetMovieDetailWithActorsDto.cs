using MovieWeb.Dto.Actors;
using System.Collections.Generic;

namespace MovieWeb.Dto.Movies
{
    public class GetMovieDetailWithActorsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public IEnumerable<GetActorListDto> Actors { get; set; }
        public IEnumerable<GetTagListDto> Tags { get; set; }
    }
}
