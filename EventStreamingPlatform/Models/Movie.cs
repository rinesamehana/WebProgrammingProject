using System.ComponentModel.DataAnnotations.Schema;

namespace EventStreamingPlatform.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public List<Category>? Categories { get; set; }


    }
}
