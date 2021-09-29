using MovieWeb.Dto.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Dto.Actors
{
    public class CreateActorDto
    {
        [MaxLength(15)]
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [TodayValidation]
        public DateTime BirthDate { get; set; }

        public int KevinBaconNumber { get; set; }

        public string Photo { get; set; }
    }
}
