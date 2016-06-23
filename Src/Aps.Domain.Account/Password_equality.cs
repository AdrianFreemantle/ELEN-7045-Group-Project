using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Password")]
    public partial class Password_equality
    {
        [TestMethod]
        public void Two_Passwords_credentials_with_the_same_value_are_equal()
        {
            IEncryptionService encryptionService = new Encryption();
            var first = new Password("12345", "12345", encryptionService);
            var second = new Password("12345", "12345", encryptionService);

            Runner.RunScenario(
            given => password(first),
            and => another_Password(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_Passwords_credentials_with_different_values_are_not_equal()
        {
            IEncryptionService encryptionService = new Encryption();
            var first = new Password("12345", "12345", encryptionService);
            var second = new Password("67890", "67890", encryptionService);

            Runner.RunScenario(
            given => password(first),
            and => another_Password(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
