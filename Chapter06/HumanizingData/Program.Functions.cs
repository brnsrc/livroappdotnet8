using System.Globalization;
using Humanizer; //To use common Humanizer extension methods

partial class Program
{
    private static void ConfigureConsole(string culture = "pt-BR")
    {
        //To enable special character like ... (ellipsis) as a single character.
        OutputEncoding = System.Text.Encoding.UTF8;
        Thread t = Thread.CurrentThread;
        t.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        t.CurrentUICulture = t.CurrentCulture;
        WriteLine("Current culture: {0}", t.CurrentCulture.DisplayName);
        WriteLine();
    }
    private static void OutputCasings(string original)
    {
        WriteLine("Original casing: {0}", original);
        WriteLine("Lower casing: {0}", original.Transform(To.LowerCase));
        WriteLine("Upper casing: {0}", original.Transform(To.UpperCase));
        WriteLine("Title casing: {0}", original.Transform(To.TitleCase));
        WriteLine("Sentence casing: {0}", original.Transform(To.SentenceCase));
        WriteLine("Lower, then Sentence casing: {0}", original.Transform(
            To.LowerCase, To.SentenceCase));
        WriteLine();
    }
}
