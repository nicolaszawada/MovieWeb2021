using System;
using System.Collections.Generic;

namespace MovieWeb.Domain
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int KevinBaconNumber { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public string Photo { get; set; }
    }
}
