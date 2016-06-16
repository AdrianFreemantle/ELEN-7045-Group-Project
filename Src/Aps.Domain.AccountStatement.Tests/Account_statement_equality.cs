using System;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription(@"Account statments should be equatable based on identity and not on internal state")]
    public partial class Account_statement_equality : FeatureFixture
    {
        [TestMethod]
        public void Two_account_statement_with_the_same_identities_are_equal()
        {
            Runner.RunScenario(
                given => two_account_statements_for_calendar_month(DateTime.Today),
                and => for_account("12345"),
                when => performing_an_equality_comparison(),
                then => the_two_account_statements_are_equal());
        }
    }
}