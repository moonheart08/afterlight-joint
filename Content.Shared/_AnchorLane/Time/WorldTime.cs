namespace Content.Shared._AnchorLane.Time;

public record struct WorldTime(TimeSpan Span)
{
    /// <summary>
    /// Days in a year.
    /// </summary>
    public const int DaysInYear = 360;
    public const int DaysInMonth = DaysInYear / 10;
    /// <summary>
    /// The offset from year 1.
    /// </summary>
    /// <remarks>This is distinctly not an offset from real-time, the years component of real time is discarded in the calculation.</remarks>
    public const int YearOffset = 16;
    /// <summary>
    /// The offset in minutes from the real clock.
    /// </summary>
    /// <remarks>This is applied alongside year offset and day offset, so they sum to create the real offset.</remarks>
    public const int MinuteOffset = 347;
    /// <summary>
    /// The offset in days from the real clock.
    /// </summary>
    /// <remarks>
    /// This is applied alongside year offset and day offset, so they sum to create the real offset.
    /// Number chosen by fair dice roll, guaranteed to be random.
    /// </remarks>
    public const int DayOffset = 173;

    public static IReadOnlyList<string> Months = new List<string>
    {

    };

    /// <summary>
    /// The current world time, relative to local clock.
    /// </summary>
    /// <remarks>This is based on the LOCAL MACHINE's UtcNow. Do not use for networking!</remarks>
    public static WorldTime Now()
    {
        return FromDateTime(DateTime.UtcNow);
    }

    public static WorldTime FromDateTime(DateTime dt)
    {
        dt = dt.AddYears(-(dt.Year - 1));
        dt = dt.AddDays(YearOffset * DaysInYear);
        dt = dt.AddMinutes(MinuteOffset);
        dt = dt.AddDays(DayOffset);
        var span = TimeSpan.FromTicks(dt.Ticks);
        return new WorldTime(span);
    }

    public override string ToString()
    {
        // AL Time Form
        // YEAR-QUARTER-DAY HH:MM
        // 00
        var year = Span.Days / DaysInYear + 1;
        var dayInYear = Span.Days % DaysInYear + 1;
        var month = dayInYear / DaysInMonth + 1;
        var dayInQuarter = dayInYear % DaysInMonth + 1;
        return $"{year:0000}-{month:00}-{dayInQuarter:00} {Span.Hours:00}:{Span.Minutes:00}";
    }
}

