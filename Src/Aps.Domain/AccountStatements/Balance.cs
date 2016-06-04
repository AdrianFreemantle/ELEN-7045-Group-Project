using System;

namespace Aps.Domain.AccountStatements
{
    public struct Balance 
    {
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

        public override string ToString()
        {
            return String.Format("{0:C}", balance);
        }
    }
}