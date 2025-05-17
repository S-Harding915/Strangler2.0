using MudBlazor;

namespace Strangler2._0.Shared
{
    partial class MainLayout
    {
        MudTheme MyCustomTheme = new()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#0b2507",
                Secondary = Colors.Green.Accent4,
                AppbarBackground = Colors.Red.Default,
            },

            PaletteDark = new PaletteDark()
            {
                Primary = "#0b2507",
            },

            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            }
        };
    }
}
