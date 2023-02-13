using System;

namespace _70_School.Web1.Brokers.DateTimes
{
    public class DateTimeBroker:IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTimeOffset() =>
            DateTimeOffset.UtcNow;
    }
}
