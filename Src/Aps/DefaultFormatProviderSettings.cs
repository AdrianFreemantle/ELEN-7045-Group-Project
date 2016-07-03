using System;
using System.Globalization;

namespace Aps
{
    public class DefaultFormatProviderSettings
    {
        private static readonly NumberFormatInfo DefaultNumberFormat;
        private static readonly DateTimeFormatInfo DefaultDateFormat;

        public IFormatProvider NumberFormat
        {
            get { return DefaultNumberFormat; }
        }        

        public IFormatProvider DateFormat
        {
            get { return DefaultDateFormat; }
        }

        public string NumberDecimalSeparator
        {
            get { return DefaultNumberFormat.NumberDecimalSeparator; }
        }

        static DefaultFormatProviderSettings()
        {
            DefaultNumberFormat = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberDecimalDigits = 2,
                NumberGroupSeparator = ",",
                NumberNegativePattern = 1,
                CurrencyDecimalDigits = 2,
                CurrencyDecimalSeparator = ".",
                CurrencyGroupSeparator = ",",
                CurrencySymbol = "R",
                CurrencyNegativePattern = 1,
            };

            DefaultDateFormat = CultureInfo.CurrentCulture.DateTimeFormat;
        }
    }
}