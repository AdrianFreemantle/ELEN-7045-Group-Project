using System;
using Aps.Domain.Company.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    [TestClass]
    [FeatureDescription(@"A billing cycle must be valid on creation")]
    public partial class Billing_cycle_create
    {
        [TestMethod]
        public void a_billing_cycle_must_be_valid_on_creation()
        {
            Runner.RunScenario(
                given => a_lead_time(new LeadTime(10)),
                and => a_number_of_days_per_cycle(new NumberOfDaysPerCycle()),
                and => a_retry_interval(new RetryInterval()),
                when => creating_a_billing_cycle(),
                then => it_must_be_valid()
                );
        }
    }
}
