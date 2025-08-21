using System.Globalization;
using System.Threading.Tasks.Dataflow; //To use CultureInfo.
ConfigureConsole("en-GB"); //Defaults to pt-BR culture
// SectionTitle("Specifying date and time values");
// WriteLine($"Datetime.MinValue: {DateTime.MinValue}");
// WriteLine($"Datetime.MaxValue: {DateTime.MaxValue}");
// WriteLine($"Datetime.UnixEpoch: {DateTime.UnixEpoch}");
// WriteLine($"datetime.Now: {DateTime.Now}");
// WriteLine($"Datetime.Today: {DateTime.Today}");
// WriteLine($"Datetime.Today: {DateTime.Today:d}");
// WriteLine($"Datetime.Today: {DateTime.Today:D}");

DateTime xmas = new(year: 2025, month: 12, day: 25);
// WriteLine($"Christmas (default format): {xmas}");
// WriteLine($"Christmas (custom short format): {xmas:ddd d/M/yy}");
// WriteLine($"Christmas (custom long format): {xmas:dddd, dd MMMM yyyy}");
// WriteLine($"Christmas (standard long format): {xmas:D}");
// WriteLine($"Christmas (sortable): {xmas:u}");
// WriteLine($"Christmas is in month {xmas.Month} of the year.");
// WriteLine($"Christmas is day {xmas.DayOfYear} of {xmas.Year}");
// WriteLine($"Christmas {xmas.Year} is on a {xmas.DayOfWeek}");

// SectionTitle("Date and time calculations");
// DateTime beforXmas = xmas.Subtract(TimeSpan.FromDays(12));
// DateTime afterXmas = xmas.AddDays(12);
// WriteLine($"12 days before Christmas: {beforXmas:d}");
// WriteLine($"12 days after Christmas: {afterXmas:d}");
// TimeSpan untilXmas = xmas - DateTime.Now;
// WriteLine($"Now: {DateTime.Now}");
// WriteLine($"there are {untilXmas.Days} days and {untilXmas.Hours} hours until Christmas {xmas.Year}");
// WriteLine($"there are {untilXmas.TotalHours:N0} hours " + $"until Christmas {xmas.Year}");

// DateTime kidsWakeUp = new(
//     year: 2025, month: 12, day: 25, hour: 6, minute: 30, second: 0);

// WriteLine($"Kids wake up: {kidsWakeUp}");
// WriteLine($"The kids woke me up at {kidsWakeUp.ToShortTimeString()}");

// SectionTitle("Milli-, micro-, and nanoseconds");
// DateTime preciseTime = new(
//     year: 2022, month: 11, day: 8, hour: 12, minute: 0, second: 0,
//     millisecond: 6, microsecond: 999);

// WriteLine(
//     $"Millisecond: {preciseTime.Millisecond}, Microsecond: {preciseTime.Microsecond}, "
//        + "Nanosecond: {preciseTime.Nanosecond}");
// preciseTime = DateTime.UtcNow;

// //Nanosecond valuew will be 0 to 900 in 100 nanosecond increments.
// WriteLine(
//     $"Millisecond: {preciseTime.Millisecond}, Microsecond: {preciseTime.Microsecond}, "
//    + "Nanosecond: {preciseTime.Nanosecond}");


// SectionTitle("Globalization with dates and times");

//Same as Thread.CurrentThread.CurrentCulture.
// WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");
// string textDate = "4 July 2024";
// DateTime independenceDay = DateTime.Parse(textDate);
// WriteLine($"Text: {textDate}, DateTime: {independenceDay:d MMMM}");

// textDate = "7/4/2024"; ;
// independenceDay = DateTime.Parse(textDate);
// WriteLine($"Text: {textDate}, DateTime: {independenceDay:d MMMM}");

// //Explicitly override the current culture by setting a provider
// independenceDay = DateTime.Parse(
//     textDate, provider: CultureInfo.GetCultureInfo("en-US"));

// WriteLine($"Text: {textDate}, DateTime: {independenceDay:d MMMM}");


// for (int year = 2023; year <= 2028; year++)
// {
//     Write($"{year} is a leap year: {DateTime.IsLeapYear(year)}.");
//     WriteLine($"There are {DateTime.DaysInMonth(year: year, month: 2)}"
//         + $" days in February {year}");
// }
// WriteLine($"Is Christmas daylight saving time ? {xmas.IsDaylightSavingTime()}");
// WriteLine(
//         $"Is July 4th daylight saving time? {independenceDay.IsDaylightSavingTime()}");

SectionTitle("Localizing the DayOfWeek enum");
CultureInfo previousCulture = Thread.CurrentThread.CurrentCulture;

//Explicitly set culture to Danish (Denmark).
Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");

//DayOfWeek is not localized to Danish.
WriteLine(
    $"Culture: {Thread.CurrentThread.CurrentCulture.NativeName}, " +
        $"DayOfWeek: {DateTime.Now.DayOfWeek}");

//Use dddd format code to get day of the week localized.
WriteLine(
    $"Culture: {Thread.CurrentThread.CurrentCulture.NativeName}, " +
    $"DayOfWeek: {DateTime.Now:dddd}");

//Use GetDayName method to get day of the week localized.
WriteLine(
    $"Culture: {Thread.CurrentThread.CurrentCulture.NativeName}, " +
    $"DayOfWeek: {DateTimeFormatInfo.CurrentInfo.GetDayName(DateTime.Now.DayOfWeek)}");

Thread.CurrentThread.CurrentCulture = previousCulture;