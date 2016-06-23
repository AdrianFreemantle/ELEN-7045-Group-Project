using System;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct NumberOfDaysPerCycle
    {
        private readonly int _numberOfDaysPerCycle;

        public NumberOfDaysPerCycle(int numberOfDaysPerCycle)
        {
            if (numberOfDaysPerCycle < 0 || numberOfDaysPerCycle > 365)
                throw new ArgumentOutOfRangeException("Number of days per cycle cannot be negative or greater then 365 days");
            _numberOfDaysPerCycle = numberOfDaysPerCycle;
        }

        public static implicit operator int(NumberOfDaysPerCycle numberOfDaysPerCycle)
        {
            return numberOfDaysPerCycle._numberOfDaysPerCycle;
        }

        public override string ToString()
        {
            return _numberOfDaysPerCycle.ToString();
        }
    }
}
