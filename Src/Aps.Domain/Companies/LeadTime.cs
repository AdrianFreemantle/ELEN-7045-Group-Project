namespace Aps.Domain.Companies
{
    public struct LeadTime
    {
        private readonly int _leadTimeInHours;

        public LeadTime(int leadTimeInHours)
        {
            _leadTimeInHours = leadTimeInHours;
        }

        public static implicit operator int(LeadTime leadTime)
        {
            return leadTime._leadTimeInHours;
        }

        public override string ToString()
        {
            return _leadTimeInHours.ToString();
        }
    }
}
