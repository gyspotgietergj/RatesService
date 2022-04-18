using Microsoft.EntityFrameworkCore;
using RatesService.Models;

namespace RatesService.Context
{
    public class RatesContext : DbContext
    {
        public RatesContext(DbContextOptions<RatesContext> options) : base(options){}

        public DbSet<FiatType> FiatTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FiatType>();
        }
    }
}
