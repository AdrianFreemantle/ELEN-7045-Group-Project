using System;

namespace Aps.Domain.Companies
{
    public struct NumberOfDaysPerCycle
    {
        private readonly int _numberOfDaysPerCycle;
        private readonly CycleMethod _cycleMethod;

        public NumberOfDaysPerCycle(int numberOfDaysPerCycle, CycleMethod cycleMethod)
        {
            switch (cycleMethod)
            {
                    case CycleMethod.Monthly:
                    if (numberOfDaysPerCycle < 0 || numberOfDaysPerCycle > 28)
                        throw new ArgumentOutOfRangeException("For a monthly billing cycle, the number of days per cycle cannot be negative or greater then 28 days");
                    break;

                    case CycleMethod.Annually:
                    if (numberOfDaysPerCycle < 0 || numberOfDaysPerCycle > 365)
                        throw new ArgumentOutOfRangeException("For an annual billing cycle, the number of days per cycle cannot be negative or greater then 365 days");
                    break;

                default:
                    throw new ArgumentException("Number of days per cycle requires a cycle method either being Monthly or Annually");
            }
            _cycleMethod = cycleMethod;
            _numberOfDaysPerCycle = numberOfDaysPerCycle;
        }

        public static implicit operator int(NumberOfDaysPerCycle numberOfDaysPerCycle)
        {
            return numberOfDaysPerCycle._numberOfDaysPerCycle;
        }

        public override string ToString()
        {
            return string.Format("Cycle method: {0}, Number of days per cycle: {1}", _cycleMethod.GetDescription(),
                _numberOfDaysPerCycle);
        }
    }
}
