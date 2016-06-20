using Aps.Domain.Credential;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class EmailAddress_equality : FeatureFixture
    {
        private EmailAddress address1;
        private EmailAddress address2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = address1.Equals(address2);
        }

        private void another_Email(EmailAddress address)
        {
            address2 = address;
        }

        private void email(EmailAddress address)
        {
            address1 = address;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
