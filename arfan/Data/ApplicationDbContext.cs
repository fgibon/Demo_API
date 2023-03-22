using arfan.Models;
using Microsoft.EntityFrameworkCore;

namespace arfan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Reserve> Reserve { get; set; }
        public DbSet<RelServicesEmployee> RelServicesEmployee { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<LogMessage> LogMensaje { get; set; }
    }
}
