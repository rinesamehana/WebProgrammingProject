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
        public DbSet<EventStreamingPlatform.Models.Actor> Actor { get; set; }
        public DbSet<EventStreamingPlatform.Models.Category> Category { get; set; }
        public DbSet<EventStreamingPlatform.Models.Company> Company { get; set; }
        public DbSet<EventStreamingPlatform.Models.Movie> Movie { get; set; }
    }
}