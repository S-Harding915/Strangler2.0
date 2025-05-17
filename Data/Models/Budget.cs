using System.ComponentModel.DataAnnotations;

namespace Strangler2._0.Data.Models
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CycleEndDate { get; set; }
        public string EndDate { get; set; }
        public double BudgetAmount { get; set; }
        public Currency DataCurrency { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public List<BudgetEntry> Entries { get; set; }
    }
}
