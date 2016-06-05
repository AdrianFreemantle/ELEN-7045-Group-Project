using Aps.Domain.AccountStatements;
using LightBDD;
using Shouldly;

namespace Aps.Domain.AccountStatement.Tests.Tests
{
    public partial class Monetary_values : FeatureFixture
    {
        private Balance balance;

        private void an_amount_of(Money amount)
        {
            balance = amount;
        }

        private void adding_an_amount_of(Money amount)
        {
            balance += amount;
        }

        private void subtracting_an_amount_of(Money amount)
        {
            balance -= amount;
        }

        private void the_balance_is(Balance amount)
        {
            balance.ShouldBe(amount);
        }

        private void an_existing_balance_of(Balance balance)
        {
            this.balance = balance;
        }

        private void crediting_the_balance_with_an_amount_of(Money amount)
        {
            balance = balance.Credit(amount);
        }

        private void debiting_the_balance_with_an_amount_of(Money amount)
        {
            balance = balance.Debit(amount);
        }
    }
}