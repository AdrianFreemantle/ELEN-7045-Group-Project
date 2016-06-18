using Aps.Domain.Company.Tests.Stubs;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class CompanyFactory
    {
        public Company CreateCompany(CompanyName companyName, ICompanyType companyType, IScraperScript scraperScript, IBillingCycle billingCycle)
        {
            return new Company(companyName, companyType, scraperScript, billingCycle);
        }
    }
}
