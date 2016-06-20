using System;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Email Address")]
    public partial class EmailAddress_identity
    {
        [TestMethod]
        public void Two_Email_Address_credentials_with_the_same_address_are_equal()
        {
            var first = new EmailAddress("chrisv@live.co.za");
            var second = new EmailAddress("chrisv@live.co.za");

            Runner.RunScenario(
            given => email(first),
            and => another_Email(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_Email_Address_credentials_with_different_addresses_are_not_equal()
        {
            var first = new EmailAddress("chrisv@live.co.za");
            var second = new EmailAddress("chrisv@hotmail.co.za");

            Runner.RunScenario(
            given => email(first),
            and => another_Email(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
