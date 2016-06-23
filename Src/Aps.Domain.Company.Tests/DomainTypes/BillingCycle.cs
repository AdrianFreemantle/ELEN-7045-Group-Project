namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class BillingCycle
    {
        private LeadTime _leadTime;
        private NumberOfDaysPerCycle _numberOfDaysPerCycle;
        private RetryInterval _retryInterval;

        public BillingCycle(LeadTime leadTime, NumberOfDaysPerCycle numberOfDaysPerCycle, RetryInterval retryInterval)
        {
            Guard.ThatValueTypeNotDefaut(leadTime, "leadTime");
            Guard.ThatValueTypeNotDefaut(numberOfDaysPerCycle, "numberOfDaysPerCycle");
            Guard.ThatValueTypeNotDefaut(retryInterval, "retryInterval");
            _leadTime = leadTime;
            _numberOfDaysPerCycle = numberOfDaysPerCycle;
            _retryInterval = retryInterval;
        }
    }
}
