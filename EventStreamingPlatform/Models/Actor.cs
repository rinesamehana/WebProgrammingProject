using System.ComponentModel.DataAnnotations;

namespace EventStreamingPlatform.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Actor_Movie>? Actors_Movies { get; set; }

    }
}
