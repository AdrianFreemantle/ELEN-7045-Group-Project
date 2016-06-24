using System;
using Aps.Domain.Company.Tests.DomainTypes;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Company.Tests
{
    public partial class Billing_cycle_create : FeatureFixture
    {
        private LeadTime _leadTime;
        private NumberOfDaysPerCycle _numberOfDaysPerCycle;
        private RetryInterval _retryInterval;
        private BillingCycle _billingCycle;
        private Exception _error;

        private void a_lead_time(LeadTime leadTime)
        {
            _leadTime = leadTime;
        }

        private void a_number_of_days_per_cycle(NumberOfDaysPerCycle numberOfDaysPerCycle)
        {
            _numberOfDaysPerCycle = numberOfDaysPerCycle;
        }

        private void a_retry_interval(RetryInterval retryInterval)
        {
            _retryInterval = retryInterval;
        }

        private void creating_a_billing_cycle()
        {
            try
            {
                _billingCycle = new BillingCycle(_leadTime, _numberOfDaysPerCycle, _retryInterval);
            }
            catch (Exception exception)
            {
                _error = exception;
            }
        }

        private void it_must_be_valid()
        {
            Assert.IsNull(_error);
        }
    }
}
