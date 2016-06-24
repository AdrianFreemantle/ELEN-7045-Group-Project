namespace Aps.Domain.Companies
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

        public bool Equals(BillingCycle other)
        {
            return _leadTime.Equals(other._leadTime)
                   && _numberOfDaysPerCycle.Equals(other._numberOfDaysPerCycle)
                   && _retryInterval.Equals(other._retryInterval);
        }
    }
}
