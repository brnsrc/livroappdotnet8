ConfigureConsole("pt-BR"); //Defaults to pt-BR culture
SectionTitle("Specifying date and time values");
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

DateTime kidsWakeUp = new(
    year: 2025, month: 12, day: 25, hour: 6, minute: 30, second: 0);

WriteLine($"Kids wake up: {kidsWakeUp}");
WriteLine($"The kids woke me up at {kidsWakeUp.ToShortTimeString()}");


