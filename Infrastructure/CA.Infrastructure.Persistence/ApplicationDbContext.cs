using CA.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }
    }
}