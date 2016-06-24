using System;

namespace Aps.Domain.AccountStatements.StatementEntryDataTypes
{
    public struct KilowattHour : IAccountStatementEntryData
    {
        private const string DefaultFormat = "{0:D} kWh";
        private readonly uint amount;

        public KilowattHour(uint amount)
        {
            this.amount = amount;
        }

        public static KilowattHour FromAmount(uint amount)
        {
            return new KilowattHour(amount);
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
            
            return String.Format(provider, format, amount);
        }

        private static IFormatProvider GetDefaultFormatProvider()
        {
            DefaultFormatProviderSettings formatProviderSettings = new DefaultFormatProviderSettings();
            return formatProviderSettings.NumberFormat;
        }
    }
}