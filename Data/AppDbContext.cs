using Microsoft.EntityFrameworkCore;
using DockerTestApp.Models;

namespace DockerTestApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
    }
}
