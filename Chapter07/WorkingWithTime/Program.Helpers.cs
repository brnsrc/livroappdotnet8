using System.Globalization; //To use CultureInfo.
partial class Program
{    
    private static void ConfigureConsole(string culture = "pt-BR",
        bool overrideComputerCulture = true)
    {
        // To enable special character like Euro currency symbol.
        OutputEncoding = System.Text.Encoding.UTF8;
        Thread t = Thread.CurrentThread;
        if (overrideComputerCulture)
        {
            t.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            t.CurrentUICulture = t.CurrentCulture;
        }

        CultureInfo ci = t.CurrentUICulture;
        WriteLine($"Current Culture: {ci.DisplayName}");
        WriteLine($"Short date pattern: {ci.DateTimeFormat.ShortDatePattern}");
        WriteLine($"Long date pattern: {ci.DateTimeFormat.LongDatePattern}");
        WriteLine();
    }

    private static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"{title}");
        ForegroundColor = previousColor;
    }
}