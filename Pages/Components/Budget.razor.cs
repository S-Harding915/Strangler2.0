using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using Strangler2._0.Data;

namespace Strangler2._0.Pages.Components
{
    partial class Budget
    {
        private MudMenu _contextMenu;
        private bool _menuOpen = false;
        private double _menuX;
        private double _menuY;

        private bool ContextMenuVisible;

        private string CurrencySymbol => CurrentDisplayedExpense?.CurrencySymbol ?? "$";
        private decimal BudgetAmount => CurrentDisplayedExpense?.Budget ?? 0;

        // Placeholder model
        [Parameter]
        public ExpenseModel CurrentDisplayedExpense { get; set; }


        private void ShowContextMenu()
        {
            ContextMenuVisible = true;
        }

        private void EditBudget()
        {
            // Call your command or method here
            Console.WriteLine("Edit Budget clicked");
        }


        private async Task OpenContextMenu(MouseEventArgs e)
        {
            //e.PreventDefault();
            _menuX = e.ClientX;
            _menuY = e.ClientY;
            _menuOpen = true;

            await InvokeAsync(StateHasChanged); // ensure menu re-renders at new location
        }


    }
}
