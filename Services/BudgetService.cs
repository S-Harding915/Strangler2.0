using Microsoft.EntityFrameworkCore;
using Strangler2._0.Context;
using Strangler2._0.Data.Models;

namespace Strangler2._0.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly BudgetDbContext _dbContext;

        public BudgetService(BudgetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Currency>> GetAllCurrency()
        {
            try
            {
                using var dbContext = _dbContext;
                var result = await dbContext.Currency.ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
