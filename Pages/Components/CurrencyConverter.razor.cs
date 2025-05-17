using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Strangler2._0.Data.Models;
using Strangler2._0.Services;

namespace Strangler2._0.Pages.Components
{
    public partial class CurrencyConverter : ComponentBase
    {
        [Inject]
        public IBudgetService _budgetService { get; set; }
        public List<Currency> AvailableCurrency { get; set; } = new List<Currency>();
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
        public string SelectedFromCurrency { get; set; }
        public string SelectedToCurrency { get; set; }
        private decimal convertedAmount = 0;
        private string ConvertAmount { get; set; }
        //private string ConvertAmount
        //{
        //    get => ConvertAmount;
        //    set
        //    {
        //        if (ConvertAmount != value)
        //        {
        //            ConvertAmount = value;
        //            UpdateCurrency(); // Or await ConvertAsync() if async
        //        }
        //    }
        //}

        protected override async Task OnInitializedAsync()

        {
            this.AvailableCurrency = await this._budgetService.GetAllCurrency();
        }

        private class ExchangeResponse
        {
            public bool Success { get; set; }
            public decimal Result { get; set; }
        }

        //"GBP": 0.0418102057,
        //"USD": 0.0555358955,
        //"ZAR": 1

        private async Task UpdateCurrency()
            {
            var ratesToUSD = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
            {
                { "USD", 1.0m },
                { "ZAR", 0.054m }, // 1 ZAR = 0.054 USD
                { "EUR", 1.1m }    // 1 EUR = 1.1 USD
                // Add more as needed
            };

            if (!ratesToUSD.ContainsKey(SelectedFromCurrency) || !ratesToUSD.ContainsKey(SelectedToCurrency))
                throw new ArgumentException("Unsupported currency code.");

            decimal usdAmount = 100 * ratesToUSD[SelectedFromCurrency]; // Convert to USD
            decimal convertedAmount = usdAmount / ratesToUSD[SelectedToCurrency]; // Convert from USD to target

            Math.Round(convertedAmount, 2);
            this.convertedAmount = convertedAmount;
            //this.convertedAmount = (decimal)5.54;
        }
    }
}
