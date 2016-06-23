namespace Aps.Domain.Company.Tests.DomainTypes
{
    public class CompanyFactory
    {
        public Company CreateCompany(CompanyName companyName, CompanyType companyType, ScraperScript scraperScript, BillingCycle billingCycle, BaseUrl baseUrl)
        {
            Guard.ThatValueTypeNotDefaut(companyName, "companyName");
            //Guard.ThatValueTypeNotDefaut(companyName, "companyType");
            //Guard.ThatValueTypeNotDefaut(companyName, "scraperScript");
            //Guard.ThatValueTypeNotDefaut(companyName, "billingCycle");
            return new Company(companyName, companyType, scraperScript, billingCycle, baseUrl);
        }
    }
}
