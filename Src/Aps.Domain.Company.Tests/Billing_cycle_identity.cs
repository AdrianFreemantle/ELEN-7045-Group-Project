using System;
using Aps.Domain.Companies;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A billing cycle must be uniquely identifiable")]
    public partial class Billing_cycle_identity
    {
        [TestMethod]
        public void Two_billing_cycles_with_the_same_attributes_are_equal()
        {
            var first = new BillingCycle(new LeadTime(2), new NumberOfDaysPerCycle(CycleMethod.Monthly), new RetryInterval(3));
            var second = new BillingCycle(new LeadTime(2), new NumberOfDaysPerCycle(CycleMethod.Monthly), new RetryInterval(3));

            Runner.RunScenario(
                given => a_billing_cycle(first),
                and => another_billing_cycle(second),
                when => performing_an_equality_comparison(),
                then => then_the_two_are_equal()
                );
        }

        [TestMethod]
        public void Two_billing_cycles_with_the_different_attributes_are_not_equal()
        {
            var first = new BillingCycle(new LeadTime(2), new NumberOfDaysPerCycle(CycleMethod.Monthly), new RetryInterval(3));
            var second = new BillingCycle(new LeadTime(7), new NumberOfDaysPerCycle(CycleMethod.Monthly), new RetryInterval(3));

            Runner.RunScenario(
                given => a_billing_cycle(first),
                and => another_billing_cycle(second),
                when => performing_an_equality_comparison(),
                then => then_the_two_are_not_equal()
                );
        }
    }
}
