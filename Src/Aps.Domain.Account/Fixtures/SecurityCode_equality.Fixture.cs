using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Aps.Domain.Account.Tests
{
    public partial class SecurityCode_equality : FeatureFixture
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
            IDecryptionService service = new Encryption();
            areEqual = code1.GetDetails(service).Equals(code2.GetDetails(service));
        }

        private void another_SecurityCode(SecurityCode code)
        {
            code2 = code;
        }

        private void securityCode(SecurityCode code)
        {
            code1 = code;
        }

        private void the_two_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
