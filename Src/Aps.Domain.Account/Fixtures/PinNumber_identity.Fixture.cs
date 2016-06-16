using Aps.Domain.Credential;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class PinNumber_identity : FeatureFixture
    {
        private PinNumber pin1;
        private PinNumber pin2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = pin1.Equals(pin2);
        }

        private void another_PinNumber(PinNumber pin)
        {
            pin2 = pin;
        }

        private void PinNumber(PinNumber pin)
        {
            pin1 = pin;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
