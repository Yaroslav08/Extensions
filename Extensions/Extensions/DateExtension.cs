using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Extensions
{
    public enum Language
    {
        English,
        Ukrainian,
        Russian
    }

    public static class DateExtension
    {
        public static long ConvertDateTimeToUnix(DateTime DateTime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime - sTime).TotalSeconds;
        }

        public static DateTime ConvertUnixToDateTime(long UnixTime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return sTime.AddSeconds(UnixTime);
        }

        public static string GetShortDate(this DateTime dateTime, Language language)
        {
            if (IsTomorrow(dateTime))
                return GetTomorrow(dateTime, language);
            if (IsToday(dateTime))
                return GetToday(dateTime);
            if (IsYesterday(dateTime))
                return GetYesterday(dateTime, language);
            else
                return GetOtherDay(dateTime, language);
        }

        public static string GetLongDate(this DateTime dateTime, Language language)
        {
            var tomorrow = IsTomorrow(dateTime);
            var today = IsToday(dateTime);
            var yesterday = IsYesterday(dateTime);
            if (tomorrow)
                return GetTomorrow(dateTime, language);
            if (today)
                return GetTodayLong(dateTime, language);
            if (yesterday)
                return GetYesterday(dateTime, language);
            else
                return GetOtherDay(dateTime, language);
        }

        public static string GetFullDate(this DateTime dateTime, Language language)
        {
            switch (language)
            {
                case Language.English: return $"{dateTime.Day} {GetEngMonth(dateTime)} {GetFullYear(dateTime)} at {dateTime.ToShortTimeString()}";
                case Language.Ukrainian: return $"{dateTime.Day} {GetUkrMonth(dateTime)} {GetFullYear(dateTime)} о {dateTime.ToShortTimeString()}";
                case Language.Russian: return $"{dateTime.Day} {GetRusMonth(dateTime)} {GetFullYear(dateTime)} в {dateTime.ToShortTimeString()}";
                default: return null;
            }
        }

        public static string GetDate(bool IsShort, DateTime dateTime, Language language)
        {
            var tomorrow = IsTomorrow(dateTime);
            var today = IsToday(dateTime);
            var yesterday = IsYesterday(dateTime);
            if (tomorrow)
                return GetTomorrow(dateTime, language);
            if (today)
            {
                if (!IsShort)
                    return GetTodayLong(dateTime, language);
                return GetToday(dateTime);
            }
            if (yesterday)
                return GetYesterday(dateTime, language);
            else
                return GetOtherDay(dateTime, language);
        }

        public static string GetFullDateInfo(DateTime dateTime, Language language)
        {
            switch (language)
            {
                case Language.English: return $"{dateTime.Day} {GetEngMonth(dateTime)} {GetFullYear(dateTime)} at {dateTime.ToShortTimeString()}";
                case Language.Ukrainian: return $"{dateTime.Day} {GetUkrMonth(dateTime)} {GetFullYear(dateTime)} о {dateTime.ToShortTimeString()}";
                case Language.Russian: return $"{dateTime.Day} {GetRusMonth(dateTime)} {GetFullYear(dateTime)} в {dateTime.ToShortTimeString()}";
                default: return null;
            }
        }

        static string GetTodayLong(DateTime dateTime, Language language)
        {
            switch (language)
            {
                case Language.English:
                    {
                        return $"Today at {dateTime.ToShortTimeString()}";
                    }
                case Language.Ukrainian:
                    {
                        return $"Сьогодні о {dateTime.ToShortTimeString()}";
                    }
                case Language.Russian:
                    {
                        return $"Сегодня в  {dateTime.ToShortTimeString()}";
                    }
                default: return null;
            }
        }

        static string GetTomorrow(DateTime dateTime, Language language)
        {
            switch (language)
            {
                case Language.English:
                    {
                        return $"Tomorrow at {dateTime.ToShortTimeString()}";
                    }
                case Language.Ukrainian:
                    {
                        return $"Завтра о {dateTime.ToShortTimeString()}";
                    }
                case Language.Russian:
                    {
                        return $"Завтра в {dateTime.ToShortTimeString()}";
                    }
                default: return null;
            }
        }

        static string GetToday(DateTime dateTime)
        {
            return dateTime.ToShortTimeString();
        }

        static string GetYesterday(DateTime dateTime, Language language)
        {
            switch (language)
            {
                case Language.English:
                    {
                        return $"Yesterday at {dateTime.ToShortTimeString()}";
                    }
                case Language.Ukrainian:
                    {
                        return $"Учора о {dateTime.ToShortTimeString()}";
                    }
                case Language.Russian:
                    {
                        return $"Вчера в {dateTime.ToShortTimeString()}";
                    }
                default: return null;
            }
        }

        static string GetOtherDay(DateTime dateTime, Language language)
        {
            if (ThisYear(dateTime))
            {
                switch (language)
                {
                    case Language.English: return $"{dateTime.Day} {GetEngMonth(dateTime)} at {dateTime.ToShortTimeString()}";
                    case Language.Ukrainian: return $"{dateTime.Day} {GetUkrMonth(dateTime)} о {dateTime.ToShortTimeString()}";
                    case Language.Russian: return $"{dateTime.Day} {GetRusMonth(dateTime)} в {dateTime.ToShortTimeString()}";
                    default: return null;
                }
            }
            else
            {
                switch (language)
                {
                    case Language.English: return $"{dateTime.Day} {GetEngMonth(dateTime)} {GetFullYear(dateTime)} at {dateTime.ToShortTimeString()}";
                    case Language.Ukrainian: return $"{dateTime.Day} {GetUkrMonth(dateTime)} {GetFullYear(dateTime)} о {dateTime.ToShortTimeString()}";
                    case Language.Russian: return $"{dateTime.Day} {GetRusMonth(dateTime)} {GetFullYear(dateTime)} в {dateTime.ToShortTimeString()}";
                    default: return null;
                }
            }
        }

        static bool ThisYear(DateTime dateTime)
        {
            return dateTime.Year == DateTime.Today.Year ? true : false;
        }

        static string GetEngMonth(DateTime dateTime)
        {
            switch (dateTime.Month)
            {
                case 1: return "january";
                case 2: return "february";
                case 3: return "march";
                case 4: return "april";
                case 5: return "may";
                case 6: return "june";
                case 7: return "july";
                case 8: return "august";
                case 9: return "september";
                case 10: return "october";
                case 11: return "november";
                case 12: return "december";
                default: throw new Exception("Invalid month");
            }
        }

        static string GetUkrMonth(DateTime dateTime)
        {
            switch (dateTime.Month)
            {
                case 1: return "січеня";
                case 2: return "лютого";
                case 3: return "березня";
                case 4: return "квітня";
                case 5: return "травня";
                case 6: return "червня";
                case 7: return "липня";
                case 8: return "серпня";
                case 9: return "вересня";
                case 10: return "жовтня";
                case 11: return "листопада";
                case 12: return "грудня";
                default: throw new Exception("Invalid month");
            }
        }

        static string GetRusMonth(DateTime dateTime)
        {
            switch (dateTime.Month)
            {
                case 1: return "января";
                case 2: return "февраля";
                case 3: return "марта";
                case 4: return "апреля";
                case 5: return "мая";
                case 6: return "июня";
                case 7: return "июля";
                case 8: return "августа";
                case 9: return "сентября";
                case 10: return "октября";
                case 11: return "ноября";
                case 12: return "декабря";
                default: throw new Exception("Invalid month");
            }
        }

        static bool IsTomorrow(DateTime dateTime)
        {
            var date = dateTime.Day + dateTime.Month + dateTime.Year;
            var todaytemp = DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year;
            return date - todaytemp == 1 ? true : false;
        }

        static bool IsToday(DateTime dateTime)
        {
            var today = dateTime.Day + dateTime.Month + dateTime.Year;
            var todaytemp = DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year;
            return today - todaytemp == 0 ? true : false;
        }

        static bool IsYesterday(DateTime dateTime)
        {
            var today = dateTime.Day + dateTime.Month + dateTime.Year;
            var todaytemp = DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year;
            return todaytemp - today == 1 ? true : false;
        }

        static string GetFullYear(DateTime dateTime)
        {
            return dateTime.Year.ToString();
        }

        static string GetShortYear(DateTime dateTime)
        {
            return GetLastYear(dateTime.Year.ToString(), 2);
        }

        static int GetDay(DateTime dateTime)
        {
            return dateTime.Day;
        }

        static string GetLastYear(string Source, int CountLastCharacters)
        {
            if (CountLastCharacters > Source.Length)
                return Source;
            return Source.Substring(Source.Length - CountLastCharacters);
        }
    }
}