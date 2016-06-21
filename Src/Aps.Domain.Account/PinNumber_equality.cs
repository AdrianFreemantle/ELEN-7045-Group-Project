using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Pin Number")]
    public partial class PinNumber_equality
    {
        [TestMethod]
        public void Two_Pin_Numbers_credentials_with_the_same_value_are_equal()
        {
            IEncryptionService encryptionService = new Encryption();
            var first = new PinNumber("12345", "12345", encryptionService);
            var second = new PinNumber("12345", "12345", encryptionService);

            Runner.RunScenario(
            given => pinNumber(first),
            and => another_PinNumber(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_Pin_Numbers_credentials_with_different_values_are_not_equal()
        {
            IEncryptionService encryptionService = new Encryption();
            var first = new PinNumber("12345", "12345", encryptionService);
            var second = new PinNumber("67890", "67890", encryptionService);

            Runner.RunScenario(
            given => pinNumber(first),
            and => another_PinNumber(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
