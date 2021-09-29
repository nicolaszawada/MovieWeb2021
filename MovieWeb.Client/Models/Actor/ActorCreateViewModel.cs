using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Client.Models.Actor
{
    public class ActorCreateViewModel
    {
        public int Id { get; set; }
        [DisplayName("First name")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        public string LastName { get; set; }

        [DisplayName("Birth date")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Kevin Bacon number")]
        public int KevinBaconNumber { get; set; }

        public IFormFile Photo { get; set; }
    }
}
