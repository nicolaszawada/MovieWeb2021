using System.Collections.Generic;

namespace MovieWeb.Client.Models.Actor
{
    public class ActorListViewComponentViewModel
    {
        public IEnumerable<ActorListViewModel> Actors { get; set; }
        public bool Editable { get; set; } = true;
        public bool ShowPhoto { get; set; } = false;
    }
}
