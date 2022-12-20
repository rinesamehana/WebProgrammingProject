namespace EventStreamingPlatform.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public List<Movie>? Movies { get; set; }

    }
}
