using System;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Telephone Number")]
    public partial class TelephoneNumber_equality
    {
        [TestMethod]
        public void Two_TelephoneNumber_credentials_with_the_same_value_are_equal()
        {
            var first = new TelephoneNumber("0111234567");
            var second = new TelephoneNumber("0111234567");

            Runner.RunScenario(
            given => telephoneNumber(first),
            and => another_TelephoneNumber(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_TelephoneNumber_credentials_with_different_values_are_not_equal()
        {
            var first = new TelephoneNumber("0111234567");
            var second = new TelephoneNumber("01187901234");

            Runner.RunScenario(
            given => telephoneNumber(first),
            and => another_TelephoneNumber(second),

            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
