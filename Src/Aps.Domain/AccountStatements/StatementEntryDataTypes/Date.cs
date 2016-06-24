using System;

namespace Aps.Domain.AccountStatements.StatementEntryDataTypes
{
    public struct Date : IAccountStatementEntryData
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
}