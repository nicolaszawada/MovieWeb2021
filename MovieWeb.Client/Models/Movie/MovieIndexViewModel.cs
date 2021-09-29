using System.Collections.Generic;

namespace MovieWeb.Client.Models.Movie
{
    public class MovieIndexViewModel
    {
        public IEnumerable<MovieListViewModel> Movies { get; set; }
        public string Filter { get; set; }
    }
}
