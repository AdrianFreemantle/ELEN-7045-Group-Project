using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Security Code")]
    public partial class SecurityCode_equality
    {
        [TestMethod]
        public void Two_Security_Codes_credentials_with_the_same_value_are_equal()
        {
            IEncryptionService encryptionService = new Encryption();
            var first = new SecurityCode("12345", "12345", encryptionService);
            var second = new SecurityCode("12345", "12345", encryptionService);

            Runner.RunScenario(
            given => securityCode(first),
            and => another_SecurityCode(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_Security_Codes_credentials_with_different_values_are_not_equal()
        {
            IEncryptionService encryptionService = new Encryption();
            var first = new SecurityCode("12345", "12345", encryptionService);
            var second = new SecurityCode("67890", "67890", encryptionService);

            Runner.RunScenario(
            given => securityCode(first),
            and => another_SecurityCode(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
