using System;
using Aps.Domain.Company.Tests.Stubs;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class Company : IEquatable<Company>
    {
        private readonly CompanyName _companyName;
        private readonly ICompanyType _companyType;
        private readonly IScraperScript _scraperScript;
        private readonly IBillingCycle _billingCycle;

        protected Company()
        {
        }

        internal Company(CompanyName companyName, ICompanyType companyType, IScraperScript scraperScript, IBillingCycle billingCycle)
        {
            _companyName = companyName;
            _companyType = companyType;
            _scraperScript = scraperScript;
            _billingCycle = billingCycle;
        }

        public bool Equals(Company other)
        {
            return _companyName.Equals(other._companyName);
        }
    }
}
