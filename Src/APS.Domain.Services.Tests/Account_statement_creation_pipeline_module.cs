using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APS.Domain.Services.Tests
{
    [TestClass]
    [ScenarioCategory("Process Scrape Result")]
    [FeatureDescription(@"An Account Statement Creation pipeline module can be used to process a scrape result")]
    public partial class Account_statement_creation_pipeline_module 
    {
        [TestMethod]
        public void Account_statement_creation_service_is_called_by_pipeline()
        {
            Runner.RunScenario(
                Given_a_completed_scrape_session_result,
                And_an_account_statement_creation_service,
                And_a_customer_notification_service,
                And_an_account_status_update_service,
                And_a_company_script_service,
                And_an_scrape_session_result_pipeline,
                When_the_pipeline_is_invoked,
                Then_the_account_statement_creation_service_creates_an_account_statement,
                And_the_company_script_service_does_not_set_the_script_as_broken,
                And_the_customer_notification_service_does_not_notify_the_customer,
                And_the_account_status_service_activates_an_inactive_account);
        }
    }
}