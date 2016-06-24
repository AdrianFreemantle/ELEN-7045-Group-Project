using System;

namespace Aps.Domain.AccountStatements.StatementEntryDataTypes
{
    public struct Duration : IAccountStatementEntryData
    {
        private const string DefaultFormat = "{0:hh\\:mm\\:ss}";
        private readonly TimeSpan duration;

        public Duration(string duration)
        {
            Guard.ThatParameterNotNullOrEmpty(duration, "duration");
            this.duration = TimeSpan.Parse(duration);
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

            return String.Format(provider, format, duration);
        }

        private static IFormatProvider GetDefaultFormatProvider()
        {
            DefaultFormatProviderSettings formatProviderSettings = new DefaultFormatProviderSettings();
            return formatProviderSettings.DateFormat;
        }
    }
}