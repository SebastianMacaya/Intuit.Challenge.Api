using NodaTime;

namespace Api.Intuit.Infrastructure.Services
{
    public interface IAppDateTime
    {
        DateTime LocalNow { get; }
        DateTime UnspecifiedNow { get; }
        DateTime UtcNow { get; }
        string YearMonthDay(DateTime date);
        string YearMonth(DateTime date);

        DateTime GetDateTimeNowBySite(string timeZone);
    }

    public class AppDateTime : IAppDateTime, IService
    {
        private const string Gmt = "GMT";

        public DateTime LocalNow => DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
        public DateTime UnspecifiedNow => DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        public DateTime UtcNow => DateTime.UtcNow;
        public string YearMonthDay(DateTime date) => date.ToString("yyyyMMdd");
        public string YearMonth(DateTime date) => date.ToString("yyyyMM");

        public DateTime GetDateTimeNowBySite(string timeZone)
        {
            var dateInstant = Instant.FromDateTimeUtc(DateTime.UtcNow);
            var hour = int.Parse(timeZone.Replace(Gmt, string.Empty).Substring(0, 3));
            var minute = int.Parse(timeZone.Replace(Gmt, string.Empty).Substring(4, 2));

            var location = DateTimeZone.ForOffset(Offset.FromHoursAndMinutes(hour, minute));
            var timezone = DateTimeZoneProviders.Tzdb[location.Id];

            var zonedTime = dateInstant.InZone(timezone);

            return zonedTime.ToDateTimeUnspecified();
        }
    }
}
