using System;
using Aps.Domain.Company.Tests.Stubs;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class Company : IEquatable<Company>
    {
        private readonly CompanyName _companyName;
        private readonly CompanyType _companyType;
        private readonly ScraperScript _scraperScript;
        private readonly BillingCycle _billingCycle;
        private readonly BaseUrl _baseUrl;

        protected Company()
        {
        }

        internal Company(CompanyName companyName, CompanyType companyType, ScraperScript scraperScript, BillingCycle billingCycle, BaseUrl baseUrl)
        {
            _companyName = companyName;
            _companyType = companyType;
            _scraperScript = scraperScript;
            _billingCycle = billingCycle;
            _baseUrl = baseUrl;
        }

        public bool Equals(Company other)
        {
            return _companyName.Equals(other._companyName);
        }

        public CompanyType GetType()
        {
            return _companyType;
        }
    }
}
