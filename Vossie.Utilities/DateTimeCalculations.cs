using System;

namespace Vossie.Utilities
{
    public class DateTimeCalculations
    {
        /// <summary>
        /// UNIX timestamp to System.DateTime
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            // Add the number of seconds in UNIX timestamp to be converted.
            return dateTime.AddMilliseconds(unixTimeStamp);
        }

        /// <summary>
        /// Calculate the time difference between the current date time and another date time
        /// </summary>
        /// <param name="dateToCompare"></param>
        /// <param name="dateToCompareIsGmt"></param>
        /// <returns></returns>
        public double CalculteTimeDifference(DateTime dateToCompare, bool dateToCompareIsGmt)
        {
            if (dateToCompareIsGmt)
            {
                TimeSpan timeToOff = (dateToCompare + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now)) -
                                     DateTime.Now;
                return timeToOff.TotalMilliseconds;
            }
            else
            {
                TimeSpan timeToOff = dateToCompare - DateTime.Now;
                return timeToOff.TotalMilliseconds;
            }
        }

        /// <summary>
        /// Return the current time in GMT
        /// </summary>
        /// <returns></returns>
        public DateTime GetGmtTime()
        {
            return TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.Now);
        }

        /// <summary>
        /// Return the time difference between the current time zone and GMT in total milliseconds
        /// </summary>
        /// <returns></returns>
        public double GetGmtOffset()
        {
            TimeSpan span = DateTime.Now - TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.Now);
            return span.TotalMilliseconds;
        }
    }
}