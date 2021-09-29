using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Dto.Actors
{
    public class UpdateActorDto
    {
        [MaxLength(15)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int KevinBaconNumber { get; set; }
    }
}
