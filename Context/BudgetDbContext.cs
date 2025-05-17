using Microsoft.EntityFrameworkCore;
using Strangler2._0.Data.Models;

namespace Strangler2._0.Context
{
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    Code = "ZAR",
                    Name = "Randellas",
                    Symbol = "R"
                },
                new Currency
                {
                    Id = 2,
                    Code = "USD",
                    Name = "Trump Dorra",
                    Symbol = "$"
                },
                new Currency
                {
                    Id = 3,
                    Code = "GBP",
                    Name = "Over the Pond Money",
                    Symbol = "£"
                });
        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<BudgetEntry> BudgetEntry { get; set; }
        public DbSet<Budget> Budget { get; set; }
    }
}
