using System;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Credit Card Number")]
    public partial class CreditCardNumber_identity
    {
        [TestMethod]
        public void Two_CreditCardNumber_credentials_with_the_same_numbers_are_equal()
        {
            var first = new CreditCardNumber("1234567890123456");
            var second = new CreditCardNumber("1234567890123456");

            Runner.RunScenario(
            given => creditCardNumber(first),
            and => another_CreditCardNumber(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_account_status_identities_with_different_statuses_are_not_equal()
        {
            var first = new CreditCardNumber("1234567890123456");
            var second = new CreditCardNumber("9234567890123457");

            Runner.RunScenario(
            given => creditCardNumber(first),
            and => another_CreditCardNumber(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
