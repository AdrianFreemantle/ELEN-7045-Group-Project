using System;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class Company : IEquatable<Company>
    {
        public CompanyName CompanyName { get; private set; }
        public CompanyType CompanyType { get; private set; }
        public ScraperScript ScraperScript { get; private set; }
        public BillingCycle BillingCycle { get; private set; }
        public BaseUrl BaseUrl { get; private set; }

        protected Company()
        {
        }

        internal Company(CompanyName companyName, CompanyType companyType, ScraperScript scraperScript, BillingCycle billingCycle, BaseUrl baseUrl)
        {
            CompanyName = companyName;
            CompanyType = companyType;
            ScraperScript = scraperScript;
            BillingCycle = billingCycle;
            BaseUrl = baseUrl;
        }

        public bool Equals(Company other)
        {
            return CompanyName.Equals(other.CompanyName);
        }
    }
}
