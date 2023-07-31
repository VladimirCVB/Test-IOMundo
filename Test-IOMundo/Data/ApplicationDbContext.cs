using Microsoft.EntityFrameworkCore;
using Test_IOMundo.Models;

namespace Test_IOMundo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
