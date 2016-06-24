using Aps.Domain.Companies;
using LightBDD;
using Shouldly;

namespace Aps.Domain.Company.Tests
{
    public partial class Company_Identity : FeatureFixture
    {
        private readonly CompanyFactory _companyFactory = new CompanyFactory();
        private Companies.Company _company1;
        private Companies.Company _company2;
        private bool areEqual;

        private void a_company(string company1Name)
        {
            var companyType = new CompanyType();
            var scraperScript = new ScraperScript();
            var billingCycle = new BillingCycle(new LeadTime(), new NumberOfDaysPerCycle(), new RetryInterval());
            var baseUrl = new BaseUrl();
            _company1 = _companyFactory.CreateCompany(new CompanyName(company1Name), companyType, scraperScript, billingCycle, baseUrl);
        }

        private void another_company(string company2Name)
        {
            var companyType = new CompanyType();
            var scraperScript = new ScraperScript();
            var billingCycle = new BillingCycle(new LeadTime(), new NumberOfDaysPerCycle(), new RetryInterval());
            var baseUrl = new BaseUrl();
            _company2 = _companyFactory.CreateCompany(new CompanyName(company2Name), companyType, scraperScript, billingCycle, baseUrl);
        }

        private void performing_an_equality_comparison()
        {
            areEqual = _company1.Equals(_company2);
        }

        private void the_companies_are_equal()
        {
            areEqual.ShouldBe(true);
        }

        private void the_companies_are_not_equal()
        {
            areEqual.ShouldBe(false);
        }
    }
}
