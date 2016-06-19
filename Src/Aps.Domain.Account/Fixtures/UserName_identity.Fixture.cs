using Aps.Domain.Credential;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class UserName_identity : FeatureFixture
    {
        private UserName username1;
        private UserName username2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = username1.Equals(username2);
        }

        private void another_UserName(UserName username)
        {
            username2 = username;
        }

        private void userName(UserName username)
        {
            username1 = username;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
