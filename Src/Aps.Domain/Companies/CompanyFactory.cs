namespace Aps.Domain.Companies
{
    public class CompanyFactory
    {
        public Company CreateCompany(CompanyName companyName, CompanyType companyType, ScraperScript scraperScript, BillingCycle billingCycle, BaseUrl baseUrl)
        {
            Guard.ThatValueTypeNotDefaut(companyName, "companyName");
            Guard.ThatValueTypeNotDefaut(companyType, "companyType");
            Guard.ThatValueTypeNotDefaut(scraperScript, "scraperScript");
            Guard.ThatParameterNotNull(billingCycle, "billingCycle");
            Guard.ThatValueTypeNotDefaut(baseUrl, "baseUrl");
            return new Company(companyName, companyType, scraperScript, billingCycle, baseUrl);
        }
    }
}
