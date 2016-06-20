using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Account Number")]
    public partial class AccountNumber_identity
    {
        [TestMethod]
        public void Two_UserName_credentials_with_the_same_value_are_equal()
        {
            var first = new AccountNumber("1112222333");
            var second = new AccountNumber("1112222333");

            Runner.RunScenario(
            given => accountNumber(first),
            and => another_AccountNumber(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_UserName_credentials_with_different_values_are_not_equal()
        {
            var first = new AccountNumber("1112222333");
            var second = new AccountNumber("0009999888");

            Runner.RunScenario(
            given => accountNumber(first),
            and => another_AccountNumber(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
