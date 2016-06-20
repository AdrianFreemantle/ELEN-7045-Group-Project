using Aps.Domain.Credential;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class AccountNumber_equality : FeatureFixture
    {
        private AccountNumber username1;
        private AccountNumber username2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = username1.Equals(username2);
        }

        private void another_AccountNumber(AccountNumber username)
        {
            username2 = username;
        }

        private void accountNumber(AccountNumber username)
        {
            username1 = username;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
