using System;

namespace Aps.Domain.Common
{
    public struct Date : IFormattable
    {
        private const string DefaultFormat = "d";

        private const int MinDay = 1;
        private const int MaxDay= 31;
        private const int MinMonth = 1;
        private const int MaxMonth = 12;
        private const int MinYear = 1900;
        private const int MaxYear = 2099;

        private readonly DateTime date;

        public Date(int year, int month, int day)
        {
            Validate(year, month, day);

            this.date = new DateTime(year, month, day);
        }

        public Date(DateTime dateTime)
        {
            Guard.ThatValueTypeNotDefaut(dateTime, "dateTime");
            Validate(dateTime.Year, dateTime.Month, dateTime.Day);

            this.date = dateTime.Date;
        }

        private static void Validate(int year, int month, int day)
        {
            ValidateYear(year);
            ValidateMonth(month);
            ValidateDay(day);
        }

        private static void ValidateDay(int day)
        {
            if (day < MinDay || day > MaxDay)
            {
                throw new ArgumentException(String.Format("The day {0} is outside of the allowed range of {1}-{2}", day, MinDay, MaxDay));
            }
        }

        private static void ValidateMonth(int month)
        {
            if (month < MinMonth || month > MaxMonth)
            {
                throw new ArgumentException(String.Format("The moth {0} is outside of the allowed range of {1}-{2}", month, MinMonth, MaxMonth));
            }
        }

        private static void ValidateYear(int year)
        {
            if (year < MinYear || year > MaxYear)
            {
                throw new ArgumentException(String.Format("The year {0} is outside of the allowed range of {1}-{2}", year, MinYear, MaxYear));
            }
        }

        public override string ToString()
        {
            return ToString(DefaultFormat);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString(DefaultFormat, provider);
        }

        public string ToString(string format)
        {
            return ToString(DefaultFormat, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            format = format ?? DefaultFormat;

            return date.ToString(format);
        }
    }

    public struct Month : IFormattable
    {
        //String.Format("{0:M MM MMM MMMM}", dt);  // "3 03 Mar March"  month
        private const int MinMonth = 1;
        private const int MaxMonth = 12;
        private const string DefaultFormat = "MMM";

        private static readonly string[] ShortMonthNames =
        {
            "Jan", "Feb", "Mar", "Apr",
            "May", "Jun", "Jul", "Aug",
            "Sep", "Oct", "Nov", "Dec"
        };

        private static readonly string[] FullMonthNames =
        {
            "January", "February", "March", "April",
            "May", "June", "July", "August",
            "September", "October", "November", "December"
        };

        private readonly int month;

        public Month(int month)
        {
            ValidateMonth(month);

            this.month = month - 1;
        }

        public Month(string month)
        {
            Guard.ThatParameterNotNullOrEmpty(month, "month");

            int monthValue = 0;

            if (month.Length < 3)
            {
                monthValue = NumericValue.Parse(month).ToInt32() - 1; //-1 for zero based index
            }
            else if (month.Length == 3)
            {
                monthValue = GetMonthValue(month, ShortMonthNames);
            }
            else
            {
                monthValue = GetMonthValue(month, FullMonthNames);
            }

            ValidateMonth(monthValue);
            this.month = monthValue;
        }

        private static int GetMonthValue(string month, string[] months)
        {
            for (int i = 0; i < months.Length; i++)
            {
                if (months[i].Equals(month, StringComparison.InvariantCultureIgnoreCase))
                {
                    return i;
                }
            }

            throw new ArgumentException(String.Format("{0} is not a valid month", month));
        }

        private static void ValidateMonth(int month)
        {
            if (month < MinMonth || month > MaxMonth)
            {
                throw new ArgumentException(String.Format("The moth {0} is outside of the allowed range of {1}-{2}", month, MinMonth, MaxMonth));
            }
        }

        public override string ToString()
        {
            return ToString(DefaultFormat);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString(DefaultFormat, provider);
        }

        public string ToString(string format)
        {
            return ToString(DefaultFormat, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            format = format ?? DefaultFormat;

            if (format.Equals("M"))
                return String.Format("{0:D1}", month + 1);

            if (format.Equals("MM"))
                return String.Format("{0:D2}", month + 1);

            if (format.Equals("MMM"))
                return ShortMonthNames[month];

            if (format.Equals("MMMM"))
                return FullMonthNames[month];

            throw new ArgumentException("Invalid format argument");
        }
    }
}