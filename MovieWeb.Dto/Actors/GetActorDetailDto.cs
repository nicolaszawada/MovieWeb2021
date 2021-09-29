using System;

namespace MovieWeb.Dto.Actors
{
    public class GetActorDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int KevinBaconNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
    }
}
