namespace MovieWeb.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
