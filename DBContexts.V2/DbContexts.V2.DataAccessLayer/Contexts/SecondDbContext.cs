using DBContexts.V2.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContexts.V2.DataAccessLayer.Contexts
{
    public class SecondDbContext : DbContext
    {
        public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}