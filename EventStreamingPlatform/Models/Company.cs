namespace EventStreamingPlatform.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Founded { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
