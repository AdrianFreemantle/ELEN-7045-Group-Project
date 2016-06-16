using System;

namespace Aps.Domain.Common
{
    public struct Money 
    {
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

        public override string ToString()
        {
            return String.Format("{0:C}", amount);
        }
    }
}