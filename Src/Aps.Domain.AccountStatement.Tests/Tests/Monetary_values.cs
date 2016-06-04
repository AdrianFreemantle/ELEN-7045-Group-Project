using Aps.Domain.AccountStatements;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.AccountStatement.Tests.Tests
{
    [TestClass]
    [FeatureDescription("Monetary values can be added and subtracted from each other so that integrity checks can be performed.")]
    public partial class Monetary_values
    {
        [TestMethod]
        public void Can_be_summed_resulting_in_a_positive_balance()
        {
            Runner.RunScenario(
                given => an_amount_of(Money.FromAmount(500)),
                when => adding_an_amount_of(Money.FromAmount(100)),
                then => the_balance_is(Balance.FromAmount(600)));
        }

        [TestMethod]
        public void Can_be_subtracted_resulting_in_a_negative_balance()
        {
            Runner.RunScenario(
                given => an_amount_of(Money.FromAmount(500)),
                when => subtracting_an_amount_of(Money.FromAmount(600)),
                then => the_balance_is(Balance.FromAmount(-100)));
        }

        [TestMethod]
        public void Can_be_subtracted_resulting_in_a_positive_balance()
        {
            Runner.RunScenario(
                given => an_amount_of(Money.FromAmount(500)),
                when => subtracting_an_amount_of(Money.FromAmount(100)),
                then => the_balance_is(Balance.FromAmount(400)));
        }

        [TestMethod]
        public void Crediting_a_negative_balance_results_in_a_positive_balance()
        {
            Runner.RunScenario(
                given => an_existing_balance_of(Balance.FromAmount(-100)),
                when => crediting_the_balance_with_an_amount_of(Money.FromAmount(200)),
                then => the_balance_is(Balance.FromAmount(100)));
        }

        [TestMethod]
        public void Debiting_a_positive_balance_results_in_a_negative_balance()
        {
            Runner.RunScenario(
                given => an_existing_balance_of(Balance.FromAmount(100)),
                when => debiting_the_balance_with_an_amount_of(Money.FromAmount(200)),
                then => the_balance_is(Balance.FromAmount(-100)));
        }

        [TestMethod]
        public void Adding_positive_balances_results_in_a_positive_balance()
        {
            Runner.RunScenario(
                given => an_existing_balance_of(Balance.FromAmount(100)),
                when => crediting_the_balance_with_an_amount_of(Money.FromAmount(100)),
                then => the_balance_is(Balance.FromAmount(200)));
        }
    }
}