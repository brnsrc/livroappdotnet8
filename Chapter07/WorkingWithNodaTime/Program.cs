using NodaTime; // To use SystemClock, Instant and so on.
SectionTile("Converting Noda Time types.");

//Get the current instant in time
Instant now = SystemClock.Instance.GetCurrentInstant();
WriteLine($"Now (Instant): {now}");
WriteLine();
ZonedDateTime nowInUTc = now.InUtc();
WriteLine($"Now (DateTimeZone): {nowInUTc.Zone}");
WriteLine($"Now (ZoneDateTime): {nowInUTc}");
WriteLine($"Now (DST): {nowInUTc.IsDaylightSavingTime()}");
WriteLine();

// Use the tzdb provider to get the time zone for US Pacific.
// To use .NET compatible time zones, use the Bcl provider.
DateTimeZone zonePT = DateTimeZoneProviders.Tzdb["US/Pacific"];
ZonedDateTime nowInPT = now.InZone(zonePT);
WriteLine($"Now (DateTimeZone): {nowInPT.Zone}");
WriteLine($"Now (ZoneDteTime): {nowInPT}");
WriteLine($"Now (DST): {nowInPT.IsDaylightSavingTime()}");
WriteLine();

DateTimeZone zoneUK = DateTimeZoneProviders.Tzdb["Europe/London"];
ZonedDateTime nowInUK = now.InZone(zoneUK);
WriteLine($"Now (DateTimeZone): {nowInUK.Zone}");
WriteLine($"Now (ZonedDateTime): {nowInUK}");
WriteLine($"now (DST): {nowInUK.IsDaylightSavingTime()}");
WriteLine();
LocalDateTime nowInLocal = nowInUTc.LocalDateTime;
WriteLine($"Now (LocalDateTime): {nowInLocal}");
WriteLine($"Now (LocalDate): {nowInLocal.Date}");
WriteLine($"Now (LocalTime): {nowInLocal.TimeOfDay}");

