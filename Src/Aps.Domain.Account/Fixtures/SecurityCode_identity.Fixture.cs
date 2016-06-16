using Aps.Domain.Credential;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class SecurityCode_identity : FeatureFixture
    {
        private SecurityCode code1;
        private SecurityCode code2;
        private bool areEqual;


        private void the_two_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = code1.Equals(code2);
        }

        private void another_SecurityCode(SecurityCode code)
        {
            code2 = code;
        }

        private void SecurityCode(SecurityCode code)
        {
            code1 = code;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
