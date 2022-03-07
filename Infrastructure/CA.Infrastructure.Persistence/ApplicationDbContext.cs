using CA.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}