using System.ComponentModel.DataAnnotations;

namespace Strangler2._0.Data.Models
{
    public class BudgetEntry
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double OriginalAmount { get; set; }
        public string Category { get; set; }
        public string PaymentChannel { get; set; }
        public string ExpenseCategory { get; set; }
        public string Comments { get; set; }
        public Currency Currency { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string GetMetaData { get; set; }
    }
}
