using Aps.Domain.Account;
using Aps.Domain.Account.Tests.DomainTypes;
using Aps.Domain.Account.Tests.Stubs;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Account.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Account Status")]
    public partial class AccountStatus_identity
    {
        [TestMethod]
        public void Two_account_status_identities_with_the_same_status_are_equal()
        {
            var first = AccountStatus.Active;
            var second = AccountStatus.Active;

            Runner.RunScenario(
            given => account_status(first),
            and => another_account_status(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_account_status_identities_with_different_statuses_are_not_equal()
        {
            var first = AccountStatus.Active;
            var second = AccountStatus.Inactive;

            Runner.RunScenario(
            given => account_status(first),
            and => another_account_status(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
