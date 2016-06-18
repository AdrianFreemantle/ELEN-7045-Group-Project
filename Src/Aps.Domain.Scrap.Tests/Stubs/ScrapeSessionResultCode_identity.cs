using Aps.Domain.Scrap;
using Aps.Domain.Scrap.Tests.DomainTypes;
using Aps.Domain.Scrap.Tests.Stubs;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Scrap.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Scraper Status")]
    public partial class ScrapeSessionResultCode_identity : FeatureFixture
    {
        [TestMethod]
        public void Two_account_status_identities_with_the_same_status_are_equal()
        {
            var first = ScrapeSessionResultCode.Complete;
            var second = ScrapeSessionResultCode.Complete;

            Runner.RunScenario(
            given => ScrapeSessionResultCode_status(first),
            and => another_ScrapeSessionResultCode_status(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_ScrapeSessionResultCode_status_identities_with_different_statuses_are_not_equal()
        {
            var first = ScrapeSessionResultCode.Pending;
            var second = ScrapeSessionResultCode.Complete;

            Runner.RunScenario(
            given => ScrapeSessionResultCode_status(first),
            and => another_ScrapeSessionResultCode_status(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
