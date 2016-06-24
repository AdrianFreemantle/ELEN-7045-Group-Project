using System;

namespace Aps.Domain.AccountStatements.StatementEntryDataTypes
{
    public struct Balance : IAccountStatementEntryData
    {
        private const string DefaultCurrencyFormat = "{0:C}";
        private readonly decimal balance;

        public Balance(decimal balance)
            : this()
        {
            this.balance = balance;
        }

        public static Balance FromAmount(decimal amount)
        {
            return new Balance(amount);
        }

        public Balance Credit(Money amount)
        {
            return this + amount;
        }

        public Balance Debit(Money amount)
        {
            return this - amount;
        }

        public int ValueInCents()
        {
            return (int)(balance * 100);
        }

        public static Balance operator +(Balance left, Balance right)
        {
            return new Balance(left.balance + right.balance);
        }

        public static Balance operator -(Balance left, Balance right)
        {
            return new Balance(left.balance - right.balance);
        }

        public static bool operator >(Balance left, Balance right)
        {
            return left.balance > right.balance;
        }

        public static bool operator <(Balance left, Balance right)
        {
            return left.balance < right.balance;
        }

        public override string ToString()
        {
            return ToString(GetDefaultFormatProvider());
        }        

        public string ToString(IFormatProvider provider)
        {
            return ToString(DefaultCurrencyFormat, provider);
        }

        public string ToString(string format)
        {
            return ToString(DefaultCurrencyFormat, GetDefaultFormatProvider());
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            IFormatProvider provider = formatProvider ?? GetDefaultFormatProvider();
            format = format ?? DefaultCurrencyFormat;
            
            return String.Format(provider, format, balance);
        }

        private static IFormatProvider GetDefaultFormatProvider()
        {
            DefaultFormatProviderSettings formatProviderSettings = new DefaultFormatProviderSettings();
            return formatProviderSettings.NumberFormat;
        }
    }
}