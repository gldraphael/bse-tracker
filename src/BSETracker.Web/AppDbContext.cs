using BSETracker.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BSETracker.Web
{
    public class AppDbContext : DbContext
    {
        public DbSet<Registration> Registrations { get; set; }

        public AppDbContext() => _ = 0;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.Migrate();
        }
    }
}
