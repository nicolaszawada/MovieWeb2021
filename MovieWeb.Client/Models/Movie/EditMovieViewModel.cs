using Microsoft.AspNetCore.Mvc.Rendering;
using MovieWeb.Client.Models.Actor;
using System.Collections.Generic;

namespace MovieWeb.Client.Models.Movie
{
    public class EditMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre{ get; set; }
        public int SelectedActorId { get; set; }
        public IEnumerable<SelectListItem> AllAddActors { get; set; }
        public IEnumerable<SelectListItem> AllRemoveActors { get; set; }
        public IEnumerable<TagListViewModel> Tags { get; set; }
        public string NewTag { get; set; }
    }
}
