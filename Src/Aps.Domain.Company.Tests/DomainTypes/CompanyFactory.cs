using Aps.Domain.Company.Tests.Stubs;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class CompanyFactory : ICompanyFactory
    {
        public Company CreateCompany(CompanyName companyName, ICompanyType companyType, IScraperScript scraperScript, IBillingCycle billingCycle)
        {
            return new Company(companyName, companyType, scraperScript, billingCycle);
        }
    }

    public interface ICompanyFactory
    {
        Company CreateCompany(CompanyName companyName, ICompanyType companyType, IScraperScript scraperScript, IBillingCycle billingCycle);
    }
}
