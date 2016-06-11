using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests
{
    [TestClass]
    [FeatureDescription(@"An account factory creates a valid instance of an account")]
    public partial class Account_statement_factory 
    {
        [TestMethod]
        public void Creates_a_valid_account_statement_from_a_scrape_result()
        {
            Runner.RunScenario(
                given => account_id(),
                and => a_scrape_session_result(),
                and => an_account_statement_factory(),
                when => creating_an_account_statement(),
                then => a_valid_account_statement_is_created());
        }
    }
}