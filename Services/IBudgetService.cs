using Strangler2._0.Data.Models;

namespace Strangler2._0.Services
{
    public interface IBudgetService
    {
        Task<List<Currency>> GetAllCurrency();
    }
}
