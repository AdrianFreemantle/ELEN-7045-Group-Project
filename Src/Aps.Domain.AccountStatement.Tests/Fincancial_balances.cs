using Aps.Domain.Common;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatements.Tests
{
    [TestClass]
    [ScenarioCategory("Account Statements")]
    [FeatureDescription("Financial balances can be credited or debited so that integrity checks can be performed.")]
    public partial class Fincancial_balances
    {
        [TestMethod]
        public void Crediting_a_negative_balance_with_a_larger_monetary_amount_results_in_a_positive_balance()
        {
            Runner.RunScenario(
                given => an_existing_balance_of(Balance.FromAmount(-100)),
                when => crediting_the_balance_with_an_amount_of(Money.FromAmount(200)),
                then => the_balance_is(Balance.FromAmount(100)));
        }

        [TestMethod]
        public void Crediting_a_positive_balance_with_a_monetary_amount_results_in_a_positive_balance()
        {
            Runner.RunScenario(
                given => an_existing_balance_of(Balance.FromAmount(100)),
                when => crediting_the_balance_with_an_amount_of(Money.FromAmount(100)),
                then => the_balance_is(Balance.FromAmount(200)));
        }

        [TestMethod]
        public void Debiting_a_positive_balance_with_a_larger_monetary_amount_results_in_a_negative_balance()
        {
            Runner.RunScenario(
                given => an_existing_balance_of(Balance.FromAmount(100)),
                when => debiting_the_balance_with_an_amount_of(Money.FromAmount(200)),
                then => the_balance_is(Balance.FromAmount(-100)));
        }

        [TestMethod]
        public void Debiting_a_negative_balance_with_a_monetary_amount_results_in_a_negative_balance()
        {
            Runner.RunScenario(
                given => an_existing_balance_of(Balance.FromAmount(-100)),
                when => debiting_the_balance_with_an_amount_of(Money.FromAmount(100)),
                then => the_balance_is(Balance.FromAmount(-200)));
        }
        
    }
}