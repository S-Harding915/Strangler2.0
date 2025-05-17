using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Strangler2._0.Pages.Components
{
    partial class EditBudgetDialog
    {
        [Parameter] public string Title { get; set; } = "Edit Budget";

        private string _inputValue = "";

        private void Submit()
        {
            if (float.TryParse(_inputValue, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float _))
            {
                MudDialog.Close(DialogResult.Ok(_inputValue));
            }
        }

        private void HandleKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                Submit();
            }
        }
    }
}
