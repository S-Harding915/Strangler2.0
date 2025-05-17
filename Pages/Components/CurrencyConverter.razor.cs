using Microsoft.AspNetCore.Components;
using Strangler2._0.Data.Models;
using Strangler2._0.Services;

namespace Strangler2._0.Pages.Components
{
    public partial class CurrencyConverter : ComponentBase
    {
        [Inject]
        public IBudgetService _budgetService { get; set; }
        public List<Currency> AvailableCurrency { get; set; } = new List<Currency>();

        private List<string> currencies = new() { "USD", "EUR", "GBP", "INR", "JPY" };
        private string fromCurrency = "USD";
        private string toCurrency = "EUR";
        private decimal convertedAmount = 0;
        
        private decimal _amount = 1;
        private decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    ConvertAsync();
                }
            }
        }

        private void Convert()
        {
            await ConvertAsync();
        }

        private async Task ConvertAsync()
        {
            if (fromCurrency == toCurrency)
            {
                convertedAmount = _amount;
                return;
            }

            try
            {
                var url = $"https://api.exchangerate.host/convert?from={fromCurrency}&to={toCurrency}&amount={_amount}";
                // var result = await Http.GetFromJsonAsync<ExchangeResponse>(url);
var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri($"https://api.exchangerate.host/convert?from={fromCurrency}&to={toCurrency}&amount={_amount}");
var result = await httpClient.GetAsync(httpClient.BaseAddress);

                if (result != null && result.IsSuccessStatusCode)
                {
                    var v = await result.Content.ReadAsStringAsync();
                    convertedAmount = int.Parse(v);
                }
                else
                {
                    convertedAmount = 0;
                }
            }
            catch
            {
                convertedAmount = 0; // You can log error if needed
            }
        }

        private async Task OnFromCurrencyChanged(ChangeEventArgs e)
        {
            fromCurrency = e.Value?.ToString();
            await ConvertAsync();
        }

        private async Task OnToCurrencyChanged(ChangeEventArgs e)
        {
            toCurrency = e.Value?.ToString();
            await ConvertAsync();
        }

        private async Task OnAmountChanged(ChangeEventArgs e)
        {
            if (decimal.TryParse(e.Value?.ToString(), out var value))
            {
                _amount = value;
                await ConvertAsync();
            }
        }

        private async Task SwapCurrencies()
        {
            (fromCurrency, toCurrency) = (toCurrency, fromCurrency);
            await ConvertAsync();
        }

        private class ExchangeResponse
        {
            public bool Success { get; set; }
            public decimal Result { get; set; }
        }
    }
}
