using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APS.Domain.Services.Tests
{
    [TestClass]
    [ScenarioCategory("Process Scrape Result")]
    [FeatureDescription(@"A pipeline can be used to process a scrape result")]
    public partial class Scrape_result_pipeline 
    {
        [TestMethod]
        public void Account_statment_creation_service_is_called_by_pipeline()
        {
            Runner.RunScenario(
                Given_a_completed_scrape_session_result,
                And_an_account_statment_creation_service,
                And_an_account_statment_creation_module,
                And_a_scrape_session_result_pipeline_factory,
                When_the_pipeline_is_invoked,
                Then_the_account_statment_creation_service_creates_an_account_statement);
        }
    }
}