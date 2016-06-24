using System;

namespace Aps.Domain.AccountStatements.StatementEntryDataTypes
{
    public struct CalendarMonth : IAccountStatementEntryData
    {
        private const int MinMonth = 1;
        private const int MaxMonth = 12;
        private const int MinYear = 1900;
        private const int MaxYear = 2099;

        private readonly int year;
        private readonly int month;

        public static CalendarMonth Empty { get { return new CalendarMonth(); } }

        public CalendarMonth(int year, int month)
        {
            Validate(month, year);

            this.year = year;
            this.month = month;
        }

        public CalendarMonth(DateTime dateTime)
        {
            Validate(dateTime.Month, dateTime.Year);

            month = dateTime.Month;
            year = dateTime.Year;
        }

        private static void Validate(int month, int year)
        {
            ValidateYear(year);
            ValidateMonth(month);
        }

        private static void ValidateMonth(int month)
        {
            if (month < MinMonth || month > MaxMonth)
            {
                throw new ArgumentException(String.Format("The month {0} is outside of the allowed range of {1}-{2}", month, MinMonth, MaxMonth));
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
            if (year == 0 || month == 0)
            {
                return String.Empty;
            }

            return String.Format("{0:0000}-{1:00}", year, month);
        }

        public string ToString(string format)
        {
            return new DateTime(year, month, 1).ToString(format);
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return new DateTime(year, month, 1).ToString(formatProvider);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return new DateTime(year, month, 1).ToString(format, formatProvider);
        }
    }
}