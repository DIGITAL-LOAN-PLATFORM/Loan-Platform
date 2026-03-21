using MudBlazor;

public class MyCustomTheme : MudTheme
{
    public MyCustomTheme()
    {
        PaletteLight = new PaletteLight()
        {
            // Primary Branding (Deep Teal)
            Primary = "#52796f",
            PrimaryDarken = "#426159",
            PrimaryLighten = "#6d9c90",

            // Secondary Branding (Muted Teal)
            Secondary = "#84a98c",
            
            // Tertiary / Accents (Ash Grey)
            Tertiary = "#cad2c5",
            
            // Surfaces & Backgrounds
            Background = "#f4f6f3",      // Ash Grey 900 (Very light off-white)
            Surface = "#ffffff",
            AppbarBackground = "#2f3e46", // Charcoal Blue (Great for headers)
            AppbarText = "#f4f6f3",
            DrawerBackground = "#eaede8", // Ash Grey 800
            DrawerText = "#2f3e46",
            
            // Typography & Interaction
            TextPrimary = "#2f3e46",     // Charcoal Blue
            TextSecondary = "#354f52",   // Dark Slate Grey
            ActionDefault = "#52796f",
            Divider = "#dfe4dc",         // Ash Grey 700
            
            Info = "#527a7e",            // Slate Blue/Grey tint
            Success = "#84a98c",         // Muted Teal
        };

        PaletteDark = new PaletteDark()
        {
            // Dark Mode Surfaces (Charcoal Blue & Dark Slate)
            Background = "#090c0e",      // Charcoal Blue 100
            Surface = "#13191c",         // Charcoal Blue 200
            
            AppbarBackground = "#090c0e",
            DrawerBackground = "#13191c",

            // Primary Branding for Dark (Lighter versions of the teals)
            Primary = "#92b5ac",         // Deep Teal 700
            Secondary = "#b5ccba",       // Muted Teal 700
            Tertiary = "#a0af97",        // Ash Grey 400
            
            // Typography
            TextPrimary = "#f4f6f3",     // Ash Grey 900
            TextSecondary = "#cad2c5",   // Ash Grey 500
            Divider = "#1f2e30",         // Dark Slate Grey 300
            ActionDefault = "#b6cdc8"
        };

        LayoutProperties = new LayoutProperties()
        {
            DefaultBorderRadius = "8px"
        };
    }
}