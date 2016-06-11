using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"Account statments should be equatable based on identity and not on internal state")]
    public partial class Account_statement_equality : FeatureFixture
    {
        [TestMethod]
        [Label("Story-1")]
        public void Two_account_statement_with_the_same_identities_are_equal()
        {
            string accountId = "12345";
            DateTime runTime = DateTime.Today;

            Runner.RunScenario(
                given => Two_account_statements_for_calendar_month(runTime),
                and => for_account(accountId),
                when => performing_an_equality_comparison(),
                then => The_two_account_statements_are_identical());
        }
    }
}