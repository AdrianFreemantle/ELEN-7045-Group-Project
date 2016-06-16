using Aps.Domain.AccountStatements;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
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


    }
}