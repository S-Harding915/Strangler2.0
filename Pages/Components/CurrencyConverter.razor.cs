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
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public int SelectedFromCurrency { get; set; }
        public int SelectedToCurrency { get; set; }
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

        private async Task UpdateCurrency()
        {
            string url =
                "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_4AVLkFJ9PdR2u80AF6laS6aE29DPbwJArc1J2zAT";

        }
    }
}
