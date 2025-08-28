using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

partial class Program
{
    private static void SectionTile(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"*** {title}");
        ForegroundColor = previousColor;
    }
}
