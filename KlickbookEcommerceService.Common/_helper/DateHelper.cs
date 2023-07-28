namespace KlickbookEcommerceService._helper
{
    public static class DatewHelper
    {
        public static string ToStringSyntax(this DateTime date)
            => date.ToString("yyyy/MM/dd HH:mm:ss");

        public static DateTime ToDateTime(this object obj)
            => Convert.ToDateTime(obj);

        public static DateTime ToTenantDateTime(this object obj, TimeZoneInfo tenanttimezone)
            => Convert.ToDateTime(obj).UpdateToTenantTimezone(tenanttimezone);

        public static DateTime? ToDateTimeNullable(this object obj)
            => Convert.ToDateTime(obj);

        public static DateTime? ToTenantDateTimeNullable(this object obj, TimeZoneInfo tenanttimezone)
            => Convert.ToDateTime(obj).UpdateToTenantTimezone(tenanttimezone);

        public static long ToUnixTime(this DateTime date)
            => ((DateTimeOffset)date).ToUnixTimeSeconds();

        public static long ToTenantUnixTime(this DateTime date, TimeZoneInfo tenanttimezone)
            => ((DateTimeOffset)date.UpdateToTenantTimezone(tenanttimezone)).ToUnixTimeSeconds();

        public static DateTime FromUnixTime(this long unixdate)
            => DateTimeOffset.FromUnixTimeSeconds(unixdate).UtcDateTime.ToDateTime();

        public static DateTime FromTenantUnixTime(this long unixdate, TimeZoneInfo tenanttimezone)
            => DateTimeOffset.FromUnixTimeSeconds(unixdate).UtcDateTime.ToTenantDateTime(tenanttimezone);

        public static DateTime UpdateToTenantTimezone(this DateTime date, TimeZoneInfo tenanttimezone)
        {
            var offset = tenanttimezone.BaseUtcOffset;
            if (offset.TotalMinutes != 0)
                date = date.Add((offset * -1));
            return date;
        }
    }
}
