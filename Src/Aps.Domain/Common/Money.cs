using System;
using Aps.Domain.AccountStatements;

namespace Aps.Domain.Common
{
    public struct Money : IAccountStatementEntryData
    {
        private const string DefaultCurrencyFormat = "{0:C}";
        private readonly decimal amount;

        public static Money Zero { get { return new Money(0); } }

        public Money(decimal amount)
            : this()
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", "A monetary amount may not be negative");

            this.amount = amount;
        }

        public static Money FromAmount(decimal amout)
        {
            return new Money(amout);
        }

        public int ValueInCents()
        {
            return (int)(amount * 100);
        }

        public static implicit operator Balance(Money money)
        {
            return new Balance(money.amount);
        }

        public static Balance operator +(Money left, Money right)
        {
            return new Balance(left.amount + right.amount);
        }

        public static Balance operator -(Money left, Money right)
        {
            return new Balance(left.amount - right.amount);
        }

        public static bool operator >(Money left, Money right)
        {
            return left.amount > right.amount;
        }

        public static bool operator <(Money left, Money right)
        {
            return left.amount < right.amount;
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

            return String.Format(provider, format, amount);
        }

        private static IFormatProvider GetDefaultFormatProvider()
        {
            DefaultFormatProviderSettings formatProviderSettings = new DefaultFormatProviderSettings();
            return formatProviderSettings.NumberFormat;
        }
    }
}