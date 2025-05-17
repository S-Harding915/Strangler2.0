using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using Strangler2._0.Data;

namespace Strangler2._0.Pages.Components
{
    partial class Budget
    {
        private MudMenu _contextMenu = null!;

        private string CurrencySymbol => CurrentDisplayedExpense?.CurrencySymbol ?? "R";
        private decimal BudgetAmount => CurrentDisplayedExpense?.Budget ?? 0;

        // Placeholder model
        [Parameter]
        public ExpenseModel CurrentDisplayedExpense { get; set; }


        private void EditBudget()
        {
            // Call your command or method here
            Console.WriteLine("Edit Budget clicked");
        }


        private async Task BruhOnOpenContextMenu(MouseEventArgs args)
        {
            await _contextMenu.OpenMenuAsync(args);
        }


    }
}
