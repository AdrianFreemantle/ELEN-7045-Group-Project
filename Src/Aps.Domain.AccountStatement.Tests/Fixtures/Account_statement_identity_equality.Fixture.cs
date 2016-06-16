using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.AccountStatements.Tests
{
    public partial class Account_statement_identity : FeatureFixture
    {
        private AccountStatementId id1;
        private AccountStatementId id2;
        private bool areEqual;

        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = id1.Equals(id2);
        }

        private void another_account_statement_id(AccountStatementId id)
        {
            id2 = id;
        }

        private void account_statement_id(AccountStatementId id)
        {
            id1 = id;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
