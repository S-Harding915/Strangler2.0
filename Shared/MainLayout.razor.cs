using MudBlazor;

namespace Strangler2._0.Shared
{
    partial class MainLayout
    {
        MudTheme MyCustomTheme = new()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#0f0f0f",
                Secondary = Colors.Green.Accent4,
                AppbarBackground = Colors.Red.Default,
            },

            PaletteDark = new PaletteDark()
            {
                Primary = "#0f0f0f",
            }

            
        };
    }
}
