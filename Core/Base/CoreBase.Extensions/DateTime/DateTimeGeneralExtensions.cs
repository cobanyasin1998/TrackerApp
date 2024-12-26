namespace CoreBase.Extensions.DateTime;

public static class DateTimeGeneralExtensions
{
    public static string ToHumanReadable(this System.DateTime dateTime)
    {
        TimeSpan timeSpan = System.DateTime.UtcNow - dateTime;

        if (timeSpan.TotalMinutes < 1) return "Just now";
        if (timeSpan.TotalMinutes < 60) return $"{timeSpan.TotalMinutes:F0} minutes ago";
        if (timeSpan.TotalHours < 24) return $"{timeSpan.TotalHours:F0} hours ago";

        return dateTime.ToString("MMM dd, yyyy");
    }
    public static Int32 GetAge(this System.DateTime birthDate)
    {
        System.DateTime today = System.DateTime.Today;
        Int32 age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age)) age--;

        return age;
    }

    public static Boolean IsWeekend(this System.DateTime date)
        => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
 
    public static IEnumerable<System.DateTime> GetDatesBetween(System.DateTime startDate, System.DateTime endDate)
    {
        for (System.DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            yield return date;
    }

    public static System.DateTime GetStartOfDay(System.DateTime date) 
        => new(date.Year, date.Month, date.Day, 0, 0, 0, date.Kind);

    public static System.DateTime GetEndOfDay(System.DateTime date) 
        => new(date.Year, date.Month, date.Day, 23, 59, 59, date.Kind);
}
