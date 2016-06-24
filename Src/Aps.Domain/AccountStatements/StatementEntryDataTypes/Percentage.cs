using System;

namespace Aps.Domain.AccountStatements.StatementEntryDataTypes
{
    public struct Percentage : IAccountStatementEntryData
    {
        private const string DefaultFormat = "{0:P1}";
        private readonly decimal percentage;

        public Percentage(decimal percentage)
        {
            this.percentage = percentage;
        }

        public static Percentage FromAmount(decimal percentage)
        {
            return new Percentage(percentage / 100);
        }

        public override string ToString()
        {
            return ToString(GetDefaultFormatProvider());
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString(DefaultFormat, provider);
        }

        public string ToString(string format)
        {
            return ToString(DefaultFormat, GetDefaultFormatProvider());
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            IFormatProvider provider = formatProvider ?? GetDefaultFormatProvider();
            format = format ?? DefaultFormat;

            return String.Format(provider, format, percentage);
        }

        private static IFormatProvider GetDefaultFormatProvider()
        {
            DefaultFormatProviderSettings formatProviderSettings = new DefaultFormatProviderSettings();
            return formatProviderSettings.NumberFormat;
        }
    }
}