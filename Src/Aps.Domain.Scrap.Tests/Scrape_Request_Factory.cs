using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aps.Domain.Scrap.Tests.DomainTypes;

namespace Aps.Domain.Scrap.Tests
{
    [TestClass]
    [ScenarioCategory("Scrapper Request Factory")]
    [FeatureDescription(@"A scrapper factory creates a valid instance of a scrapper request")]
    public partial class Scrape_Request_Factory : FeatureFixture
    {
        [TestMethod]
        public void Creates_a_valid_scrape_request()
        {

            Runner.RunScenario(
                given => ScrapeRequest_Id(),
                and => account_id(),
                and => an_scrape_request_factory(),
                when => creating_an_scrape_request(),
                then => a_valid_scrap_request_is_created());
            
        }
   
    }
}