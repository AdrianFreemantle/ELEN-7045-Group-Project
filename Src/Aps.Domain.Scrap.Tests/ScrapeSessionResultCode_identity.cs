using Aps.Domain.Scrap;
using Aps.Domain.Scrap.Tests.DomainTypes;
using Aps.Domain.Scrap.Tests.Stubs;
using Aps.Domain.Scraping;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Scrap.Tests
{
    [TestClass]
    [FeatureDescription(@"Equality checks and In-equality checks for Scrape Session Result Code")]
    public partial class ScrapeSessionResultCode_identity
    {
        [TestMethod]
        public void Two_Scrape_Session_Result_Code_identities_with_the_same_status_are_equal()
        {
            var first = ScrapeSessionResultCode.Pending;
            var second = ScrapeSessionResultCode.Pending;

            Runner.RunScenario(
            given => Scrape_Session_Result_Code(first),
            and => another_Scrape_Session_Result_Code(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_equal());
        }

        [TestMethod]
        public void Two_Scrape_Session_Result_Code_identities_with_different_statuses_are_not_equal()
        {
            var first = ScrapeSessionResultCode.Complete;
            var second = ScrapeSessionResultCode.Pending;

            Runner.RunScenario(
            given => Scrape_Session_Result_Code(first),
            and => another_Scrape_Session_Result_Code(second),
            when => performing_an_equality_comparison(),
            then => the_two_are_not_equal());
        }
    }
}
