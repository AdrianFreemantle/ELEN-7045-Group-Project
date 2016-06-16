using Aps.Domain.Credential;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class CreditCardNumber_identity : FeatureFixture
    {
        private CreditCardNumber number1;
        private CreditCardNumber number2;
        private bool areEqual;

        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = number1.Equals(number2);
        }

        private void another_CreditCardNumber(CreditCardNumber number)
        {
            number2 = number;
        }

        private void creditCardNumber(CreditCardNumber number)
        {
            number1 = number;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
