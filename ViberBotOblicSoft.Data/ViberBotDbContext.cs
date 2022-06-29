using Microsoft.EntityFrameworkCore;
using ViberBotOblicSoft.Domain.Models;

namespace ViberBotOblicSoft.Data
{
    public class ViberBotDbContext : DbContext
    {
        public ViberBotDbContext(DbContextOptions<ViberBotDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Jorney>().HasNoKey().ToView(null);
            modelBuilder.Entity<Jorney>().Property("Distance").HasColumnType("decimal").HasPrecision(3);
        }
    }
}
