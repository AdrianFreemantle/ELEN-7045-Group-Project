using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"As a customer I want to view previous account statements for an account so that I can track my payment history or dispute discrepancies")]
    public partial class Previous_account_statements
    {
        [TestMethod]
        public void Account_statement_repository_cant_fetch_all_prior_statments_for_an_account()
        {
            string accountNumber = "12345";

            Runner.RunScenario(
                given => an_account_statement_repository(),
                and => it_contains_account_statements_for_account(accountNumber),
                when => fetching_all_account_statements_for_account_number(accountNumber),
                then => account_statements_are_returned());
        }
    }
}