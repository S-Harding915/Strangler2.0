using Microsoft.AspNetCore.Components;
using Strangler2._0.Data.Models;
using Strangler2._0.Services;

namespace Strangler2._0.Pages.Components
{
    public partial class CurrencyConverter
    {
        [Inject]
        public IBudgetService _budgetService { get; set; }
        public List<Currency> AvailableCurrency { get; set; } = new List<Currency>();

        private List<string> currencies = new() { "USD", "EUR", "GBP", "INR", "JPY" };
        private string fromCurrency = "USD";
        private string toCurrency = "EUR";
        private decimal amount = 1;
        private decimal convertedAmount = 0;

        protected override async Task OnInitializedAsync()
        {
            this.AvailableCurrency = await _budgetService.GetAllCurrency();
        }

        //protected override void OnInitialized()
        //{
        //    Convert();
        //}

        private void Convert()
        {
            // Dummy conversion logic for demo purposes
            var rate = GetConversionRate(fromCurrency, toCurrency);
            convertedAmount = amount * rate;
        }

        private decimal GetConversionRate(string from, string to)
        {
            if (from == to) return 1m;

            // Replace with actual API or logic
            return (from, to) switch
            {
                ("USD", "EUR") => 0.91m,
                ("EUR", "USD") => 1.10m,
                ("USD", "INR") => 83.0m,
                ("INR", "USD") => 0.012m,
                _ => 1.0m
            };
        }

        private void SwapCurrencies()
        {
            (fromCurrency, toCurrency) = (toCurrency, fromCurrency);
            Convert();
        }

        private void OnAmountChanged(ChangeEventArgs e)
        {
            if (decimal.TryParse(e.Value?.ToString(), out var value))
            {
                amount = value;
                Convert();
            }
        }

        // Auto convert on change
        private void OnCurrencyChanged(ChangeEventArgs e)
        {
            Convert();
        }
    }
}
