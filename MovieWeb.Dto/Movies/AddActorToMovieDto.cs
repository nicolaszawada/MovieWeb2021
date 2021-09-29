using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Dto.Movies
{
    public class AddActorToMovieDto
    {
        [Required]
        public int ActorId { get; set; }
    }
}
