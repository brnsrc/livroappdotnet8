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