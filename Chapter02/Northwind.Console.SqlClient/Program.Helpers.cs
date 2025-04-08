using System.Collections; // To use Diction
using System.Globalization;
using Microsoft.Data.SqlClient; // To use SqlConnection

partial class Program
{
    private static void ConfigureConsole(string culture = "en-US", bool useComputerCulture = false)
    {
        //To enable Unicode character like euro symbol in the console
        OutputEncoding = System.Text.Encoding.UTF8;
        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    private static void WriteInColor(string value, ConsoleColor color = ConsoleColor.White)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = color;
        WriteLine(value);
        ForegroundColor = previousColor;
    }

    private static void OutputStatistics(SqlConnection connection)
    {
        //remove all the strings to see all the statistics.
        string[] includeKeys = {
            "BytesSent", "BytesReceived", "ConnectionTime", "SelectRows"
        };

        IDictionary statistics = connection.RetrieveStatistics();
        foreach (object? key in statistics.Keys)
        {
            if (!includeKeys.Any() || includeKeys.Contains(key))
            {
                if (int.TryParse(statistics[key]?.ToString(), out int value))
                {
                    WriteInColor($"{key}: {value:N0}", ConsoleColor.Cyan);
                }
            }
        }
    }
    
}
