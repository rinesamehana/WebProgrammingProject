using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventStreamingPlatform.Models;

namespace EventStreamingPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventStreamingPlatform.Models.Actor> Actors { get; set; }
        public DbSet<EventStreamingPlatform.Models.Category> Categories { get; set; }
        public DbSet<EventStreamingPlatform.Models.Company> Companies { get; set; }
        public DbSet<EventStreamingPlatform.Models.Movie> Movies { get; set; }

     

        public DbSet<Actor_Movie> Actors_Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorID,
                am.MovieID
            });
            builder.Entity<Actor_Movie>().HasOne(m=>m.Movie)
                .WithMany(am=>am.Actors_Movies)
                .HasForeignKey(m=>m.MovieID);
            builder.Entity<Actor_Movie>().HasOne(m => m.Actor)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(m => m.ActorID);

            base.OnModelCreating(builder);
        }
    }
}