using Aps.Domain.AccountStatements;
using Aps.Domain.AccountStatements.StatementEntryDataTypes;
using Aps.Domain.Common;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
{
    public partial class Fincancial_balances : FeatureFixture
    {
        private Balance balance;

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

        private void the_balance_is(Balance amount)
        {
            balance.ShouldBe(amount);
        }
    }
}