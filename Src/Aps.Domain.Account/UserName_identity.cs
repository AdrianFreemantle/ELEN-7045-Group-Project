using System;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for UserName")]
    public partial class UserName_identity
    {
        [TestMethod]
        public void Two_UserName_credentials_with_the_same_value_are_equal()
        {
            var first = new UserName("ChrisV");
            var second = new UserName("ChrisV");

            Runner.RunScenario(
            given => userName(first),
            and => another_UserName(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_UserName_credentials_with_different_values_are_not_equal()
        {
            var first = new UserName("ChrisV");
            var second = new UserName("NatashjaV");

            Runner.RunScenario(
            given => userName(first),
            and => another_UserName(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
