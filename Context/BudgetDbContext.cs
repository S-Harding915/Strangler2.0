using Microsoft.EntityFrameworkCore;
using Strangler2._0.Data.Models;

namespace Strangler2._0.Context
{
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options) { }


        public DbSet<Currency> Currency { get; set; }
        public DbSet<BudgetEntry> BudgetEntry { get; set; }
        public DbSet<Budget> Budget { get; set; }
    }
}
