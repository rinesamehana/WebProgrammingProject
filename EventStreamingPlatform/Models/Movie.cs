
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventStreamingPlatform.Models
{
    public class Movie 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
      
      

        public List<Actor_Movie>? Actors_Movies { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Categories { get; set; }
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company Companies { get; set; }
    }
}
