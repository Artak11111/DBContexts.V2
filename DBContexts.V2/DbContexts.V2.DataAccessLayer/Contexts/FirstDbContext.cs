using DBContexts.V2.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace DbContexts.V2.DataAccessLayer.Contexts
{
    public class FirstDbContext : DbContext
    {
        public FirstDbContext(DbContextOptions<FirstDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}