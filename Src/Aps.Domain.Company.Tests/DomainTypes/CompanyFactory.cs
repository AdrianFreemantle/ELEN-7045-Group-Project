using Aps.Domain.Company.Tests.Stubs;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class CompanyFactory
    {
        public Company CreateCompany(CompanyName companyName, ICompanyType companyType, IScraperScript scraperScript, IBillingCycle billingCycle)
        {
            Guard.ThatValueTypeNotDefaut(companyName, "companyName");
            //Guard.ThatValueTypeNotDefaut(companyName, "companyType");
            //Guard.ThatValueTypeNotDefaut(companyName, "scraperScript");
            //Guard.ThatValueTypeNotDefaut(companyName, "billingCycle");
            return new Company(companyName, companyType, scraperScript, billingCycle);
        }
    }
}
