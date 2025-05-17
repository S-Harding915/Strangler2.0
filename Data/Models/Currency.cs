using System.ComponentModel.DataAnnotations;

namespace Strangler2._0.Data.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
