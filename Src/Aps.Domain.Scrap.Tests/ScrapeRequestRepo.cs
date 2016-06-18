using Aps.Domain.Scraping;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Scrap.Tests
{
    [TestClass]
    [ScenarioCategory("Scrape Repo")]
    [FeatureDescription(@"All Scrape requests recieved should reside in a repo for tracking and dispute discrepancies")]
    public partial class ScrapeRequestRepo
    {
        [TestMethod]
        public void Save_Scrape_Request_to_repository()
        {

            Runner.RunScenario(
                given => a_valid_scrape_request(),
                and => an_scrap_request_repository(),
                when => saving_the_scrap_request_data(),
                then => then_saved());
        }

    }
}