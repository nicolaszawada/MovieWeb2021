using System.Collections.Generic;

namespace MovieWeb.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
