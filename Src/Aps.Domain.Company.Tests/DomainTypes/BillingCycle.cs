using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class BillingCycle
    {
        private LeadTime _leadTime;
        private NumberOfDaysPerCycle _numberOfDaysPerCycle;
        private RetryInterval _retryInterval;

        public BillingCycle(LeadTime leadTime, NumberOfDaysPerCycle numberOfDaysPerCycle, RetryInterval retryInterval)
        {
            _leadTime = leadTime;
            _numberOfDaysPerCycle = numberOfDaysPerCycle;
            _retryInterval = retryInterval;
        }
    }
}
