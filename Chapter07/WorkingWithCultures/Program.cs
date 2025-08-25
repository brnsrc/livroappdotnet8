
// To enable especial character like €
using System.Threading.Tasks.Dataflow;

OutputEncoding = System.Text.Encoding.UTF8;
OutputCultures("Current Culture");
WriteLine("Example ISO culture codes:");
string[] cultureCodes = {
    "da-DK", "en-GB", "en-US", "fa-IR", "fr-CA", "fr-FR", "he-IL", "pl-PL", "sl-SL" };

foreach (string code in cultureCodes)
{
    CultureInfo culture = CultureInfo.GetCultureInfo(code);
    WriteLine($" {culture.Name}: {culture.EnglishName}/{culture.NativeName}");
}

WriteLine();
Write("Enter an ISO culture code: ");
string? cultureCode = ReadLine();

if (string.IsNullOrWhiteSpace(cultureCode))
{
    cultureCode = "en-US";
}
CultureInfo ci;
try
{
    ci = CultureInfo.GetCultureInfo(cultureCode);
}
catch (CultureNotFoundException)
{

    WriteLine($"Culture code not found: {cultureCode}");
    WriteLine("Exiting the app.");

    return;
}


