using JokeSphere.Models;
using Microsoft.EntityFrameworkCore;

namespace JokeSphere.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }  
        public DbSet<Joke> Jokes { get; set; }
    }
}