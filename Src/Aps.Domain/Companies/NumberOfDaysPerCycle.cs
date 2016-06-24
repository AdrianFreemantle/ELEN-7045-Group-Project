using System;

namespace Aps.Domain.Companies
{
    public struct NumberOfDaysPerCycle
    {
        private const int MonthlyCycleDays = 28;
        private const int AnnualCycleDays = 365;
        private readonly int _numberOfDaysPerCycle;
        private readonly CycleMethod _cycleMethod;

        public NumberOfDaysPerCycle(CycleMethod cycleMethod)
        {
            _cycleMethod = cycleMethod;
            switch (_cycleMethod)
            {
                    case CycleMethod.Monthly:
                    _numberOfDaysPerCycle = MonthlyCycleDays;
                    break;
                    case CycleMethod.Annually:
                    _numberOfDaysPerCycle = AnnualCycleDays;
                    break;
                default:
                    throw new ArgumentException("Number of days per cycle requires a cycle method either being Monthly or Annually");
            }
        }

        public static implicit operator int(NumberOfDaysPerCycle numberOfDaysPerCycle)
        {
            return numberOfDaysPerCycle._numberOfDaysPerCycle;
        }

        public override string ToString()
        {
            return string.Format("Cycle method: {0}, Number of days per cycle: {1}", 
                _cycleMethod.GetDescription(),
                _numberOfDaysPerCycle);
        }
    }
}
